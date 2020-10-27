using Newtonsoft.Json;

namespace WeatherApi.Models
{
    public class WeatherInfoModel
    {
        [JsonProperty("location")]
        public LocationModel Location { get; set; }
        [JsonProperty("current")]
        public TempuratureModel Tempurature { get; set; }
    }
}
