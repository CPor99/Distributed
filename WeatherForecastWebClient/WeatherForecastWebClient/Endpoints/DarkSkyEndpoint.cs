using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    class DarkSkyEndpoint : Endpoint
    {
        public DarkSkyEndpoint() : base (
            "230505b00902edbcd97bf00ddffe5202",
            "http://api.darksky.net/forecast",
            new Dictionary<EndpointType, string>
            {
                {EndpointType.FORECAST, "forecast"},
            }){ }

        public string getTimeMachineEndpoint(string position)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{endpointTypeDictionary[EndpointType.FORECAST]}");
            stringBuilder.Append($"/{apiKey}");
            stringBuilder.Append(position);
            stringBuilder.Append("?units=si");
            
            return stringBuilder.ToString();
        }
    }
}
