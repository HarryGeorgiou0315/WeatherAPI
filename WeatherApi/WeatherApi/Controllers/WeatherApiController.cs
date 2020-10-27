using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using WeatherApi.Boundaries;
using WeatherApi.Interfaces;

namespace WeatherApi.Controllers
{
    [Route("api/weather")]
    [ApiController]
    public class WeatherApiController : ControllerBase
    {
        // Handles client requests and commication with the Logic layer 
              //and the response back to client

        private IWeatherInfoLogic _weatherInfoLogic;

        public WeatherApiController (IWeatherInfoLogic weatherInfoLogic)
        {
            _weatherInfoLogic = weatherInfoLogic;
        }

        // GET api/weather/london
        [ProducesResponseType(typeof(ResponseBoundary), StatusCodes.Status200OK)]
        [HttpGet("{city}")]
        public ActionResult GetWeatherInfoLogic([FromRoute]RequestBoundary request)
        {
            try
            {
                return Ok(_weatherInfoLogic.GetWeatherInfoResponse(request));
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(400, $"The request to retrieve information has failed with - {ex.Message} - {ex.InnerException}");
            }
            catch(Exception ex)
            { //catch any other exceptions that may have occured during execution
                return StatusCode(500, $"An error has occured while executing the request - " +
                                                $"{ex.Message} - {ex.InnerException}");
            }
        }
    }
}
