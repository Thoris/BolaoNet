using Newtonsoft.Json;
using System.Collections.Generic;

namespace BolaoNet.Infra.External.API.TheSportsDb.Dto
{
    public class TeamResponseDto
    {
        [JsonProperty("teams")]
        public List<TeamDto> Teams { get; set; }
    }
}
