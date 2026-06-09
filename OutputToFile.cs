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

            // write using UTF-8 with BOM so consumers (e.g., Excel) detect UTF-8 and display characters like '°' correctly
            File.AppendAllLines(path, logOutput, new System.Text.UTF8Encoding(encoderShouldEmitUTF8Identifier: true));
            Console.WriteLine();

            return path;
        }

    }
}
