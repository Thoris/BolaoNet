using BolaoNet.Domain.Entities.EnriquecimentoDados;
using BolaoNet.Infra.External.API.TheSportsDb;
using BolaoNet.Infra.External.API.TheSportsDb.Client;
using BolaoNet.Infra.External.API.TheSportsDb.Dto.BolaoNet.Infra.External.API.TheSportsDb.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoNet.Application.Services
{
    public class TheSportsDbService
    {
        private readonly TheSportsDbClient _client;

        public TheSportsDbService(TheSportsDbClient client)
        {
            _client = client;
        }

        #region Sync Matches (return domain)

        public async Task<List<WorldCupMatch>> GetMatchesAsync(long id, string season)
        {
            var response = await _client.GetSeasonMatchesAsync(id, season);

            if (response?.Events == null)
                return new List<WorldCupMatch>();

            return response.Events
                .Select(TheSportsDbMapper.ToDomain)
                .ToList();
        }

        #endregion

        #region Match Details (single match enriched)

        public async Task<WorldCupMatch> GetMatchDetailsAsync(string eventId)
        {
            var response = await _client.GetMatchDetailsAsync(eventId);

            var match = response?.Events?.FirstOrDefault();

            if (match == null)
                return null;

            var domain = TheSportsDbMapper.ToDomain(match);

            // enrich with parsed events (sem persistência)
            domain.Events = ParseMatchEvents(match);

            return domain;
        }

        #endregion

        #region Daily sync (return list only)

        public async Task<List<WorldCupMatch>> GetMatchesByDateAsync(DateTime date)
        {
            var response = await _client.GetEventsByDateAsync(date);

            if (response?.Events == null)
                return new List<WorldCupMatch>();

            return response.Events
                .Where(x => x.LeagueId == "4429")
                .Select(TheSportsDbMapper.ToDomain)
                .ToList();
        }

        #endregion

        #region Event parsing (domain only)

        private List<MatchEvent> ParseMatchEvents(EventDetailDto match)
        {
            var events = new List<MatchEvent>();

            if (!string.IsNullOrEmpty(match.HomeGoalDetails))
                events.AddRange(ParseGoals(match.HomeGoalDetails, match.HomeTeam));

            if (!string.IsNullOrEmpty(match.AwayGoalDetails))
                events.AddRange(ParseGoals(match.AwayGoalDetails, match.AwayTeam));

            return events;
        }

        private List<MatchEvent> ParseGoals(string raw, string team)
        {
            var result = new List<MatchEvent>();

            var parts = raw.Split(';');

            foreach (var p in parts)
            {
                var cleaned = p.Trim();

                if (!cleaned.Contains(":"))
                    continue;

                var split = cleaned.Split(':');

                if (!int.TryParse(split[0].Replace("'", "").Trim(), out var minute))
                    continue;

                var player = split[1].Trim();

                result.Add(new MatchEvent
                {
                    EventType = "goal",
                    PlayerName = player,
                    TeamName = team,
                    Minute = minute,
                    RawDescription = raw
                });
            }

            return result;
        }

        #endregion

        public async Task<List<MatchEvent>> GetMatchTimelineAsync(
            string eventId)
        {
            var response =
                await _client.GetMatchTimelineAsync(eventId);

            return TheSportsDbMapper
                .ToDomain(response, eventId)
                .ToList();
        }

        //public async Task<List<MatchStatistic>> GetMatchStatisticsAsync(
        //    string eventId)
        //{
        //    var response =
        //        await _client.GetMatchStatisticsAsync(eventId);

        //    return TheSportsDbMapper
        //        .ToDomain(response, eventId)
        //        .ToList();
        //}

        public async Task<List<WorldCupMatch>> GetWorldCupMatchesAsync(
            string season)
        {
            var response =
                await _client.GetSeasonMatchesAsync(
                    4429,
                    season);

            return response.Events
                .Select(TheSportsDbMapper.ToDomain)
                .ToList();
        }
    }
}