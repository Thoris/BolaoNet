using Newtonsoft.Json;

namespace BolaoNet.Infra.External.API.TheSportsDb.Dto
{
    namespace BolaoNet.Infra.External.API.TheSportsDb.Dto
    {
        public class EventDto
        {
            [JsonProperty("idEvent")]
            public string IdEvent { get; set; }

            [JsonProperty("strEvent")]
            public string EventName { get; set; }

            [JsonProperty("strFilename")]
            public string FileName { get; set; }

            [JsonProperty("strSport")]
            public string Sport { get; set; }

            [JsonProperty("idLeague")]
            public string LeagueId { get; set; }

            [JsonProperty("strLeague")]
            public string LeagueName { get; set; }

            [JsonProperty("strSeason")]
            public string Season { get; set; }

            [JsonProperty("strStatus")]
            public string Status { get; set; }

            [JsonProperty("dateEvent")]
            public string DateEvent { get; set; }

            [JsonProperty("strTime")]
            public string Time { get; set; }

            [JsonProperty("idHomeTeam")]
            public string HomeTeamId { get; set; }

            [JsonProperty("idAwayTeam")]
            public string AwayTeamId { get; set; }

            [JsonProperty("strHomeTeam")]
            public string HomeTeam { get; set; }

            [JsonProperty("strAwayTeam")]
            public string AwayTeam { get; set; }

            [JsonProperty("intHomeScore")]
            public int? HomeScore { get; set; }

            [JsonProperty("intAwayScore")]
            public int? AwayScore { get; set; }

            [JsonProperty("strVenue")]
            public string Venue { get; set; }

            [JsonProperty("strCountry")]
            public string Country { get; set; }

            [JsonProperty("strCity")]
            public string City { get; set; }
        }
    }
}
