using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ResponseModel
{
    public class WeatherForecastResponseModel
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("temperatureC")]
        public int TemperatureC { get; set; }
        [JsonProperty("temperatureF")]
        public int TemperatureF { set; get; }
        [JsonProperty("summary")]
        public string Summary { get; set; }
    }
}
