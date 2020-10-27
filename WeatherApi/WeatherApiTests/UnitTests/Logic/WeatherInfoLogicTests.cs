using WeatherApi.Logic;
using Moq;
using NUnit.Framework;
using WeatherApi.Interfaces;
using WeatherApi.Boundaries;
using System;

namespace WeatherApiTests.UnitTests.Logic
{
    [TestFixture]
    public class WeatherInfoLogicTests
    {
        private Mock<IWeatherInfoService> _weatherInfoServiceMoq;
        private WeatherInfoLogic _classUnderTest; 

        [SetUp]
        public void Setup()
        {
            _weatherInfoServiceMoq = new Mock<IWeatherInfoService>();
            _classUnderTest = new WeatherInfoLogic(_weatherInfoServiceMoq.Object);
        }

        [Test]
        public void Should_Call_Correct_Methods_Based_On_User_Input()
        {
            var userInput = TestResources.ModelSetups._requestBoundaryC;

            _weatherInfoServiceMoq.Setup(x => x.RetrieveWeatherInfo(userInput))
                                        .Returns(TestResources.ModelSetups._weatherInfoModel);
            _weatherInfoServiceMoq.Setup(x => x.RetrieveWeatherInfoAstronomy(userInput))
                                        .Returns(TestResources.ModelSetups._astronomyInfoModel);

            _classUnderTest.GetWeatherInfoResponse(userInput);

            _weatherInfoServiceMoq.Verify(x => x.RetrieveWeatherInfo(userInput), Times.Once);
        }

        [Test]
        public void Should_Convert_Result_Using_Factory_To_ResponseBoundary_Model()
        {
            var userInput = TestResources.ModelSetups._requestBoundaryC;

            _weatherInfoServiceMoq.Setup(x => x.RetrieveWeatherInfo(userInput))
                                        .Returns(TestResources.ModelSetups._weatherInfoModel);
            _weatherInfoServiceMoq.Setup(x => x.RetrieveWeatherInfoAstronomy(userInput))
                                        .Returns(TestResources.ModelSetups._astronomyInfoModel);

            var result = _classUnderTest.GetWeatherInfoResponse(userInput);

            Assert.IsInstanceOf<ResponseBoundary>(result);
        }

        [Test]
        public void Should_Return_Expected_Response_Based_On_User_Input()
        {
            var expectedResult = TestResources.ModelSetups._responseBoundary;
            var userInput = TestResources.ModelSetups._requestBoundaryC;

            _weatherInfoServiceMoq.Setup(x => x.RetrieveWeatherInfo(userInput))
                                        .Returns(TestResources.ModelSetups._weatherInfoModel);
            _weatherInfoServiceMoq.Setup(x => x.RetrieveWeatherInfoAstronomy(userInput))
                                        .Returns(TestResources.ModelSetups._astronomyInfoModel);

            var result = _classUnderTest.GetWeatherInfoResponse(userInput);

            Assert.AreEqual(expectedResult.City, result.City);
            Assert.AreEqual(expectedResult.Country, result.Country);
            Assert.AreEqual(expectedResult.LocalTime.Date, result.LocalTime.Date);
            Assert.AreEqual(expectedResult.Region, result.Region);
            Assert.AreEqual(expectedResult.Tempurature, result.Tempurature);
            Assert.AreEqual(expectedResult.Sunrise, result.Sunrise);
            Assert.AreEqual(expectedResult.Sunset, result.Sunset);
        }

        [Test]
        public void Should_Throw_Exception_If_Request_Fails_When_Retrieving_Weather_Info()
        {
            var expectedResult = TestResources.ModelSetups._responseBoundary;
            var userInput = TestResources.ModelSetups._requestBoundaryC;

            _weatherInfoServiceMoq.Setup(x => x.RetrieveWeatherInfo(userInput))
                                        .Throws(new Exception());
            _weatherInfoServiceMoq.Setup(x => x.RetrieveWeatherInfoAstronomy(userInput))
                                        .Returns(TestResources.ModelSetups._astronomyInfoModel);

            Assert.Throws<Exception>(() => _classUnderTest.
                                     GetWeatherInfoResponse(userInput));
        }

        [Test]
        public void Should_Throw_Exception_If_Request_Fails_When_Retrieving_Astronomy_Info()
        {
            var expectedResult = TestResources.ModelSetups._responseBoundary;
            var userInput = TestResources.ModelSetups._requestBoundaryC;

            _weatherInfoServiceMoq.Setup(x => x.RetrieveWeatherInfo(userInput))
                                        .Returns(TestResources.ModelSetups._weatherInfoModel);
            _weatherInfoServiceMoq.Setup(x => x.RetrieveWeatherInfoAstronomy(userInput))
                                        .Throws(new Exception());

            Assert.Throws<Exception>(() => _classUnderTest.
                                     GetWeatherInfoResponse(userInput));
        }
    }
}
