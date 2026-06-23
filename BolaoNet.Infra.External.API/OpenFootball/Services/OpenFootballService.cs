using BolaoNet.Domain.Entities.EnriquecimentoDados;
using BolaoNet.Infra.External.API.OpenFootball.Client;
using BolaoNet.Infra.External.API.OpenFootball.Dto;
using BolaoNet.Infra.External.API.OpenFootball.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BolaoNet.Infra.External.API.OpenFootball.Services
{
    public class OpenFootballService
    {
        private readonly OpenFootballClient _client;

        public OpenFootballService(
            OpenFootballClient client)
        {
            _client = client;
        }

        #region Sync Matches

        public async Task<List<WorldCupMatch>> GetWorldCupMatchesAsync(
            int year,
            CancellationToken cancellationToken = default)
        {
            var matches = await _client.GetSeasonMatchesAsync(
                year,
                cancellationToken);

            if (matches == null)
                return new List<WorldCupMatch>();

            return matches
                .Select(OpenFootballMapper.ToDomain)
                .ToList();
        }

        #endregion

        #region Match Details

        public async Task<WorldCupMatch> GetMatchDetailsAsync(
            int year,
            DateTime date,
            string homeTeam,
            string awayTeam,
            CancellationToken cancellationToken = default)
        {
            var match = await _client.GetMatchAsync(
                year,
                date,
                homeTeam,
                awayTeam,
                cancellationToken);

            if (match == null)
                return null;

            var domain = OpenFootballMapper.ToDomain(match);

            domain.Events = ParseMatchEvents(match);

            return domain;
        }

        #endregion

        #region Daily Sync

        public async Task<List<WorldCupMatch>> GetMatchesByDateAsync(
            int year,
            DateTime date,
            CancellationToken cancellationToken = default)
        {
            var matches = await _client.GetMatchesByDateAsync(
                year,
                date,
                cancellationToken);

            if (matches == null)
                return new List<WorldCupMatch>();

            return matches
                .Select(OpenFootballMapper.ToDomain)
                .ToList();
        }

        #endregion

        #region Match Events

        public async Task<List<MatchEvent>> GetMatchEventsAsync(
            int year,
            DateTime date,
            string homeTeam,
            string awayTeam,
            CancellationToken cancellationToken = default)
        {
            var match = await _client.GetMatchAsync(
                year,
                date,
                homeTeam,
                awayTeam,
                cancellationToken);

            if (match == null)
                return new List<MatchEvent>();

            return ParseMatchEvents(match);
        }

        private List<MatchEvent> ParseMatchEvents(
            MatchDto match)
        {
            var events = new List<MatchEvent>();

            if (match.Goals1 != null)
            {
                events.AddRange(
                    ParseGoals(
                        match.Goals1,
                        match.Team1,
                        isHomeTeam: true));
            }

            if (match.Goals2 != null)
            {
                events.AddRange(
                    ParseGoals(
                        match.Goals2,
                        match.Team2,
                        isHomeTeam: false));
            }

            return events
                .OrderBy(x => x.Minute)
                .ThenBy(x => x.ExtraMinute)
                .ToList();
        }

        private List<MatchEvent> ParseGoals(
            IEnumerable<GoalDto> goals,
            string team,
            bool isHomeTeam)
        {
            var result = new List<MatchEvent>();

            foreach (var goal in goals)
            {
                var (minute, extraTime) =
                    GoalMinuteParser.Parse(goal.Minute);

                result.Add(new MatchEvent
                {
                    EventType = "goal",
                    TeamName = team,
                    PlayerName = goal.Player,
                    Minute = minute,
                    ExtraMinute = extraTime,
                    IsPenalty = goal.Penalty,
                    IsOwnGoal = goal.OwnGoal,
                    RawDescription = goal.Minute + "' " + goal.Player,
                    IsHomeTeam = isHomeTeam
                });
            }

            return result;
        }

        #endregion
    }
}
