using System;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using WeatherApi;
using WeatherApi.Boundaries;
using WeatherApiTests.IntegrationTests.Helpers;

namespace WeatherApiTests.IntegrationTests
{
    [TestFixture]
    public class WeatherApiEndToEndTests : IntegrationTestsSetup<Startup>
    {
        [Test]
        public void Should_Return_Success()
        {
            HelperMethods.SetupWeatherApiMockApiWithRequest(
                          _mockWeatherApi, HttpStatusCode.OK);
            HelperMethods.SetupAstronomyApiMockApiWithRequest(
                          _mockWeatherApi, HttpStatusCode.OK);

            var url = new Uri($"/api/weather/london", UriKind.Relative);
            var response = _httpClient.GetAsync(url).Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public void Should_Return_Bad_Request_If_Request_Exception_Thrown_From_Weather_Api()
        {
            HelperMethods.SetupWeatherApiMockApiWithRequest(
                         _mockWeatherApi, HttpStatusCode.BadRequest);
            HelperMethods.SetupAstronomyApiMockApiWithRequest(
                         _mockWeatherApi, HttpStatusCode.OK);

            var url = new Uri($"/api/weather/london", UriKind.Relative);
            var response = _httpClient.GetAsync(url).Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }

        [Test]
        public void Should_Return_Bad_Request_If_Request_Exception_Thrown_From_Astronomy_Api()
        {
            HelperMethods.SetupWeatherApiMockApiWithRequest(
                          _mockWeatherApi, HttpStatusCode.OK);
            HelperMethods.SetupAstronomyApiMockApiWithRequest(
                           _mockWeatherApi, HttpStatusCode.BadRequest);

            var url = new Uri($"/api/weather/london", UriKind.Relative);
            var response = _httpClient.GetAsync(url).Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }

        [Test]
        public void Should_Return_Expected_Result()
        {
            var expectedResult = TestResources.ModelSetups._responseBoundary;
            HelperMethods.SetupWeatherApiMockApiWithRequest(
                          _mockWeatherApi, HttpStatusCode.OK);
            HelperMethods.SetupAstronomyApiMockApiWithRequest(
                          _mockWeatherApi, HttpStatusCode.OK);

            var url = new Uri($"/api/weather/london", UriKind.Relative);
            var response = _httpClient.GetAsync(url).Result;
            var result = JsonConvert.DeserializeObject<ResponseBoundary>
                                       (response.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(expectedResult.City, result.City);
            Assert.AreEqual(expectedResult.Country, result.Country);
            Assert.AreEqual(expectedResult.LocalTime.Date, result.LocalTime.Date);
            Assert.AreEqual(expectedResult.Region, result.Region);
            Assert.AreEqual(expectedResult.Tempurature, result.Tempurature);
            Assert.AreEqual(expectedResult.Sunrise, result.Sunrise);
            Assert.AreEqual(expectedResult.Sunset, result.Sunset);
        }
    }
}
