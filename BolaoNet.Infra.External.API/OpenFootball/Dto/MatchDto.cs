using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;

namespace BolaoNet.Infra.External.API.OpenFootball.Dto
{
    public sealed class MatchDto
    {
        [JsonPropertyName("round")]
        public string Round { get; set; } = string.Empty;

        [JsonPropertyName("group")]
        public string Group { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("team1")]
        public string Team1 { get; set; } = string.Empty;

        [JsonPropertyName("team2")]
        public string Team2 { get; set; } = string.Empty;

        [JsonPropertyName("ground")]
        public string Ground { get; set; }

        [JsonPropertyName("score")]
        public ScoreDto Score { get; set; }

        [JsonPropertyName("goals1")]
        public List<GoalDto> Goals1 { get; set; }

        [JsonPropertyName("goals2")]
        public List<GoalDto> Goals2 { get; set; }
    }
}
