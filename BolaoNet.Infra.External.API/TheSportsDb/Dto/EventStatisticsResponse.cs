using Newtonsoft.Json;
using System.Collections.Generic;

namespace BolaoNet.Infra.External.API.TheSportsDb.Dto
{
    public class EventStatisticsResponse
    {
        [JsonProperty("eventstats")]
        public List<EventStatisticDto> EventStats { get; set; }
            = new List<EventStatisticDto>();
    }
}
