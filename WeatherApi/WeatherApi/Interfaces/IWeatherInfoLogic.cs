using WeatherApi.Boundaries;

namespace WeatherApi.Interfaces
{
    public interface IWeatherInfoLogic
    {
        ResponseBoundary GetWeatherInfoResponse(RequestBoundary request);
    }
}
