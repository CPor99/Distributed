using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient.Controllers
{
    class ClimaCellController : Controller
    {
        private ClimaCellEndpoint climaCellEndpoint;

        public ClimaCellController() : base()
        {
            climaCellEndpoint = new ClimaCellEndpoint();
        }

        public float getCurrentWeather(string cityName)
        {
            float temperature = 0f;

            restClient.endpoint = climaCellEndpoint.getCurrentEndpoint(cityName);
            string response = restClient.makeRequest();

            JSONParser<List<ClimaCellModel>> jsonParser = new JSONParser<List<ClimaCellModel>>();

            List<ClimaCellModel> deserialisedClimateCellModel = new List<ClimaCellModel>();
            deserialisedClimateCellModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            temperature = deserialisedClimateCellModel[0].main.latitude;
            temperature = deserialisedClimateCellModel[1].main.longitude;

            return temperature;
        }

        public List<ClimaCellForcast> getForecast(string cityName)
        {
            List<ClimaCellForcast> forecastList = new List<ClimaCellForcast>();

            restClient.endpoint = climaCellEndpoint.getForecastEndpoint(cityName);
            string response = restClient.makeRequest();

            JSONParser<ClimaCellModel> jsonParser = new JSONParser<ClimaCellModel>();


            ClimaCellModel deserialisedClimaCell = new ClimaCellModel();
            deserialisedClimaCell = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            foreach (DailyForecast dailyForecast in deserialisedClimaCell.DailyForecasts)
            {
                forecastList.Add(new AccuWeatherForecast(dailyForecast.EpochDate, dailyForecast.Temperature.Minimum.Value, dailyForecast.Temperature.Maximum.Value));
            }

            return forecastList;
        }
    }
}
