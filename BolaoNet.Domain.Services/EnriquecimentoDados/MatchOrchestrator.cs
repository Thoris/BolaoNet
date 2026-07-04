using BolaoNet.Application.Services;
using BolaoNet.Domain.Entities.EnriquecimentoDados;
using BolaoNet.Domain.Interfaces.Repositories.Campeonatos;
using BolaoNet.Domain.Interfaces.Repositories.EnriquecimentoDados;
using BolaoNet.Domain.Interfaces.Services.EnriquecimentoDados;
using BolaoNet.Infra.External.API.OpenFootball.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.EnriquecimentoDados
{
    public class MatchOrchestrator : IMatchOrchestrator
    {
        private readonly TheSportsDbService _service;
        private readonly OpenFootballService _serviceOpenFootball;
        private readonly IMatchEventRepositoryDao _matchEventRepository; 
        private readonly IWorldCupMatchRepositoryDao _worldCupMatchRepository; 
        private readonly ITeamAliasRepositoryDao _teamAliasRepository;
        private readonly IJogoDao _jogoDao;

        public MatchOrchestrator(
            TheSportsDbService service,
            IMatchEventRepositoryDao matchEventRepository, 
            IWorldCupMatchRepositoryDao worldCupMatchRepository, 
            ITeamAliasRepositoryDao teamAliasRepository,
            IJogoDao jogoDao,
            OpenFootballService openFootballService)
        {
            _service = service;
            _serviceOpenFootball = openFootballService;
            _matchEventRepository = matchEventRepository; 
            _worldCupMatchRepository = worldCupMatchRepository; 
            _teamAliasRepository = teamAliasRepository;
            _jogoDao = jogoDao;
        }

        #region DAILY SYNC

        public async Task SyncDailyMatches(DateTime date)
        {
            var matches = await _service.GetMatchesByDateAsync(date);

            foreach (var match in matches)
            {
                 //UpsertTeams(match);
                 UpsertMatch(match);
            }
        }

        #endregion

        #region LIVE SYNC

        public async Task SyncLiveMatches()
        {
            var matches = await _service.GetMatchesByDateAsync(DateTime.UtcNow);

            var liveMatches = matches
                .Where(m => IsLive(m.Status))
                .ToList();

            foreach (var match in liveMatches)
            {
                await SyncMatchDeep(match.ExternalId);
            }
        }

        #endregion

        #region MATCH DETAILS

        public async Task SyncMatchDeep(string externalId)
        {
            var match =
                await _service.GetMatchDetailsAsync(externalId);

            if (match == null)
                return;

            // UpsertTeams(match);

            await UpsertMatch(match);

            await SyncEvents(match);

            var timeline =
                await _service.GetMatchTimelineAsync(externalId);

            await SyncTimeline(
                externalId,
                timeline);

            //var statistics =
            //    await _service.GetMatchStatisticsAsync(externalId);

            //SyncStatistics(
            //    externalId,
            //    statistics);
        }

        #endregion

        #region MATCH

        private async Task UpsertMatch(WorldCupMatch match)
        {
            var existing = _worldCupMatchRepository
                .GetByExternalId(match.ExternalId);

            if (existing == null)
            {
                 _worldCupMatchRepository.Insert(match);
                return;
            }

            MergeMatch(existing, match);

            _worldCupMatchRepository.Update(existing);
        }

        #endregion

        #region TEAMS

        //private void UpsertTeams(WorldCupMatch match)
        //{
        //    UpsertTeam(match.HomeTeam);
        //    UpsertTeam(match.AwayTeam);
        //}

        //private void UpsertTeam(string teamName)
        //{
        //    return;

        //    if (string.IsNullOrWhiteSpace(teamName))
        //        return;

        //    var existing =  _teamRepository.GetByName(teamName);

        //    if (existing != null)
        //        return;

        //    _teamRepository.Insert(new Team
        //    {
        //        Name = teamName,
        //        ExternalId = null
        //    });
        //}

        #endregion

        #region EVENTS

        private async Task SyncEvents(WorldCupMatch match)
        {
            if (match.Events == null || !match.Events.Any())
                return;

            var existingEvents = _matchEventRepository
                .GetByMatchExternalId(match.ExternalId);

            foreach (var ev in match.Events)
            {
                bool exists = existingEvents.Any(x =>
                    x.EventType == ev.EventType &&
                    x.PlayerName == ev.PlayerName &&
                    x.Minute == ev.Minute);

                if (!exists)
                {
                    _matchEventRepository.Insert(new MatchEvent
                    {
                        ExternalId = match.ExternalId,
                        EventType = ev.EventType,
                        PlayerName = ev.PlayerName,
                        TeamName = ev.TeamName,
                        Minute = ev.Minute,
                        RawDescription = ev.RawDescription
                    });
                }
            }
        }

        #endregion

        #region HELPERS

        private bool IsLive(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                return false;

            status = status.ToUpperInvariant();

            return status == "1H"
                || status == "2H"
                || status == "HT"
                || status.Contains("LIVE")
                || status.Contains("IN PROGRESS");
        }

        private void MergeMatch(WorldCupMatch target, WorldCupMatch source)
        {
            target.HomeScore = source.HomeScore;
            target.AwayScore = source.AwayScore;
            target.Status = source.Status;

            if (!string.IsNullOrWhiteSpace(source.Venue))
                target.Venue = source.Venue;

            target.MatchDate = source.MatchDate;
            target.HomeTeam = source.HomeTeam;
            target.AwayTeam = source.AwayTeam;
        }

        #endregion

        private async Task SyncTimeline(
            string matchExternalId,
            System.Collections.Generic.IEnumerable<MatchEvent> timelineEvents)
        {
            if (timelineEvents == null)
                return;

            var existingEvents =
                _matchEventRepository
                    .GetByMatchExternalId(matchExternalId);

            foreach (var ev in timelineEvents)
            {
                bool exists = existingEvents.Any(x =>
                    x.EventType == ev.EventType &&
                    x.PlayerName == ev.PlayerName &&
                    x.Minute == ev.Minute);

                if (exists)
                    continue;

                ev.ExternalId = matchExternalId;

                if (string.IsNullOrWhiteSpace(ev.ExternalId))
                {
                    ev.ExternalId =
                        $"{matchExternalId}_{ev.EventType}_{ev.PlayerName}_{ev.Minute}";
                }

                ev.CreatedAt = DateTime.Now;
                _matchEventRepository.Insert(ev);
            }
        }

        //private void SyncStatistics(
        //    string matchExternalId,
        //    System.Collections.Generic.IEnumerable<MatchStatistic> statistics)
        //{
        //    if (statistics == null)
        //        return;

        //    _matchStatisticRepository
        //        .DeleteByMatchExternalId(matchExternalId);

        //    foreach (var stat in statistics)
        //    {
        //        stat.ExternalId = matchExternalId;

        //        _matchStatisticRepository.Insert(stat);
        //    }
        //}

        public async Task<int> CreateMatches(int season)
        {
            var apiMatchesOpenFootball = await _serviceOpenFootball.GetWorldCupMatchesAsync(season);

            var dbMatches = _worldCupMatchRepository.GetAll();

            if (dbMatches == null || !dbMatches.Any())
            {
                foreach (var apiMatch in apiMatchesOpenFootball)
                {
                    apiMatch.Season = season.ToString();
                    _worldCupMatchRepository.Insert(apiMatch);
                }
                return apiMatchesOpenFootball.Count;
            }
            else
            {
                foreach (var apiMatch in apiMatchesOpenFootball)
                {
                    if (apiMatch.Status != "finished")
                    {
                        apiMatch.Season = season.ToString();
                        _worldCupMatchRepository.Insert(apiMatch);
                    }
                }
            }
            return 0;
        }

        public async Task LoadExternalApiMatches(string season)
        {
            var dbMatches = _worldCupMatchRepository.GetAll();

            if (dbMatches == null || !dbMatches.Any())
                return;

            var apiMatches = await _service.GetWorldCupMatchesAsync(season);

            foreach (var api in apiMatches)
            {
                foreach (var local in dbMatches)
                {

                    if (Math.Abs((api.MatchDate - local.MatchDate).TotalHours) <= 24 && 
                        (
                        api.HomeTeam.Equals(local.HomeTeam, StringComparison.OrdinalIgnoreCase) &&
                        api.AwayTeam.Equals(local.AwayTeam, StringComparison.OrdinalIgnoreCase)
                        ) ||
                         (
                        api.HomeTeam.Equals(local.AwayTeam, StringComparison.OrdinalIgnoreCase) &&
                        api.AwayTeam.Equals(local.HomeTeam, StringComparison.OrdinalIgnoreCase)
                        )
                        )
                    {
                        if (local.ExternalId == api.ExternalId)
                        {
                            dbMatches.Remove(local);
                            break;
                        }
                    

                        local.ExternalId = api.ExternalId;
                        local.Venue = api.Venue; 
                        local.AwayTeamId = api.AwayTeamId;
                        local.HomeTeamId = api.HomeTeamId;
                        local.LeagueId = api.LeagueId;
                        local.Season = api.Season;
                        _worldCupMatchRepository.Update(local);

                        apiMatches.Remove(api);
                        break;
                    }
                }
            } 
        
        }

        public async Task AssociateMatches(int season)
        {

            var localMatches = await _jogoDao.GetWithoutExternalId();

            if (localMatches == null || !localMatches.Any())
                return;

            var aliases = _teamAliasRepository.GetAll();

            var apiMatches = _worldCupMatchRepository.GetAll();

            foreach (var local in localMatches)
            {
                var homeApiName = aliases
                    .FirstOrDefault(x =>
                        x.LocalName.Equals(
                            local.NomeTime1,
                            StringComparison.OrdinalIgnoreCase))
                    ?.ApiOpenFtName;

                var awayApiName = aliases
                    .FirstOrDefault(x =>
                        x.LocalName.Equals(
                            local.NomeTime2,
                            StringComparison.OrdinalIgnoreCase))
                    ?.ApiOpenFtName;

                string grupo1 = null;
                string grupo2 = null;

                if (string.IsNullOrWhiteSpace(homeApiName) ||
                    string.IsNullOrWhiteSpace(awayApiName))
                {
                    if (local.PendenteTime1NomeGrupo != null)
                    {
                        grupo1 = local.PendenteTime1PosGrupo.ToString() + local.PendenteTime1NomeGrupo;
                    }
                    if (local.PendenteTime2NomeGrupo != null)
                    {
                        grupo2 = local.PendenteTime2PosGrupo.ToString() + local.PendenteTime2NomeGrupo;
                    }
                    else
                    {
                        continue;
                    }
                }

                var apiMatch = apiMatches.FirstOrDefault(x =>
                    Math.Abs(
                        (x.MatchDate - local.DataJogo)
                        .TotalHours) <= 32

                    && x.HomeTeam.Equals(
                        homeApiName,
                        StringComparison.OrdinalIgnoreCase)

                    && x.AwayTeam.Equals(
                        awayApiName,
                        StringComparison.OrdinalIgnoreCase));

                if (apiMatch == null)
                {
                    if (grupo1 != null && grupo2 != null)
                    {
                        apiMatch = apiMatches.FirstOrDefault(x =>
                            Math.Abs(
                                (x.MatchDate - local.DataJogo)
                                .TotalHours) <= 72
                            && (x.HomeTeam.Equals(grupo1, StringComparison.OrdinalIgnoreCase) || x.HomeTeam.StartsWith("3"))
                            && (x.AwayTeam.Equals(grupo2, StringComparison.OrdinalIgnoreCase) || x.AwayTeam.StartsWith("3"))
                            );

                        if (apiMatch == null)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                local.ExternalId = apiMatch.Id;

                _jogoDao.Update(local);
            }
        }

        public async Task<bool> UpdateMatch(int id)
        {
            var match = _worldCupMatchRepository.GetList( x => x.Id == id).FirstOrDefault();

            if (match == null)
                return false;
            var data = await _serviceOpenFootball.GetMatchDetailsAsync(int.Parse(match.Season), match.MatchDate, match.HomeTeam, match.AwayTeam);

            if (data == null)
                return false;

            match.HomeScore = data.HomeScore;
            match.AwayScore = data.AwayScore;
            match.Status = data.Status;

            foreach (var ev in data.Events)
            { 
                var matchEvent = _matchEventRepository.GetList( x=> 
                                                x.MatchKeyId == id &&
                                                x.Minute == ev.Minute && 
                                                x.PlayerName == ev.PlayerName && 
                                                x.EventType == ev.EventType).FirstOrDefault();

                if (matchEvent == null)
                {
                    ev.MatchKeyId = id;
                    ev.CreatedAt = DateTime.Now;
                    _matchEventRepository.Insert(ev);
                }
            }

            
            match.LastSync = DateTime.Now;
            _worldCupMatchRepository.Update(match);
            return true;
        }


        public async Task<WorldCupMatch> LoadMatch (int id)
        {
            var match = _worldCupMatchRepository.GetList(x => x.Id == id).FirstOrDefault();

            if (match == null)
                return null;
            var data = await _serviceOpenFootball.GetMatchDetailsAsync(int.Parse(match.Season), match.MatchDate, match.HomeTeam, match.AwayTeam);

            if (data == null)
                return null;

            match.HomeScore = data.HomeScore;
            match.AwayScore = data.AwayScore;

            match.Events = data.Events.ToList();
             
            return match;
        }
    }
}