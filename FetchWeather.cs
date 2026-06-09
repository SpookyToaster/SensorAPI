using System.Text.Json;

namespace SensorAPI
{
    public class fetchWeather
    {

        public static async Task<string[]> FetchWeather(double latitude, double longitude)
        {
            string url = $"https://api.open-meteo.com/v1/forecast" +
                        $"?latitude=" + latitude +
                        $"&longitude=" + longitude +
                        $"&current_weather=true";

            string json = await getJson.GetJson(url);

            using JsonDocument doc = JsonDocument.Parse(json);

            JsonElement weather = doc.RootElement.GetProperty("current_weather");

            double temperature = weather.GetProperty("temperature").GetDouble();
            double windspeed = weather.GetProperty("windspeed").GetDouble();
            double weathercode = weather.GetProperty("weathercode").GetDouble();

            DewPointCalc dewPoint = new DewPointCalc(temperature, 50);

            //sanity test
            //Console.WriteLine($"Dew point is {dewPoint.DewPointCalculator}");

            //Revised log output to CSV format for easier parsing and analysis
            // Current output is in the same column, possibly need to export as a single string with delimiting commas??
            // If so, pretty lame. I like doing the string.
            string[] logOutput2 =
            {
                    $"{DateTime.Now}",
                    $"{temperature}",
                    $"{windspeed}",
                    $"{weathercode}",
                    $"{dewPoint.DewPointCalculator(temperature, 50)}",
                };

            string[] logOutput =
            {
                $"{DateTime.Now}," +
                $" {temperature}," +
                $" {windspeed}," +
                $" {weathercode}," +
                $" {dewPoint.DewPointCalculator(temperature, 50)}",
            };


            //string[] logOutput =
            //{
            //        "================================================",
            //        "[Open-Meteo API] ",
            //        $"TimeStamp: {DateTime.Now}",
            //        $"Current Temperature: {temperature}°C",
            //        $"Current Windspeed: {windspeed} km/h",
            //        $"Current Weathercode: {weathercode}",
            //        $"Current Dew Point: {dewPoint.DewPointCalculator(temperature, 50)} °F",
            //        "================================================"
            //    };

            return logOutput;
        }
    }
}
