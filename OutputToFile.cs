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

            //TODO APPEND ALL lines is only appending to rows. Need to revise so the intial data is separated into columns, then appended. 
            File.AppendAllLines(path, logOutput);
            Console.WriteLine();

            return path;
        }

    }
}
