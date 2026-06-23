using Newtonsoft.Json;

namespace BolaoNet.Infra.External.API.TheSportsDb.Dto
{
    public class EventTimelineItemDto
    {
        [JsonProperty("idEvent")]
        public string EventId { get; set; }

        [JsonProperty("strTimeline")]
        public string TimelineType { get; set; }

        [JsonProperty("strTimelineDetail")]
        public string TimelineTypeDetail { get; set; }

        [JsonProperty("intTime")]
        public string Minute { get; set; }

        [JsonProperty("strPlayer")]
        public string Player { get; set; }

        [JsonProperty("strAssist")]
        public string Assist { get; set; }

        [JsonProperty("strTeam")]
        public string Team { get; set; }

        [JsonProperty("strDetail")]
        public string Detail { get; set; }

        [JsonProperty("strDescription")]
        public string Description { get; set; }

        [JsonProperty("strComment")]
        public string Comment { get; set; }

        [JsonProperty("idTeam")]
        public string TeamExternalId { get; set; }

        [JsonProperty("idPlayer")]
        public string PlayerId { get; set; }

        [JsonProperty("strHome")]
        public string HomeTeam { get; set; }
    }
}
