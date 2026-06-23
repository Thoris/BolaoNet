using Newtonsoft.Json;

namespace BolaoNet.Infra.External.API.TheSportsDb.Dto
{
    public class TimelineItemDto
    {
        [JsonProperty("idEvent")]
        public string EventId { get; set; }

        [JsonProperty("strTimeline")]
        public string TimelineType { get; set; }

        [JsonProperty("intTime")]
        public string Minute { get; set; }

        [JsonProperty("strPlayer")]
        public string Player { get; set; }

        [JsonProperty("strTeam")]
        public string Team { get; set; }
    }
}
