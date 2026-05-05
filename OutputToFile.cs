namespace SensorAPI
{
    public class OutputToFile   
    {
        public void outPutToFile(string[] logOutput)
        {
            // This is confusing - learn and rewrite in my own code
            if (logOutput == null) throw new ArgumentNullException(nameof(logOutput));

            string path = "C:\\Users\\Logan\\OneDrive\\SensorAPI\\log.txt";
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
