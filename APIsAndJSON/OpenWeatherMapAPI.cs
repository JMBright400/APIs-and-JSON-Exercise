using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON   
{
    public class OpenWeatherMapAPI
    {
        public static void GetTemp()
        {
            var apiKeyObj = File.ReadAllText("appsettings.json");

            var apiKey =JObject.Parse(apiKeyObj).GetValue("apiKey".ToString());

            Console.Write("Enter ZIP Code: ");

            var zip = Console.ReadLine();

            var url = $"http://api.openweathermap.org/data/2.5/weather?zip={zip}&appid={apiKey}&units=imperial";

            var client = new HttpClient();

            var jtext = client.GetStringAsync(url).Result;

            var weatherObj = JObject.Parse(jtext);

            Console.WriteLine($"Temp: {weatherObj["main"]["temp"]}");
        }
    }
}



