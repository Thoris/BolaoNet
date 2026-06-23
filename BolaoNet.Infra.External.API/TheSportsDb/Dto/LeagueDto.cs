using Newtonsoft.Json;

namespace BolaoNet.Infra.External.API.TheSportsDb.Dto
{
    public class LeagueDto
    {
        [JsonProperty("idLeague")]
        public string IdLeague { get; set; }

        [JsonProperty("strLeague")]
        public string Name { get; set; }

        [JsonProperty("strSport")]
        public string Sport { get; set; }

        [JsonProperty("strLeagueAlternate")]
        public string AlternateName { get; set; }

        [JsonProperty("strCurrentSeason")]
        public string CurrentSeason { get; set; }

        [JsonProperty("strCountry")]
        public string Country { get; set; }

        [JsonProperty("strDescriptionEN")]
        public string Description { get; set; }

        [JsonProperty("strBadge")]
        public string Badge { get; set; }

        [JsonProperty("strLogo")]
        public string Logo { get; set; }
    }
}
