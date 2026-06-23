using Newtonsoft.Json;

namespace BolaoNet.Infra.External.API.TheSportsDb.Dto
{
    public class EventStatisticDto
    {
        [JsonProperty("strStat")]
        public string StatisticName { get; set; }

        [JsonProperty("intHome")]
        public int HomeValue { get; set; }

        [JsonProperty("intAway")]
        public int AwayValue { get; set; }
    }
}
