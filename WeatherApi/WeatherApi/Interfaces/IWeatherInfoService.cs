using System.Threading.Tasks;
using WeatherApi.Boundaries;
using WeatherApi.Models;

namespace WeatherApi.Interfaces
{
    public interface IWeatherInfoService
    {
        WeatherInfoModel RetrieveWeatherInfo(RequestBoundary request);
        AstronomyInfo RetrieveWeatherInfoAstronomy(RequestBoundary request);
    }
}
