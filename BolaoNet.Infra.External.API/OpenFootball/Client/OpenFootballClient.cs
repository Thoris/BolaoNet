
using BolaoNet.Infra.External.API.OpenFootball.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BolaoNet.Infra.External.API.OpenFootball.Client
{
    public sealed class OpenFootballClient 
    {
        private readonly HttpClient _http;

        public OpenFootballClient(
            HttpClient httpClient)
        {
            _http = httpClient;
        }

        public OpenFootballClient(string url = "https://raw.githubusercontent.com/openfootball/worldcup.json/master/")
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri(url),                
            };
            _http.Timeout = TimeSpan.FromSeconds(10);

            _http.DefaultRequestHeaders.Add(
                "Accept",
                "application/json");
             
        }

        private async Task<T> GetAsync<T>(
            string endpoint,
            CancellationToken cancellationToken = default)
        {
            //var response = await _http.GetAsync(
            //    endpoint,
            //    cancellationToken);

            //response.EnsureSuccessStatusCode();

            // var stream =
            //    await response.Content.ReadAsStreamAsync();

            //return await JsonSerializer.DeserializeAsync<T>(
            //    stream,
            //    JsonSerializerOptions.Default,
            //    cancellationToken);


            try
            {
                var response = await _http.GetAsync(
                    endpoint,
                    cancellationToken);

                var content = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                return JsonSerializer.Deserialize<T>(
                    content,
                    JsonSerializerOptions.Default);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception(
                    $"Timeout ao acessar '{_http.BaseAddress}{endpoint}'.",
                    ex);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(
                    $"Erro HTTP ao acessar '{_http.BaseAddress}{endpoint}'.",
                    ex);
            }
            catch (JsonException ex)
            {
                throw new Exception(
                    $"Erro ao desserializar a resposta de '{_http.BaseAddress}{endpoint}'.",
                    ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<WorldCupDto> GetWorldCupAsync(
            int year,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<WorldCupDto>(
                       $"{year}/worldcup.json",
                       cancellationToken)
                   ?? throw new Exception($"Copa {year} não encontrada.");
        }

        public async Task<IReadOnlyCollection<MatchDto>> GetSeasonMatchesAsync(
            int year,
            CancellationToken cancellationToken = default)
        {
            var result = await GetWorldCupAsync(
                year,
                cancellationToken);

            return result.Matches;
        }


        public async Task<IReadOnlyCollection<MatchDto>> GetMatchesByDateAsync(
            int year,
            DateTime date,
            CancellationToken cancellationToken = default)
        {
            var matches = await GetSeasonMatchesAsync(
                year,
                cancellationToken);

            return matches
                .Where(x =>
                {
                    if (string.IsNullOrWhiteSpace(x.Date))
                        return false;

                    return DateTime.TryParseExact(
                               x.Date,
                               "yyyy-MM-dd",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None,
                               out var matchDate)
                           && matchDate.Date == date.Date;
                })
                .ToList();
        }

        public async Task<MatchDto> GetMatchAsync(
            int year,
            DateTime date,
            string homeTeam,
            string awayTeam,
            CancellationToken cancellationToken = default)
        {
            var matches = await GetMatchesByDateAsync(
                year,
                date,
                cancellationToken);

            return matches.FirstOrDefault(x =>
                string.Equals(
                    x.Team1,
                    homeTeam,
                    StringComparison.OrdinalIgnoreCase)
                &&
                string.Equals(
                    x.Team2,
                    awayTeam,
                    StringComparison.OrdinalIgnoreCase));
        }
    }
}
