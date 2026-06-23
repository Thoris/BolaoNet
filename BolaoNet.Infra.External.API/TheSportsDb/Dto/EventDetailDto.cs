namespace BolaoNet.Infra.External.API.TheSportsDb.Dto
{
    using Newtonsoft.Json;

    namespace BolaoNet.Infra.External.API.TheSportsDb.Dto
    {
        public class EventDetailDto : EventDto
        {
            [JsonProperty("strProgress")]
            public string Progress { get; set; }

            [JsonProperty("intRound")]
            public int? Round { get; set; }

            [JsonProperty("strPostponed")]
            public string Postponed { get; set; }

            [JsonProperty("strLocked")]
            public string Locked { get; set; }

            [JsonProperty("strTimestamp")]
            public string Timestamp { get; set; }

            [JsonProperty("strHomeGoalDetails")]
            public string HomeGoalDetails { get; set; }

            [JsonProperty("strAwayGoalDetails")]
            public string AwayGoalDetails { get; set; }

            [JsonProperty("strHomeYellowCards")]
            public string HomeYellowCards { get; set; }

            [JsonProperty("strAwayYellowCards")]
            public string AwayYellowCards { get; set; }

            [JsonProperty("strHomeRedCards")]
            public string HomeRedCards { get; set; }

            [JsonProperty("strAwayRedCards")]
            public string AwayRedCards { get; set; }

            [JsonProperty("intHomeShots")]
            public int? HomeShots { get; set; }

            [JsonProperty("intAwayShots")]
            public int? AwayShots { get; set; }

            [JsonProperty("strTVStation")]
            public string TvStation { get; set; }

            [JsonProperty("strResult")]
            public string Result { get; set; }
        }
    }
}
