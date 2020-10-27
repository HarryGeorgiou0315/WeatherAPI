using Moq;
using NUnit.Framework;
using WeatherApi.Services;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Moq.Protected;
using System.Threading;

namespace WeatherApiTests.UnitTests.Services
{
    [TestFixture]
    public class WeatherInfoServiceTests
    {
        private Mock<HttpMessageHandler> _messageHandler;
        private WeatherInfoService _classUnderTest;
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            _messageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            _httpClient = new HttpClient(_messageHandler.Object)
            {
                BaseAddress = new Uri("http://test.com"),
            };
            _classUnderTest = new WeatherInfoService(_httpClient);
        }

        private void Setup_Http_MessageHander_Response(Mock<HttpMessageHandler> mockMessageHandler, HttpStatusCode httpStatusCode, StringContent content)
        {
            var stubbedResponse = new HttpResponseMessage
            {
                StatusCode = httpStatusCode,
                Content = content
            };

            mockMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                    )
                .ReturnsAsync(stubbedResponse)
                .Verifiable();
        }


        [Test]
        public void Should_Throw_Exception_If_Api_Key_Is_Not_Valid()
        {
            Environment.SetEnvironmentVariable("API_KEY", null);
            Setup_Http_MessageHander_Response(_messageHandler, HttpStatusCode.Unauthorized,null);

            Assert.Throws<HttpRequestException>(() => _classUnderTest.RetrieveWeatherInfo(TestResources.ModelSetups._requestBoundaryC));
        }

        [Test]
        public void Should_Return_Result_With_Expected_Weather_Info_If_Response_Success()
        {
            var expectedResult = TestResources.ModelSetups._weatherInfoModel;
            Environment.SetEnvironmentVariable("API_KEY", It.IsAny<string>());
            Setup_Http_MessageHander_Response(_messageHandler, HttpStatusCode.OK,
                new StringContent(JsonConvert.SerializeObject
                            (TestResources.ModelSetups._weatherInfoModel)));

            var result = _classUnderTest.RetrieveWeatherInfo(TestResources.ModelSetups._requestBoundaryC);

            Assert.AreEqual(expectedResult.Location.Country, result.Location.Country);
            Assert.AreEqual(expectedResult.Location.Lat, result.Location.Lat);
            Assert.AreEqual(expectedResult.Location.LocalTime.Date, result.Location.LocalTime.Date);
            Assert.AreEqual(expectedResult.Location.LocalTimeEpoch, result.Location.LocalTimeEpoch);
            Assert.AreEqual(expectedResult.Location.Lon, result.Location.Lon);
            Assert.AreEqual(expectedResult.Location.Name, result.Location.Name);
            Assert.AreEqual(expectedResult.Location.Region, result.Location.Region);
            Assert.AreEqual(expectedResult.Location.TzId, result.Location.TzId);
            Assert.AreEqual(expectedResult.Tempurature.TempCelsius, result.Tempurature.TempCelsius);
            Assert.AreEqual(expectedResult.Tempurature.TempFahrenheit, result.Tempurature.TempFahrenheit);
            Assert.AreEqual(expectedResult.Tempurature.WindDir, result.Tempurature.WindDir);
            Assert.AreEqual(expectedResult.Tempurature.WindKph, result.Tempurature.WindKph);
            Assert.AreEqual(expectedResult.Tempurature.WindMph, result.Tempurature.WindMph);
        }

        [Test]
        public void Should_Return_Result_With_Expected_Astronomy_Info_If_Response_Success()
        {
            var expectedResult = TestResources.ModelSetups._astronomyInfoModel.AstronomyInfoDetail.AstronomyInfoModel;
            Environment.SetEnvironmentVariable("API_KEY", It.IsAny<string>());
            Setup_Http_MessageHander_Response(_messageHandler, HttpStatusCode.OK,
                new StringContent(JsonConvert.SerializeObject
                            (TestResources.ModelSetups._astronomyInfoModel)));

            var result = _classUnderTest.RetrieveWeatherInfoAstronomy(TestResources.ModelSetups._requestBoundaryC);
            var resultAstronomyDetail = result.AstronomyInfoDetail.AstronomyInfoModel;
            Assert.AreEqual(expectedResult.MoonIllumination, resultAstronomyDetail.MoonIllumination);
            Assert.AreEqual(expectedResult.MoonPhase, resultAstronomyDetail.MoonPhase);
            Assert.AreEqual(expectedResult.Moonrise, resultAstronomyDetail.Moonrise);
            Assert.AreEqual(expectedResult.Moonset, resultAstronomyDetail.Moonset);
            Assert.AreEqual(expectedResult.Sunrise, resultAstronomyDetail.Sunrise);
            Assert.AreEqual(expectedResult.Sunset, resultAstronomyDetail.Sunset);
        }
        

        [Test]
        public void Should_Throw_Exception_If_BadRequest()
        {
            Environment.SetEnvironmentVariable("API_KEY", It.IsAny<string>());
            Setup_Http_MessageHander_Response(_messageHandler, HttpStatusCode.BadRequest,null);

            Assert.Throws<HttpRequestException>(() => _classUnderTest.RetrieveWeatherInfo(TestResources.ModelSetups._requestBoundaryC));
        }
    }
}
