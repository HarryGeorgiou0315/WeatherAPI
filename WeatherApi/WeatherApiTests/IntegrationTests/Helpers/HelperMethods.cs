using System.Net;
using System.Text;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Newtonsoft.Json;

namespace WeatherApiTests.IntegrationTests.Helpers
{
    public static class HelperMethods
    {
        public static void SetupWeatherApiMockApiWithRequest(WireMockServer mockWeatherApi, HttpStatusCode httpStatusCode)
        { 
            mockWeatherApi.Given(Request.Create().WithPath("/current.json").UsingGet())
                .RespondWith(Response.Create().WithBody(JsonConvert.SerializeObject(TestResources.ModelSetups._weatherInfoModel), encoding: Encoding.UTF8)
                    .WithStatusCode(httpStatusCode));
        }
        public static void SetupAstronomyApiMockApiWithRequest(WireMockServer mockWeatherApi, HttpStatusCode httpStatusCode)
        {
            mockWeatherApi.Given(Request.Create().WithPath("/astronomy.json").UsingGet())
                .RespondWith(Response.Create().WithBody(JsonConvert.SerializeObject(TestResources.ModelSetups._astronomyInfoModel), encoding: Encoding.UTF8)
                    .WithStatusCode(httpStatusCode));
        }
    }
}
