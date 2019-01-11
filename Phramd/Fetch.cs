using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Phramd
{
    public class Fetch
    {
        public string cs = "Server=(localdb)\\mssqllocaldb;Database=PhramdDB;Trusted_Connection=true";
        public HttpClient client = new HttpClient();
        public string Data { get; set; }
        public string Bios { get; set; }
        public string Images { get; set; }
        public string Search { get; set; }
        public string Videos { get; set; }
        public string Details { get; set; }
        public string Credits { get; set; }
        public string Temp { get; set; }

        public async Task GrabWeather()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicationException/json"));

            HttpResponseMessage response = await client.GetAsync("https://api.openweathermap.org/data/2.5/weather?q=London,Ca&units=metric&APPID=2c44fa8568a1b65b1865d69f48558362");

            if (response.IsSuccessStatusCode)
            {
                Data = await response.Content.ReadAsStringAsync();
            }
            else
            {
                Data = null; //this is so that if the search field is empty it does not show what was last searched
            }
        }
    }
}