using Microsoft.AspNetCore.Mvc;
using ASP_MVC_PROJ.Models;
using Newtonsoft.Json;

namespace ASP_MVC_PROJ.Controllers
{
    public class WeatherController : Controller
    {
        static async Task<List<WeatherDataView>> MakeRequest()
        {
            List<WeatherDataView> weatherInfo = new List<WeatherDataView>();
            string apiUrl = "https://forecast9.p.rapidapi.com/rapidapi/forecast/46.95828/10.87152/hourly/";
            
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "e090d04ee9mshca3f0eda4545bd5p16cff3jsn462f0396386c");
                    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "forecast9.p.rapidapi.com");

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    string responseBody = await response.Content.ReadAsStringAsync();
                    WeatherData weatherEntity = JsonConvert.DeserializeObject<WeatherData>(responseBody);
                        
                    foreach (var item in weatherEntity.Items)
                    {
                        weatherInfo.Add(new WeatherDataView { Date = $"{item.Date}", Temperature = $"{item.Temperature.Avg}" });
                        Console.WriteLine($"{item.Date}" + $"{item.Temperature.Avg}");
                    }
                    return weatherInfo;
                    
                }
                catch (HttpRequestException e)
                {
                    return weatherInfo;
                }
            }
        }

        public async Task<IActionResult> Index()
        {
            List<WeatherDataView> weatherDatas = await MakeRequest();
            return View(weatherDatas);
        }
    }
}
