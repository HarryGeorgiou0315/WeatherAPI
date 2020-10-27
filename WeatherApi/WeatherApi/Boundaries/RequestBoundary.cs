using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Boundaries
{
    public class RequestBoundary
    {
        /* <example>
         * 'Liverpool'
         * </example>*/
        [FromRoute(Name = "city")]
        public string City { get; set; }
        /* <example>
         * 'C' or 'F'
         * </example>*/
        [FromQuery(Name = "temp_measurement")]
        public string TempMeasurement { get; set; }
    }
}
