using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Net.Http;
using WeatherApi.Boundaries;
using WeatherApi.Controllers;
using WeatherApi.Interfaces;

namespace WeatherApiTests.UnitTests.Controllers
{
    [TestFixture]
    public class WeatherApiControllerTests
    {
        private Mock<IWeatherInfoLogic> _weatherInfoLogicMoq;
        private WeatherApiController _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _weatherInfoLogicMoq = new Mock<IWeatherInfoLogic>();
            _classUnderTest = new WeatherApiController(_weatherInfoLogicMoq.Object);
        }

        [Test]
        public void Should_Return_InternalServer_Error_If_Response_Not_Success()
        {
            _weatherInfoLogicMoq.Setup(x => x.GetWeatherInfoResponse(
                                       TestResources.ModelSetups._requestBoundaryC))
                                       .Throws(It.IsAny<Exception>());

            var result = _classUnderTest.GetWeatherInfoLogic(
                         TestResources.ModelSetups._requestBoundaryC)     
                         as ObjectResult;

            Assert.AreEqual(result.StatusCode, 500);
        }


        [Test]
        public void Should_Return_BadRequest_Error_If_Response_Not_Success()
        {
            _weatherInfoLogicMoq.Setup(x => x.GetWeatherInfoResponse(
                                       TestResources.ModelSetups._requestBoundaryC))
                                       .Throws(new HttpRequestException());

            var result = _classUnderTest.GetWeatherInfoLogic(
                          TestResources.ModelSetups._requestBoundaryC)             
                          as ObjectResult;

            Assert.AreEqual(result.StatusCode, 400);
        }

        [Test]
        public void Should_Return_Ok_If_Response_Success()
        {
            _weatherInfoLogicMoq.Setup(x => x.GetWeatherInfoResponse(
                                      TestResources.ModelSetups._requestBoundaryC))
                                      .Returns(It.IsAny<ResponseBoundary>());

            var result = _classUnderTest.GetWeatherInfoLogic(
                         TestResources.ModelSetups._requestBoundaryC)                
                         as ObjectResult;

            Assert.AreEqual(result.StatusCode, 200);
        }

        [Test]
        public void Should_Return_Result_Of_Type_ReponseBoundary_If_Request_Success()
        {
            _weatherInfoLogicMoq.Setup(x => x.GetWeatherInfoResponse(
                                      TestResources.ModelSetups._requestBoundaryC))
                                     .Returns(TestResources.ModelSetups._responseBoundary);

            var response = _classUnderTest.GetWeatherInfoLogic(
                           TestResources.ModelSetups._requestBoundaryC)
                           as OkObjectResult;

            Assert.IsInstanceOf<ResponseBoundary>(response.Value); 
        }

        [Test]
        public void Should_Return_Expected_Result_If_Request_Success()
        {
            var expectedResult = TestResources.ModelSetups._responseBoundary;
            _weatherInfoLogicMoq.Setup(x => x.GetWeatherInfoResponse(
                                      TestResources.ModelSetups._requestBoundaryC))
                                     .Returns(TestResources.ModelSetups._responseBoundary);

            var response = _classUnderTest.GetWeatherInfoLogic(
                           TestResources.ModelSetups._requestBoundaryC)     
                           as OkObjectResult;

            var result = response.Value as ResponseBoundary;

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
