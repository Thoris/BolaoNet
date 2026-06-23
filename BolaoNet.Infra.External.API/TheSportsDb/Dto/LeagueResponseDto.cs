using Newtonsoft.Json;
using System.Collections.Generic;

namespace BolaoNet.Infra.External.API.TheSportsDb.Dto
{
    public class LeagueResponseDto
    {
        [JsonProperty("leagues")]
        public List<LeagueDto> Leagues { get; set; }
    }
}
