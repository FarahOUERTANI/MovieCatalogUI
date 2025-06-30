using MovieCatalogUI.Models;
using System.Net.Http;
using System.Text.Json;

namespace MovieCatalogUI.Services
{
    public class MovieService
    {
        private readonly HttpClient _httpClient;

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7240/"); 
        }

        public async Task<List<Movie>> GetMoviesAsync()
        {
            var response = await _httpClient.GetAsync("api/movies");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var movies = JsonSerializer.Deserialize<List<Movie>>(content, options);
                return movies ?? new List<Movie>();
            }

            return new List<Movie>();
        }
    }
}
