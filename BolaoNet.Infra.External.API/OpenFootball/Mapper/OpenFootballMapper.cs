using BolaoNet.Domain.Entities.EnriquecimentoDados;
using BolaoNet.Infra.External.API.OpenFootball.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BolaoNet.Infra.External.API.OpenFootball.Mapper
{
    public static class OpenFootballMapper
    {
        public static WorldCupMatch ToDomain(MatchDto source)
        {
            if (source == null)
                return null;

            DateTime.TryParseExact(
                source.Date,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var matchDate);

            TimeSpan matchTime = TimeSpan.Zero;

            //if (!string.IsNullOrWhiteSpace(source.Time))
            //{
            //    TimeSpan.TryParse(
            //        source.Time,
            //        CultureInfo.InvariantCulture,
            //        out matchTime);
            //}


            //DateTimeOffset matchTime = DateTimeOffset.MinValue;

            //// exemplo: "13:00 UTC-6"
            //var input = source.Time;

            //if (!string.IsNullOrWhiteSpace(input))
            //{
            //    // extrai hora e offset
            //    var match = Regex.Match(input, @"(?<time>\d{2}:\d{2})\s*UTC(?<offset>[+-]\d{1,2})");

            //    if (match.Success)
            //    {
            //        var time = TimeSpan.Parse(match.Groups["time"].Value);

            //        var offsetHours = int.Parse(match.Groups["offset"].Value);
            //        var offset = TimeSpan.FromHours(offsetHours);

            //        var today = DateTime.Today;

            //        matchTime = new DateTimeOffset(
            //            today.Year, today.Month, today.Day,
            //            time.Hours, time.Minutes, 0,
            //            offset
            //        );
            //    }
            //}

            return new WorldCupMatch
            {
                //ExternalId = BuildExternalId(source),

                MatchDate = matchDate.Date.Add(matchTime),

                HomeTeam = source.Team1,
                AwayTeam = source.Team2,

                HomeScore = source.Score?.FullTime?.Count > 0
                    ? source.Score.FullTime[0]
                    : (int?)null,

                AwayScore = source.Score?.FullTime?.Count > 1
                    ? source.Score.FullTime[1]
                    : (int?)null,

                Round = source.Round,

                Group = source.Group,

                Ground = source.Ground,

                Status = GetStatus(source),
                
                Events = new List<MatchEvent>()
            };
        }

        public static string BuildExternalId(MatchDto source)
        {
            return string.Format(
                    "{0}_{1}_{2}",
                    source.Date,
                    source.Team1,
                    source.Team2)
                .Replace(" ", "_")
                .Replace("/", "_")
                .Replace("-", "_");
        }

        private static string GetStatus(MatchDto source)
        {
            if (source?.Score?.FullTime == null)
                return "scheduled";

            return "finished";
        }
    }

}
