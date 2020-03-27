using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;
using WeatherForecastWebClient.WebClient;

namespace WeatherForecastWebClient.Controllers
{
    class DarkSkyWeatherController : Controller
    {
        private DarkSkyEndpoint darkSkyEndpoint;
        private LatitudeLongitudeEndpoint LatitudeLongitudeEndpoint;

        public DarkSkyWeatherController() : base ()
        {
            darkSkyEndpoint = new DarkSkyEndpoint();
            LatitudeLongitudeEndpoint = new LatitudeLongitudeEndpoint();
        }

        private string getPosition(string cityName)
        {
            float latitude = 0f;
            float longitude = 0f;

            string response = getResponse(LatitudeLongitudeEndpoint.getEndpoint(cityName));

            JSONParser<List<Position>> jsonParser = new JSONParser<List<Position>>();
            
            List<Position> LatandLongModel = new List<Position>();
            LatandLongModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            //temperature = darkSkyForecastModel.data[0].temp;
            latitude = LatandLongModel[0].GeoPosition.Latitude;
            longitude = LatandLongModel[0].GeoPosition.Longitude;
            
            return latitude + "," + longitude;
        }

        public float getCurrentWeather(string cityName)
        {
            float temperature = 0f;
            string position = getPosition(cityName);

            string response = getResponse(darkSkyEndpoint.getTimeMachineEndpoint(position));
            System.Diagnostics.Debug.WriteLine(response);

            JSONParser<List<AccuWeatherWeatherModel>> jsonParser = new JSONParser<List<AccuWeatherWeatherModel>>();

            List<AccuWeatherWeatherModel> deserialisedAccuWeatherModel = new List<AccuWeatherWeatherModel>();
            deserialisedAccuWeatherModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            temperature = deserialisedAccuWeatherModel[0].Temperature.Metric.Value;

            return temperature;
        }

        public List<DarkSkyForcast> getForecast(string cityName)
        {
            List<DarkSkyForcast> forecastList = new List<DarkSkyForcast>();

            string position = getPosition(cityName);

            string response = getResponse(darkSkyEndpoint.getTimeMachineEndpoint(position));
            System.Diagnostics.Debug.WriteLine(response);

            JSONParser<DarkSkyForcastModel> jsonParser = new JSONParser<DarkSkyForcastModel>();
            
            DarkSkyForcastModel darkSkyForecastModel = new DarkSkyForcastModel();
            darkSkyForecastModel =  jsonParser.parseJSON(response, Parser.Version.NETCore2);

            foreach (Data data in darkSkyForecastModel.daily.data)
            {
                forecastList.Add(new DarkSkyForcast(data.time, data.temp_min, data.temp_max));
            }
            
            return forecastList;
        }
    }
}
