using Newtonsoft.Json;

namespace WeatherApi.Models
{
    public class AstronomyInfo
    {
        [JsonProperty("astronomy")]
        public AstronomyInfoDetail AstronomyInfoDetail { get; set; }
    }

    public class AstronomyInfoDetail
    {
        [JsonProperty("astro")]
        public AstronomyInfoModel AstronomyInfoModel { get; set; }
    }
    
    public class AstronomyInfoModel
    {
        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }
        [JsonProperty("sunset")]
        public string Sunset { get; set; }
        [JsonProperty("moonrise")]
        public string Moonrise { get; set; }
        [JsonProperty("moonset")]
        public string Moonset { get; set; }
        [JsonProperty("moon_phase")]
        public string MoonPhase { get; set; }
        [JsonProperty("moon_illumination")]
        public string MoonIllumination { get; set; }
    }
}
