using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BolaoNet.Infra.External.API.OpenFootball.Dto
{
    public sealed class ScoreDto
    {
        [JsonPropertyName("ft")]
        public List<int> FullTime { get; set; }

        [JsonPropertyName("ht")]
        public List<int> HalfTime { get; set; }

        [JsonPropertyName("et")]
        public List<int> ExtraTime { get; set; }

        [JsonPropertyName("p")]
        public List<int> Penalties { get; set; }
    }
}
