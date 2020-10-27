using System;
using WeatherApi.Boundaries;
using WeatherApi.Models;

namespace WeatherApiTests.TestResources
{
    public static class ModelSetups
    {
        public static RequestBoundary _requestBoundaryC = new RequestBoundary
        {
            City = "london",
            TempMeasurement = "C"
        };

        public static RequestBoundary _requestBoundaryF = new RequestBoundary
        {
            City = "london",
            TempMeasurement = "F"
        };

        public static RequestBoundary _requestBoundaryNoTempMeasurement = new RequestBoundary
        {
            City = "london",
            TempMeasurement = ""
        };

        public static ResponseBoundary _responseBoundary = new ResponseBoundary
        {
            City = "London",
            Region = "City of London, Greater London",
            Country = "United Kingdom",
            LocalTime = DateTime.Parse("2020-04-05 21:54"),
            Tempurature = 15.0,
            Sunrise = "07:36 AM",
            Sunset = "05:54 PM"
        };

        public static AstronomyInfo _astronomyInfoModel = new AstronomyInfo
        {
            AstronomyInfoDetail = new AstronomyInfoDetail
            {
                AstronomyInfoModel = new AstronomyInfoModel
                {
                    Sunset = "05:54 PM",
                    Sunrise = "07:36 AM",
                    MoonIllumination = "27",
                    MoonPhase = "Waxing Crescent",
                    Moonrise = "01:35 PM",
                    Moonset = "09:09 PM"
                }

            }

        };

        public static WeatherInfoModel _weatherInfoModel = new WeatherInfoModel
        {
            Location = new LocationModel
            {
                Country = "United Kingdom",
                Lat = 51.52,
                LocalTime = DateTime.Parse("2020-04-05 21:54"),
                LocalTimeEpoch = 1603296728,
                Lon = -0.11,
                Name = "London",
                Region = "City of London, Greater London",
                TzId = "Europe/London"
            },
            Tempurature = new TempuratureModel
            {
                TempCelsius = 15.0,
                TempFahrenheit = 59.0,
                WindDir = "W",
                WindKph = 24.1,
                WindMph = 15.0
            }
        };

    }
}
