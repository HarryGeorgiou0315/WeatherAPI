using Newtonsoft.Json;

namespace WeatherApi.Models
{
    public class TempuratureModel
    {
        [JsonProperty("temp_c")]
        public double TempCelsius { get; set; }
        [JsonProperty("temp_f")]
        public double TempFahrenheit { get; set; }
        [JsonProperty("wind_mph")]
        public double WindMph { get; set; }
        [JsonProperty("wind_kph")]
        public double WindKph { get; set; }
        [JsonProperty("wind_dir")]
        public string WindDir { get; set; }
    }
}
