using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;

namespace WeatherForecastWebClient.Controllers
{
    class WeatherBitController : Controller
    {
        private WeatherBitEndpoint weatherBitEndpoint;

        public WeatherBitController() : base()
        {
            weatherBitEndpoint = new WeatherBitEndpoint();
        }
    }
}
