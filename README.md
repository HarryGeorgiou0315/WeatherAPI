# WeatherAPI
A complete solution which can be used to retrieve weather information from a specified City. 

Overview:
- The weather API is being used for retrieving weather information from a given data source API.

Weather API example GET request

     GET /api/weather/london?temp_measurement=f
        

## How to use Weather API 

* build with `dotnet build` command
* run with `dotnet run` command - this will run locally
* run tests with `dotnet test` command.

Swagger documentation - `https://localhost:44393/index.html`

Use within Postman - `https://localhost:44393/api/weather/{city}?temp_measurement=""` *temp_measurement='C' (Celsius) or 'F' (Fahrenheit)*
 
 Example response:
 
    {
        "city": "London",
        "region": "City of London, Greater London",
        "country": "United Kingdom",
        "localTime": "2020-10-25T12:05:00",
        "tempurature": 50.0,
        "sunrise": "06:42 AM",
        "sunset": "04:46 PM"
    }
