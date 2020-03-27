using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    class ClimaCellEndpoint : Endpoint
    {
        public ClimaCellEndpoint() : base (
            "cIb5SxWrS1jdWeVLvNimOlB0YqWTLtln",
            "http://api.climacell.co/v3/weather",
            new Dictionary<EndpointType, string>
            {
                {EndpointType.FORECAST, "forecast"},
                {EndpointType.CURRENT,"currentconditions" },
            })
        { }

        public string getCurrentEndpoint(string cityName)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{endpointTypeDictionary[EndpointType.CURRENT]}");
            stringBuilder.Append("?apikey=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&lat=");

            stringBuilder.Append("&lon=");
 
            stringBuilder.Append("&fields=temp:C");

            return stringBuilder.ToString();
        }

        public string getForecastEndpoint(string locationKey)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{endpointTypeDictionary[EndpointType.FORECAST]}");
            stringBuilder.Append("/daily");
            stringBuilder.Append("?apikey=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&lat=");

            stringBuilder.Append("&lon=");

            stringBuilder.Append("2&start_time=now&end_time=");
            //END TIME IN THE FORMAT 2020-03-25T14:09:50Z
            stringBuilder.Append("&fields=temp:C");

            return stringBuilder.ToString();
        }
    }
}
