using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_UnderTheHood.Models;

namespace WebApp_UnderTheHood.Pages
{
    [Authorize(Policy = "HRManager")]
    public class HRManagerModel : PageModel
    {
        private readonly HttpClient _httpClient;

        [BindProperty]
        public List<WeatherForecast> WeatherForecastItems { get; set; }

        public HRManagerModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("WebAPI");
        }

        public async Task OnGetAsync()
        {
            WeatherForecastItems = await _httpClient.GetFromJsonAsync<List<WeatherForecast>>("/WeatherForecast");
        }
    }
}
