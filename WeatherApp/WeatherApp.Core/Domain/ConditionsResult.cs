using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core
{
    public class ConditionsResult
    {
        public string weather { get; set; }
        public float temp_c { get; set; }
        public float temp_f { get; set; }
        public string icon { get; set; }
        public string icon_url { get; set; }
        public string display_location { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string wind_string { get; set; }
        public string feelslike_string { get; set; }
        public string wind_dir { get; set; }
        public float elevation { get; set; }
        public string observation_time { get; set; }
        public string relative_humidity { get; set; }
        public float visibility_mi { get; set; }
        public float uv { get; set; }
        public float precip_today_in { get; set; }
        
    }
}
