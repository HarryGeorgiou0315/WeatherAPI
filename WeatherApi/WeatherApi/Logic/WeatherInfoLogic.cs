using System;
using WeatherApi.Boundaries;
using WeatherApi.Factory;
using WeatherApi.Interfaces;

namespace WeatherApi.Logic
{
    public class WeatherInfoLogic : IWeatherInfoLogic
    {
        // this is the class which will carry out any pre / post 
           // processing and invoke the service class. 
        private IWeatherInfoService _weatherInfoService;

        public WeatherInfoLogic(IWeatherInfoService weatherInfoService)
        {
            _weatherInfoService = weatherInfoService;
        }

        public ResponseBoundary GetWeatherInfoResponse(RequestBoundary requestBoundary)
        {
            try
            {
                var resultWeatherInfo = _weatherInfoService.RetrieveWeatherInfo(requestBoundary);
                var resultWeatherInfoAstronomy = _weatherInfoService.
                                                 RetrieveWeatherInfoAstronomy(requestBoundary);

                return resultWeatherInfo.ToResponseModel(
                               resultWeatherInfoAstronomy.AstronomyInfoDetail.AstronomyInfoModel,
                               requestBoundary);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
