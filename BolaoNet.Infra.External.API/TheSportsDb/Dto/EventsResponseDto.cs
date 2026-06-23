using BolaoNet.Infra.External.API.TheSportsDb.Dto.BolaoNet.Infra.External.API.TheSportsDb.Dto;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BolaoNet.Infra.External.API.TheSportsDb.Dto
{
    public class EventsResponseDto
    {
        [JsonProperty("events")]
        public List<EventDto> Events { get; set; }
    }
}
