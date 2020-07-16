using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace BlazorAppDemo2.Servicio
{
    public interface IWeatherService
    {
        Task<Weather> GetProductAsync();
    }

    public class WeatherService : IWeatherService
    {

        public WeatherService()
        {
            this.client = httpClient;
            client.BaseAddress = new Uri(@"http://localhost:44354/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private HttpClient client;


        public async Task<Weather> GetProductAsync()
        {
            Weather product = null;
            HttpResponseMessage response = await client.GetAsync("WeatherForecast");
            if (response.IsSuccessStatusCode)
            {
                var product1 = await response.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<Weather>(product1);
            }
            return product;
        }
    }
}
