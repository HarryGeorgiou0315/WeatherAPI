using NUnit.Framework;
using WeatherApi.Factory;

namespace WeatherApiTests.UnitTests.Factory
{
    [TestFixture]
    public class WeatherInfoFactoryTests
    {
        [Test]
        public void Should_Convert_WeatherInfoModel_To_ResponseModel_With_Tempurature_Showing_Celsius()
        {
            var expectedResult = TestResources.ModelSetups._responseBoundary;
            var result = WeatherInfoFactory.ToResponseModel(
                        TestResources.ModelSetups._weatherInfoModel,
                        TestResources.ModelSetups._astronomyInfoModel.AstronomyInfoDetail.AstronomyInfoModel,
                        TestResources.ModelSetups._requestBoundaryC);


            Assert.AreEqual(TestResources.ModelSetups._weatherInfoModel.Tempurature.TempCelsius,
                            result.Tempurature);
        }

        [Test]
        public void Should_Convert_WeatherInfoModel_To_ResponseModel_With_Tempurature_Showing_Fahrenheit()
        {
            var expectedResult = TestResources.ModelSetups._responseBoundary;
            var result = WeatherInfoFactory.ToResponseModel(
                        TestResources.ModelSetups._weatherInfoModel,
                        TestResources.ModelSetups._astronomyInfoModel.AstronomyInfoDetail.AstronomyInfoModel,
                        TestResources.ModelSetups._requestBoundaryF);


            Assert.AreEqual(TestResources.ModelSetups._weatherInfoModel.Tempurature.TempFahrenheit,
                            result.Tempurature);
        }

        [Test]
        public void Should_Convert_WeatherInfoModel_To_ResponseModel()
        {
            var expectedResult = TestResources.ModelSetups._responseBoundary;
            var result = WeatherInfoFactory.ToResponseModel(
                        TestResources.ModelSetups._weatherInfoModel,
                        TestResources.ModelSetups._astronomyInfoModel.AstronomyInfoDetail.AstronomyInfoModel,
                        TestResources.ModelSetups._requestBoundaryC);

            Assert.AreEqual(expectedResult.City, result.City);
            Assert.AreEqual(expectedResult.Country, result.Country);
            Assert.AreEqual(expectedResult.LocalTime.Date, result.LocalTime.Date);
            Assert.AreEqual(expectedResult.Region, result.Region);
            Assert.AreEqual(expectedResult.Tempurature, result.Tempurature);
            Assert.AreEqual(expectedResult.Sunrise, result.Sunrise);
            Assert.AreEqual(expectedResult.Sunset, result.Sunset);
        }

        [Test]
        public void Should_Convert_WeatherInfoModel_To_ResponseModel_With_Temp_Measurement_Celisus_When_Not_Specified()
        {
            var expectedResult = TestResources.ModelSetups._responseBoundary;
            var result = WeatherInfoFactory.ToResponseModel(
                        TestResources.ModelSetups._weatherInfoModel,
                        TestResources.ModelSetups._astronomyInfoModel.AstronomyInfoDetail.AstronomyInfoModel,
                        TestResources.ModelSetups._requestBoundaryNoTempMeasurement);

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
