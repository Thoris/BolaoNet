using Newtonsoft.Json;
using System.Collections.Generic;

namespace BolaoNet.Infra.External.API.TheSportsDb.Dto
{
    public class EventTimelineResponse
    {
        [JsonProperty("timeline")]
        public List<EventTimelineItemDto> Timeline { get; set; }
            = new List<EventTimelineItemDto>();
    }
}
