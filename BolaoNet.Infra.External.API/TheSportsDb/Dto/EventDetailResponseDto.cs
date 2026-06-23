using BolaoNet.Infra.External.API.TheSportsDb.Dto.BolaoNet.Infra.External.API.TheSportsDb.Dto;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BolaoNet.Infra.External.API.TheSportsDb.Dto
{
    public class EventDetailResponseDto
    {
        [JsonProperty("events")]
        public List<EventDetailDto> Events { get; set; }
    }
}
