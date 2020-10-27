using System;

namespace WeatherApi.Boundaries
{
    public class ResponseBoundary
    {
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public DateTime LocalTime { get; set; }
        public double Tempurature { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
    }
}
