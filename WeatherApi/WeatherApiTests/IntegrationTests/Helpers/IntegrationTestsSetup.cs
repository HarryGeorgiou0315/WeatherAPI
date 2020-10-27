using System;
using System.Collections.Generic;
using System.Text;
using WireMock.Server;
using NUnit.Framework;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using WeatherApi;

namespace WeatherApiTests.IntegrationTests.Helpers
{
    public class IntegrationTestsSetup<TStartup> where TStartup : class
    {
        protected WireMockServer _mockWeatherApi { get; private set; }
        private MockWeatherApiFactory<TStartup> _factory;
        protected HttpClient _httpClient { get; private set; }

        [SetUp]
        public void Setup()
        {
            _mockWeatherApi = WireMockServer.Start();
            Environment.SetEnvironmentVariable("WEATHER_API_URL", $"http://localhost:{_mockWeatherApi.Ports[0]}/");
            Environment.SetEnvironmentVariable("API_KEY", "apiKey");
            _factory = new MockWeatherApiFactory<TStartup>();
            _httpClient = _factory.CreateClient();
        }

        [TearDown]
        public void Teardown()
        {
            _httpClient.Dispose();
            _factory.Dispose();
            _mockWeatherApi.Stop();
            _mockWeatherApi.Dispose();
        }
    }
}
