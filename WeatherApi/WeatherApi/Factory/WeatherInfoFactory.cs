using WeatherApi.Boundaries;
using WeatherApi.Models;

namespace WeatherApi.Factory
{
    public static class WeatherInfoFactory
    {
        public static ResponseBoundary ToResponseModel (this WeatherInfoModel weatherInfoModel, AstronomyInfoModel astronomyInfoModel, RequestBoundary request)
        {
            return new ResponseBoundary
            {
                City = weatherInfoModel.Location.Name,
                Country = weatherInfoModel.Location.Country,
                LocalTime = weatherInfoModel.Location.LocalTime,
                Region = weatherInfoModel.Location.Region,
                Tempurature = !string.IsNullOrEmpty(request.TempMeasurement) && request.TempMeasurement.ToUpper() == "F" ? 
                              weatherInfoModel.Tempurature.TempFahrenheit : weatherInfoModel.Tempurature.TempCelsius,
                Sunrise = !string.IsNullOrEmpty(astronomyInfoModel.Sunrise) ? astronomyInfoModel.Sunrise : string.Empty,
                Sunset = !string.IsNullOrEmpty(astronomyInfoModel.Sunset) ? astronomyInfoModel.Sunset : string.Empty
            };
        }
    }
}
