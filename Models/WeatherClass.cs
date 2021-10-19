//using ImaggaAPISample;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class WeatherClass
    {
        public Main CheckWeather(string city)
        {
            Main result = null;
            string apiKey = "efe83d986e7db538087a0a3355daeff8";
            // string apiSecret = "4ac5da868fa47b900e6f6103483ef380";
            //string imageUrl = "https://idsb.tmgrup.com.tr/ly/uploads/images/2020/07/05/44510.jpg";

            //string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

            var client = new RestClient("https://api.openweathermap.org/data/2.5/weather");
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddParameter("q", city);
            request.AddParameter("appid", apiKey);
            request.AddParameter("units", "metric");
            IRestResponse response = client.Execute(request);
            result = ConvertToDictionary(response.Content);
            //Console.Write(response.Content);
            // Console.ReadLine();
            return result;
        }
        public Main ConvertToDictionary(string response)
        {
           // List<string> result = new List<string>();
            Root TheTags = JsonConvert.DeserializeObject<Root>(response);

            return TheTags.main;
        }
    }
}
