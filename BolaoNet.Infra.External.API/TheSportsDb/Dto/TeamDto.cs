using Newtonsoft.Json;

namespace BolaoNet.Infra.External.API.TheSportsDb.Dto
{
    public class TeamDto
    {
        [JsonProperty("idTeam")]
        public string IdTeam { get; set; }

        [JsonProperty("strTeam")]
        public string Name { get; set; }

        [JsonProperty("strTeamShort")]
        public string ShortName { get; set; }

        [JsonProperty("strAlternate")]
        public string AlternateName { get; set; }

        [JsonProperty("intFormedYear")]
        public string FoundedYear { get; set; }

        [JsonProperty("strLeague")]
        public string League { get; set; }

        [JsonProperty("strCountry")]
        public string Country { get; set; }

        [JsonProperty("strWebsite")]
        public string Website { get; set; }

        [JsonProperty("strDescriptionEN")]
        public string Description { get; set; }

        [JsonProperty("strBadge")]
        public string Badge { get; set; }

        [JsonProperty("strLogo")]
        public string Logo { get; set; }

        [JsonProperty("strBanner")]
        public string Banner { get; set; }

        [JsonProperty("strFanart1")]
        public string Fanart1 { get; set; }
    }
}
