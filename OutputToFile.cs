namespace SensorAPI
{
    public class OutputToFile   
    {
        public void outPutToFile(string[] logOutput)
        {
            if (logOutput == null) throw new ArgumentNullException(nameof(logOutput));

            string path = "C:\\Users\\lburkardt\\Documents\\DATALogger\\log.txt";
            string dir = Path.GetDirectoryName(path);
            
            
            if (!string.IsNullOrEmpty(dir))
            {
                Directory.CreateDirectory(dir);
            }

            File.AppendAllLines(path, logOutput);
            Console.WriteLine();
        }
    }
}
