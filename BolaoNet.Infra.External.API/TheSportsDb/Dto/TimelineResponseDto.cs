using Newtonsoft.Json;
using System.Collections.Generic;

namespace BolaoNet.Infra.External.API.TheSportsDb.Dto
{
    public class TimelineResponseDto
    {
        [JsonProperty("timeline")]
        public List<TimelineItemDto> Timeline { get; set; }
    }
}
