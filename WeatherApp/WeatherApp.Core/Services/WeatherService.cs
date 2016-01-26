using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherApp.Core
{
    public class WeatherService
    {
        private static string apiKey = "d9337551a5d14d80";

        public static ConditionsResult GetWeatherFor(string zipCode)
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString($"http://api.wunderground.com/api/{apiKey}/conditions/q/CA/{zipCode}.json");
                var o = JObject.Parse(json);

                var result = new ConditionsResult();

                result.temp_c = (float)o["current_observation"]["temp_c"];
                result.temp_f = (float)o["current_observation"]["temp_f"];
                result.weather = o["current_observation"]["weather"].ToString();
                result.display_location = o["current_observation"]["display_location"]["full"].ToString();
                result.latitude = (float)o["current_observation"]["display_location"]["latitude"];
                result.longitude = (float)o["current_observation"]["display_location"]["longitude"];
                result.wind_string = o["current_observation"]["wind_string"].ToString();
                result.wind_dir = o["current_observation"]["wind_dir"].ToString();
                result.feelslike_string = o["current_observation"]["feelslike_string"].ToString();
                result.elevation = (float)o["current_observation"]["display_location"]["elevation"];
                result.observation_time = o["current_observation"]["observation_time"].ToString();
                result.relative_humidity = o["current_observation"]["relative_humidity"].ToString();
                result.visibility_mi = (float)o["current_observation"]["visibility_mi"];
                result.uv = (float)o["current_observation"]["UV"];
                result.precip_today_in = (float)o["current_observation"]["precip_today_in"];
                result.icon_url = o["current_observation"]["icon_url"].ToString();
                result.icon = o["current_observation"]["icon"].ToString();

                //var result = JsonConvert.DeserializeObject<ConditionsResult>(json);

                return result;
            }
        }
    }
}
