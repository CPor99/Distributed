using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    class LatitudeLongitudeEndpoint : Endpoint
    {
        public LatitudeLongitudeEndpoint() : base (
            "http://dataservice.accuweather.com/locations/v1/cities/search",
            "WGhVOCmjgdjjt1EO461GV84cPNwa6AL1",
            new Dictionary<EndpointType, string>
            {
                {EndpointType.FORECAST, "forecast"},
            }
        ) 
        { }

        public string getEndpoint(string cityName)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{endpointTypeDictionary[EndpointType.FORECAST]}");
            stringBuilder.Append("?apikey=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&q=");
            stringBuilder.Append(cityName);
            return stringBuilder.ToString();
        }
    }
}
