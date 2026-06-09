using System.Reflection.Metadata.Ecma335;

namespace SensorAPI
{
    public class OutputToFile   
    {
        public string outPutToFile(string[] logOutput, string fileType)
        {
            if (logOutput == null) throw new ArgumentNullException(nameof(logOutput));

            string path = $"C:\\Users\\lburkardt\\Documents\\DATALogger\\log.{fileType}";
            string dir = Path.GetDirectoryName(path);
            
            
            if (!string.IsNullOrEmpty(dir))
            {
                Directory.CreateDirectory(dir);
            }

            File.AppendAllLines(path, logOutput);
            Console.WriteLine();

            return (string) path;
        }

    }
}
