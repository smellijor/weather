using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherExam
{
    public class WeatherstackUtil : IWeatherstack
    {
        public Weatherstack GetResponse(string accessKey, string zipcode)
        {
            var url = $"http://api.weatherstack.com/current?access_key={accessKey}&query={zipcode}";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response;
            using (HttpClient httpClient = new HttpClient())
            {
                response = httpClient.GetAsync($"http://api.weatherstack.com/current?access_key={accessKey}&query={zipcode}").Result;
            }

            var deserialized = JsonConvert.DeserializeObject<Weatherstack>(response.Content.ReadAsStringAsync().Result);

            return deserialized;
        }
    }

    public class WeatherstackServices
    {
        IWeatherstack _weatherstack;
        public WeatherstackServices(IWeatherstack weatherstack)
        {
            this._weatherstack = weatherstack;
        }

        public Weatherstack GetResponse(string accessKey, string zipcode)
        {
            return this._weatherstack.GetResponse(accessKey, zipcode);
        }
    }

    public interface IWeatherstack
    {
        Weatherstack GetResponse(string accessKey, string zipcode);
    }
}
