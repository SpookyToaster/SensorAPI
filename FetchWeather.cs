using DocumentFormat.OpenXml.Office.CustomUI;
using System.Text.Json;

// ============================================================
// THIS CLASS IS RESPONSIBLE FOR FETCHING THE WEATHER DATA FROM THE API
// ============================================================
// THIS CLASS IS NOW OBSOLETE
// 6/16/2026
// DATA EXISTS IN WINDOWS ACCESSIBLE FILE. NO API ACCESS AVAILABLE AT THIS TIME. 
//============================================================


namespace SensorAPI
{
    public class fetchWeather
    {
        [Obsolete()]
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

            string[] logOutput =
            {
                $"{DateTime.Now}," +
                $" {temperature}," +
                $" {windspeed}," +
                $" {weathercode}," +
                $" {dewPoint.DewPointCalculator(temperature, 50)}",
            };

            //check the alert values directly here instead of in program.cs
            //use the alert method, but if used in here we can iterate through the array n+1.
            //if an issue is found then need to kick out an alert from the alert method

            Alert firstAlert = new Alert();

            foreach (var item in logOutput)
            {
                //perform the error handling inside of alert method to convert to int. need to skip first index, always.
                int i = 0;
                firstAlert.alert(logOutput[i]);

            }

            //===========================================================
            // OBSOLETE BLOCK
            // SINGLE COLUMN EXPORT ONLY
            //===========================================================

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

            //===========================================================
            // OBSOLETE BLOCK
            // SINGLE COLUMN EXPORT ONLY
            //===========================================================
            //string[] logOutput2 =
            //{
            //        $"{DateTime.Now}",
            //        $"{temperature}",
            //        $"{windspeed}",
            //        $"{weathercode}",
            //        $"{dewPoint.DewPointCalculator(temperature, 50)}",
            //    };


            return logOutput;
        }
    }
}
