namespace SensorAPI
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            string exit = "";

            Console.WriteLine("API Demo Test");
            Console.WriteLine("TODO: replace with actual API call");

            do
            {

                OutputToFile toFile = new OutputToFile();

                try
                {
                    string[] logOutput = await fetchWeather.FetchWeather(37.12929369843719, -93.45036244045811);
                    toFile.outPutToFile(logOutput, "txt");
                    foreach (var item in logOutput)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine($"File Output Path is {OutputToFile.path}");
                }

                catch (HttpRequestException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //exit = Console.ReadLine();
                await Task.Delay(120000);

            }
            while (exit != "0");

            // Open Meteo API: https://open-meteo.com/en/docs
            // Example API call: https://api.open-meteo.com/v1/forecast?latitude=37.21&longitude=-93.29&current_weather=true

        }
    }
}
