using System;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.WebClient;
using WeatherForecastWebClient.Output;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using WeatherForecastWebClient.WeatherModel;
using WeatherForecastWebClient.ForecastModel;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.Controllers;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string response = String.Empty;

            //OpenWeatherMap
            //openWeatherMapCurrentAPI();
            //openWeatherMapForecastAPI();

            ////Accuweather
            //accuweatherCurrentConditionsAPI();
            //accuweatherForecastAPI();

            //DarkSky
            darkSkyCurrentConditionsAPI();
            darkSkyForecastAPI();

            Console.ReadKey();

        }

        //static void openWeatherMapCurrentAPI()
        //{
        //    Out output = new Out();

        //    OpenWeatherMapController openWeatherMapController = new OpenWeatherMapController();

        //    output.outputToConsole("**** Open Weather Map Current Weather *****");

        //    string cityName = "Valletta";
        //    output.outputToConsole($"Temperature for {cityName}: {openWeatherMapController.getCurrentTemperature(cityName,EndpointType.CURRENT)}");

        //    cityName = "London";
        //    output.outputToConsole($"Temperature for {cityName}: {openWeatherMapController.getCurrentTemperature(cityName, EndpointType.CURRENT)}");
        //}

        //static void openWeatherMapForecastAPI()
        //{
        //    Out output = new Out();

        //    OpenWeatherMapController openWeatherMapController = new OpenWeatherMapController();

        //    output.outputToConsole("**** Open Weather Map Forecast *****");

        //    string cityName = "Valletta";

        //    output.outputToConsole($"Forecast weather for: {cityName}");

        //    foreach (OpenWeatherMapForecast forecast in openWeatherMapController.getForecastList(cityName,EndpointType.FORECAST))
        //    {          
        //        output.outputToConsole($"Date/Time: {forecast.dateTime} Temperature: {forecast.temperature}");
        //    }
        //}

        //static void accuweatherCurrentConditionsAPI()
        //{
        //    Out output = new Out();

        //    AccuWeatherController accuweatherController = new AccuWeatherController();

        //    output.outputToConsole("***** Accuweather Current Conditions *****");

        //    string cityName = "Valletta";

        //    output.outputToConsole($"Temperature for {cityName}: {accuweatherController.getCurrentWeather(cityName)}");
        //}

        //static void accuweatherForecastAPI()
        //{
        //    Out output = new Out();

        //    AccuWeatherController accuweatherController = new AccuWeatherController();

        //    output.outputToConsole("***** Accuweather Forecast *****");

        //    string cityName = "Valletta";

        //    foreach (AccuWeatherForecast forecast in accuweatherController.getForecast(cityName))
        //    {
        //        output.outputToConsole($"{forecast.getDateTime().ToString()} Minimum: {forecast.getMinimum()} Maximum: {forecast.getMaximum()}");
        //    }
        //}

        static void darkSkyCurrentConditionsAPI()
        {
            Out output = new Out();

            DarkSkyWeatherController darkSkyWeatherController = new DarkSkyWeatherController();

            output.outputToConsole("***** DarkSky Current Conditions *****");

            string cityName = "Valletta";

            output.outputToConsole($"Temperature for {cityName}: {darkSkyWeatherController.getForecast(cityName)}");
        }

        static void darkSkyForecastAPI()
        {
            Out output = new Out();

            DarkSkyWeatherController darkSkyWeatherController = new DarkSkyWeatherController();

            output.outputToConsole("***** DarkSky Forecast *****");

            string cityName = "Valletta";

            foreach (DarkSkyForcast forecast in darkSkyWeatherController.getForecast(cityName))
            {
                output.outputToConsole($"{forecast.getDateTime().ToString()} Minimum: {forecast.getMinimum()} Maximum: {forecast.getMaximum()}");
            }
        }
    }
}
