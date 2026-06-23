using System;

namespace BolaoNet.Infra.External.API.TheSportsDb.Dto
{
    public class WorldCupMatchDto
    {
        public string ExternalId { get; set; }

        public DateTime MatchDate { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public int? HomeScore { get; set; }

        public int? AwayScore { get; set; }

        public string Status { get; set; }

        public string Venue { get; set; }

        public string League { get; set; }

        public string Season { get; set; }
    }
}
