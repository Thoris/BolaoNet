using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BolaoNet.Infra.External.API.OpenFootball.Dto
{
    public sealed class WorldCupDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("matches")]
        public List<MatchDto> Matches { get; set; } 
    }
}
