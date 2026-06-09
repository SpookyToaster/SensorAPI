using System.Security.Cryptography;

namespace SensorAPI
{
    public class OutputToFile   
    {
        public string outPutToFile(string[] logOutput, string fileType)
        {
            if (logOutput == null) throw new ArgumentNullException(nameof(logOutput));


            // Revise to private and add method to update default path? Need to display default path and ask user if that's the correct filepath?
            string path = $"C:\\Users\\lburkardt\\Documents\\DATALogger\\log.{fileType}";
            string dir = Path.GetDirectoryName(path);
            
            
            if (!string.IsNullOrEmpty(dir))
            {
                string[] headers =
                {
                    "Date Time," +
                    "Temp (F)," +
                    "Windspeed (Mph)," +
                    "Weathercode?," +
                    "Dew point"
                };

                Console.WriteLine();
                Directory.CreateDirectory(dir);
                Console.WriteLine($"No existing file found, creating new File.{fileType}");
                Console.WriteLine($"Added headers to new file.");
                File.AppendAllLines(path, headers);
            }

            
            File.AppendAllLines(path, logOutput);
            Console.WriteLine();

            return path;
        }

    }
}
