using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BolaoNet.Infra.External.API.TheSportsDb.Dto;

namespace BolaoNet.Infra.External.API.TheSportsDb.Client
{
    public class TheSportsDbClient
    {
        private readonly string _key;
        private readonly HttpClient _http;

        public TheSportsDbClient(
            string url = "https://www.thesportsdb.com/",
            string key = "123")
        {
            _key = key;

            _http = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            _http.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        #region Core HTTP

        private async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _http.GetAsync(endpoint);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }

        #endregion

        #region League

        public async Task<LeagueResponseDto> GetLeagueAsync(long leagueId)
        {
            return await GetAsync<LeagueResponseDto>(
                $"api/v1/json/{_key}/lookupleague.php?id={leagueId}");
        }

        public async Task<TeamResponseDto> GetLeagueTeamsAsync(long leagueId)
        {
            return await GetAsync<TeamResponseDto>(
                $"api/v1/json/{_key}/lookup_all_teams.php?id={leagueId}");
        }

        #endregion

        #region Season / Schedule (Copa)

        public async Task<EventsResponseDto> GetScheduleAsync(long leagueId, string season)
        {
            return await GetAsync<EventsResponseDto>(
                $"api/v2/json/{_key}/schedule/league/{leagueId}/{season}");
        }

        public async Task<EventsResponseDto> GetSeasonMatchesAsync(long leagueId, string season)
        {
            return await GetAsync<EventsResponseDto>(
                $"api/v1/json/{_key}/eventsseason.php?id={leagueId}&s={season}");
        }

        #endregion

        #region Events by date

        public async Task<EventsResponseDto> GetEventsByDateAsync(DateTime date)
        {
            return await GetAsync<EventsResponseDto>(
                $"api/v1/json/{_key}/eventsday.php?d={date:yyyy-MM-dd}&s=Soccer");
        }

        #endregion

        #region Live / History

        public async Task<EventsResponseDto> GetLiveScoresAsync()
        {
            return await GetAsync<EventsResponseDto>(
                $"api/v1/json/{_key}/livescore.php?s=Soccer");
        }

        public async Task<EventsResponseDto> GetNextLeagueEventsAsync(long leagueId)
        {
            return await GetAsync<EventsResponseDto>(
                $"api/v1/json/{_key}/eventsnextleague.php?id={leagueId}");
        }

        public async Task<EventsResponseDto> GetPastLeagueEventsAsync(long leagueId)
        {
            return await GetAsync<EventsResponseDto>(
                $"api/v1/json/{_key}/eventspastleague.php?id={leagueId}");
        }

        #endregion

        #region Match

        public async Task<EventDetailResponseDto> GetMatchDetailsAsync(string eventId)
        {
            return await GetAsync<EventDetailResponseDto>(
                $"api/v1/json/{_key}/lookupevent.php?id={eventId}");
        }

        public async Task<EventDetailResponseDto> GetMatchDetailsBatchAsync(string eventIds)
        {
            return await GetAsync<EventDetailResponseDto>(
                $"api/v1/json/{_key}/lookupevent.php?id={eventIds}");
        }

        public async Task<EventTimelineResponse> GetMatchTimelineAsync(string eventId)
        {
            var url = $"api/v1/json/{_key}/lookuptimeline.php?id={eventId}";

            var response = await _http.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<EventTimelineResponse>(json);
        }

        public async Task<EventStatisticsResponse> GetMatchStatisticsAsync(string eventId)
        {
            var url = $"api/v1/json/{_key}/lookupeventstats.php?id={eventId}";

            var response = await _http.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<EventStatisticsResponse>(json);
        }

        #endregion

        #region Team

        public async Task<TeamResponseDto> GetTeamAsync(string teamId)
        {
            return await GetAsync<TeamResponseDto>(
                $"api/v1/json/{_key}/lookupteam.php?id={teamId}");
        }

        #endregion
    }
}