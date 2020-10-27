using System.Net.Http;
using WeatherApi.Boundaries;
using WeatherApi.Interfaces;
using WeatherApi.Models;
using System;
using Newtonsoft.Json;

namespace WeatherApi.Services
{
    public class WeatherInfoService : IWeatherInfoService
    {
        //Used for communication with data source API.

        private readonly HttpClient _httpClient;

        public WeatherInfoService(HttpClient client)
        {
            _httpClient = client;
        }

        public WeatherInfoModel RetrieveWeatherInfo(RequestBoundary request)
        { 
            string apiKey = Environment.GetEnvironmentVariable("API_KEY");
            try
            {
                var response = _httpClient.GetAsync(
                            $"current.json?key={apiKey}&q={request.City}").Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(
                            $"Request failed with status code {response.StatusCode}");
                }
                var result = JsonConvert.DeserializeObject<WeatherInfoModel>
                                         (response.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch(HttpRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public AstronomyInfo RetrieveWeatherInfoAstronomy(RequestBoundary request)
        {
            string apiKey = Environment.GetEnvironmentVariable("API_KEY");
            try
            {
                var response = _httpClient.GetAsync(
                            $"astronomy.json?key={apiKey}&q={request.City}" +
                            $"&dt={DateTime.Now.Date}").Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(
                            $"Request failed with status code {response.StatusCode}");

                }
                var result = JsonConvert.DeserializeObject<AstronomyInfo>
                                         (response.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

