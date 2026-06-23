//using BolaoNet.Domain.Entities.EnriquecimentoDados;
//using BolaoNet.Domain.Interfaces.Repositories.Campeonatos;
//using BolaoNet.Domain.Interfaces.Repositories.EnriquecimentoDados;
//using BolaoNet.Infra.External.API.OpenFootball.Services;
//using System;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

//namespace BolaoNet.Domain.Services.EnriquecimentoDados
//{
//    public class MatchOrchestratorOpenFootball
//    {
//        private readonly OpenFootballService _service;

//        private readonly IMatchEventRepositoryDao _matchEventRepository;
//        private readonly ITeamRepositoryDao _teamRepository;
//        private readonly IWorldCupMatchRepositoryDao _worldCupMatchRepository;
//        private readonly IMatchStatisticRepositoryDao _matchStatisticRepository;
//        private readonly ITeamAliasRepositoryDao _teamAliasRepository;
//        private readonly IJogoDao _jogoDao;

//        public MatchOrchestratorOpenFootball(
//            OpenFootballService service,
//            IMatchEventRepositoryDao matchEventRepository,
//            ITeamRepositoryDao teamRepository,
//            IWorldCupMatchRepositoryDao worldCupMatchRepository,
//            IMatchStatisticRepositoryDao matchStatisticRepository,
//            ITeamAliasRepositoryDao teamAliasRepository,
//            IJogoDao jogoDao)
//        {
//            _service = service;

//            _matchEventRepository = matchEventRepository;
//            _teamRepository = teamRepository;
//            _worldCupMatchRepository = worldCupMatchRepository;
//            _matchStatisticRepository = matchStatisticRepository;
//            _teamAliasRepository = teamAliasRepository;
//            _jogoDao = jogoDao;
//        }

//        #region DAILY SYNC

//        public async Task SyncDailyMatches(DateTime date)
//        {
//            var matches = await _service.GetMatchesByDateAsync(
//                2026,
//                date);

//            foreach (var match in matches)
//            {
//                UpsertTeams(match);
//                await UpsertMatch(match);
//            }
//        }

//        #endregion

//        #region LIVE SYNC

//        public async Task SyncLiveMatches()
//        {
//            var matches = await _service.GetMatchesByDateAsync(
//                2026,
//                DateTime.UtcNow);

//            var liveMatches = matches
//                .Where(m => IsLive(m.Status))
//                .ToList();

//            foreach (var match in liveMatches)
//            {
//                await SyncMatchDeep(match.ExternalId);
//            }
//        }

//        #endregion

//        #region MATCH DETAILS

//        public async Task SyncMatchDeep(string externalId)
//        {
//            var match = await _service.GetMatchDetailsAsync(
//                2026,
//                DateTime.UtcNow, // fallback, pois OpenFootball não usa ID real
//                "", "", CancellationToken.None);

//            if (match == null)
//                return;

//            UpsertTeams(match);

//            await UpsertMatch(match);

//            await SyncEvents(match);

//            var timeline = await _service.GetMatchEventsAsync(
//                2026,
//                match.MatchDate,
//                match.HomeTeam,
//                match.AwayTeam);

//            await SyncTimeline(externalId, timeline);
//        }

//        #endregion

//        #region MATCH

//        private async Task UpsertMatch(WorldCupMatch match)
//        {
//            var existing = _worldCupMatchRepository
//                .GetByExternalId(match.ExternalId);

//            if (existing == null)
//            {
//                _worldCupMatchRepository.Insert(match);
//                return;
//            }

//            MergeMatch(existing, match);

//            _worldCupMatchRepository.Update(existing);
//        }

//        #endregion

//        #region TEAMS

//        private void UpsertTeams(WorldCupMatch match)
//        {
//            UpsertTeam(match.HomeTeam);
//            UpsertTeam(match.AwayTeam);
//        }

//        private void UpsertTeam(string teamName)
//        {
//            if (string.IsNullOrWhiteSpace(teamName))
//                return;

//            var existing = _teamRepository.GetByName(teamName);

//            if (existing != null)
//                return;

//            _teamRepository.Insert(new Team
//            {
//                Name = teamName,
//                ExternalId = null
//            });
//        }

//        #endregion

//        #region EVENTS

//        private async Task SyncEvents(WorldCupMatch match)
//        {
//            if (match.Events == null || !match.Events.Any())
//                return;

//            var existingEvents = _matchEventRepository
//                .GetByMatchExternalId(match.ExternalId);

//            foreach (var ev in match.Events)
//            {
//                bool exists = existingEvents.Any(x =>
//                    x.EventType == ev.EventType &&
//                    x.PlayerName == ev.PlayerName &&
//                    x.Minute == ev.Minute);

//                if (!exists)
//                {
//                    _matchEventRepository.Insert(new MatchEvent
//                    {
//                        ExternalId = match.ExternalId,
//                        EventType = ev.EventType,
//                        PlayerName = ev.PlayerName,
//                        TeamName = ev.TeamName,
//                        Minute = ev.Minute,
//                        ExtraMinute = ev.ExtraMinute,
//                        IsPenalty = ev.IsPenalty,
//                        IsOwnGoal = ev.IsOwnGoal,
//                        RawDescription = ev.RawDescription
//                    });
//                }
//            }
//        }

//        #endregion

//        #region HELPERS

//        private bool IsLive(string status)
//        {
//            if (string.IsNullOrWhiteSpace(status))
//                return false;

//            status = status.ToUpperInvariant();

//            return status == "LIVE"
//                || status.Contains("IN PROGRESS")
//                || status == "1H"
//                || status == "2H"
//                || status == "HT";
//        }

//        private void MergeMatch(WorldCupMatch target, WorldCupMatch source)
//        {
//            target.HomeScore = source.HomeScore;
//            target.AwayScore = source.AwayScore;
//            target.Status = source.Status;
//            target.MatchDate = source.MatchDate;

//            if (!string.IsNullOrWhiteSpace(source.Venue))
//                target.Venue = source.Venue;
//        }

//        #endregion

//        #region TIMELINE

//        private async Task SyncTimeline(
//            string matchExternalId,
//            System.Collections.Generic.IEnumerable<MatchEvent> events)
//        {
//            if (events == null)
//                return;

//            var existingEvents =
//                _matchEventRepository.GetByMatchExternalId(matchExternalId);

//            foreach (var ev in events)
//            {
//                bool exists = existingEvents.Any(x =>
//                    x.EventType == ev.EventType &&
//                    x.PlayerName == ev.PlayerName &&
//                    x.Minute == ev.Minute);

//                if (exists)
//                    continue;

//                ev.ExternalId = matchExternalId;
//                ev.CreatedAt = DateTime.Now;

//                _matchEventRepository.Insert(ev);
//            }
//        }

//        #endregion
         

//        #region ASSOCIATE MATCHES

//        public async Task AssociateMatches(int season)
//        {
//            try
//            {
//                var localMatches = await _jogoDao.GetWithoutExternalId();

//                if (localMatches == null || !localMatches.Any())
//                    return;

//                var aliases = _teamAliasRepository.GetAll();

//                var apiMatches = await _service.GetWorldCupMatchesAsync(2026);

//                foreach (var match in apiMatches)
//                {
//                    if (_worldCupMatchRepository.GetByExternalId(match.ExternalId) == null)
//                    {
//                        _worldCupMatchRepository.Insert(match);
//                    }
//                }

//                foreach (var local in localMatches)
//                {
//                    var homeApiName = aliases
//                        .FirstOrDefault(x =>
//                            x.LocalName.Equals(local.NomeTime1, StringComparison.OrdinalIgnoreCase))
//                        ?.ApiName;

//                    var awayApiName = aliases
//                        .FirstOrDefault(x =>
//                            x.LocalName.Equals(local.NomeTime2, StringComparison.OrdinalIgnoreCase))
//                        ?.ApiName;

//                    if (string.IsNullOrWhiteSpace(homeApiName) ||
//                        string.IsNullOrWhiteSpace(awayApiName))
//                        continue;

//                    var apiMatch = apiMatches.FirstOrDefault(x =>
//                        Math.Abs((x.MatchDate - local.DataJogo).TotalHours) <= 36
//                        && x.HomeTeam.Equals(homeApiName, StringComparison.OrdinalIgnoreCase)
//                        && x.AwayTeam.Equals(awayApiName, StringComparison.OrdinalIgnoreCase));

//                    if (apiMatch == null)
//                        continue;

//                    local.ExternalId = int.Parse(apiMatch.ExternalId);

//                    _jogoDao.Update(local);
//                }
//            }
//            catch
//            {
//                // log necessário
//            }
//        }

//        #endregion
//    }
//}
