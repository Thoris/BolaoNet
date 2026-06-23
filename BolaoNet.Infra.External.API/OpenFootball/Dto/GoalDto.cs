using System.Text.Json.Serialization;

namespace BolaoNet.Infra.External.API.OpenFootball.Dto
{
    public sealed class GoalDto
    {
        [JsonPropertyName("name")]
        public string Player { get; set; } = string.Empty;

        [JsonPropertyName("minute")]
        public string Minute { get; set; } = string.Empty;

        [JsonPropertyName("penalty")]
        public bool Penalty { get; set; }

        [JsonPropertyName("owngoal")]
        public bool OwnGoal { get; set; }
    }
}
