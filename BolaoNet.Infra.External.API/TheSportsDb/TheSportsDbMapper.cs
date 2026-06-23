using BolaoNet.Domain.Entities.EnriquecimentoDados;
using BolaoNet.Infra.External.API.TheSportsDb.Dto;
using BolaoNet.Infra.External.API.TheSportsDb.Dto.BolaoNet.Infra.External.API.TheSportsDb.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BolaoNet.Infra.External.API.TheSportsDb
{
    public static class TheSportsDbMapper
    {
        public static WorldCupMatch ToDomain(EventDto dto)
        {
            return new WorldCupMatch
            {
                ExternalId = dto.IdEvent,
                LeagueId = int.TryParse(dto.LeagueId, out var l) ? l : 0,
                Season = dto.Season,
                MatchDate = DateTime.Parse($"{dto.DateEvent} {dto.Time}"),
                HomeTeam = dto.HomeTeam,
                AwayTeam = dto.AwayTeam,
                HomeScore = dto.HomeScore,
                AwayScore = dto.AwayScore,
                Status = NormalizeStatus(dto.Status),
                AwayTeamId = dto.AwayTeamId,
                HomeTeamId = dto.HomeTeamId,
                Venue = dto.Venue
            };
        }

        public static MatchEvent ParseGoal(string raw, string team)
        {
            // exemplo: "12': Neymar; 44': Vinicius"
            var parts = raw.Split(';');

            var events = new List<MatchEvent>();

            foreach (var p in parts)
            {
                var cleaned = p.Trim();

                if (!cleaned.Contains(":")) continue;

                var split = cleaned.Split(':');

                var minute = int.Parse(split[0].Replace("'", "").Trim());
                var player = split[1].Trim();

                events.Add(new MatchEvent
                { 
                    EventType = "goal",                    
                    Minute = minute,
                    PlayerName = player,
                    TeamName = team,
                    RawDescription = raw
                });
            }

            return null;
        }

        private static string NormalizeStatus(string status)
        {
            if (string.IsNullOrEmpty(status))
                return "Scheduled";

            if (status.Contains("Finished"))
                return "Finished";

            if (status.Contains("In Progress"))
                return "Live";

            return status;
        }


        public static IEnumerable<MatchEvent> ToDomain(
            TimelineResponseDto response,
            string matchExternalId)
        {
            if (response?.Timeline == null)
                return Enumerable.Empty<MatchEvent>();

            return response.Timeline.Select(x => new MatchEvent
            {
                ExternalId = matchExternalId,

                EventType = NormalizeType(x.TimelineType),

                Minute = ParseInt(x.Minute),

                PlayerName = x.Player,
                
                TeamName = x.Team,

                RawDescription =
                    $"{x.Minute}' {x.Player}"
            });
        }

        private static int? ParseInt(string value)
        {
            if (int.TryParse(value, out var result))
                return result;

            return null;
        }

        private static string NormalizeType(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "Unknown";

            value = value.ToUpperInvariant();

            if (value.Contains("GOAL"))
                return "Goal";

            if (value.Contains("YELLOW"))
                return "YellowCard";

            if (value.Contains("RED"))
                return "RedCard";

            if (value.Contains("SUB"))
                return "Substitution";

            return value;
        }

        //public static IEnumerable<MatchStatistic> ToDomain(
        //        EventStatisticsResponseDto dto,
        //        string matchExternalId)
        //{
        //    if (dto?.EventStats == null)
        //        return Enumerable.Empty<MatchStatistic>();

        //    return dto.EventStats.Select(x => new MatchStatistic
        //    {
        //        ExternalId = matchExternalId,
        //        StatisticType = x.StatisticName,
        //        HomeValue = x.HomeValue.ToString(),
        //        AwayValue = x.AwayValue.ToString()
        //    });
        //}

        public static List<MatchEvent> ToDomain(
             EventTimelineResponse response,
             string matchExternalId)
        {
            if (response?.Timeline == null)
                return new List<MatchEvent>();

            return response.Timeline
                .Select(x => new MatchEvent
                {
                    ExternalId = matchExternalId, 

                    //ExternalEventKey = x.PlayerId,

                    EventType = x.TimelineTypeDetail, // NormalizeTypeEvent(x.TimelineType),

                    PlayerName = x.Player,

                    TeamName = x.Team,

                    TeamExternalId = x.TeamExternalId,

                    AssistPlayerName = x.Assist,

                    IsHomeTeam = x.HomeTeam == "Yes",
                    
                    Minute = ParseMinute(x.Minute),

                    RawDescription =
                        x.Description ??
                        x.Detail ??
                        $"{x.Minute}' {x.Player}"
                })
                .ToList();
        }

        private static int? ParseMinute(string minute)
        {
            if (string.IsNullOrWhiteSpace(minute))
                return null;

            if (int.TryParse(minute, out var value))
                return value;

            return null;
        }

        private static string NormalizeTypeEvent(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return "Unknown";

            type = type.ToUpperInvariant();

            if (type.Contains("GOAL"))
                return "Goal";

            if (type.Contains("YELLOW"))
                return "YellowCard";

            if (type.Contains("RED"))
                return "RedCard";

            if (type.Contains("SUB"))
                return "Substitution";

            return type;
        }

        //public static List<MatchStatistic> ToDomain(
        //    EventStatisticsResponse response,
        //    string matchExternalId)
        //{
        //    if (response?.EventStats == null)
        //        return new List<MatchStatistic>();

        //    return response.EventStats
        //        .Select(x => new MatchStatistic
        //        {
        //            ExternalId = matchExternalId,
        //            StatisticType = x.StatisticName,
        //            HomeValue = x.HomeValue.ToString()  ,
        //            AwayValue = x.AwayValue.ToString()
        //        })
        //        .ToList();
        //}
    }
}
