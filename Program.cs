using DocumentFormat.OpenXml.Spreadsheet;
using System.Globalization;
using System.Security.Cryptography;

namespace SensorAPI
{
    internal class Program
    {

        static void Main(string[] args)
        {

            // OutputToFile toFile = new OutputToFile();


            string FilePathInput = "C:\\Program Files (x86)\\WiFi Sensor Software\\sensor1.wdf";
            string FilePathOutput = "C:\\Users\\lburkardt\\Documents\\DATALogger\\log.csv";

            try

            {

                if (!File.Exists(FilePathInput))
                {
                    Console.WriteLine("File at input directory was not found.");
                    return;
                }

                Console.WriteLine();
                Console.WriteLine($"Reading file from: {FilePathInput}");
                Console.WriteLine($"Exporting file to: {FilePathOutput}");

                string[] logOutput = File.ReadAllLines(FilePathInput);
                {
                    //==============================================================
                    // Layout of the input file columns is as follows:
                    // 0: Time YYYY-MM-DD HH:MM:SS
                    // 1: Temperature in Celsius (Float, 1 decimal)
                    // 2: humidity in percentage (Int, relative humidity)
                    // 3: sample start (not needed)
                    // 4: recording date YYYY-MM-DD HH:MM:SS (not needed, i think this is "output" date)
                    //
                    // file is comma delimited and has a header row
                    // recalculate temp to farenheit
                    // discard index 3 and 4 and add index 3 as the calculated dew point in Fahrenheit
                    //==============================================================

                    List<string> fileOutput = new List<string>();

                    //==============================================================
                    // Loop through each line, delimit it into a parrallel array, perform calc for dew point, then compile into a single line array for export into csv.
                    //==============================================================

                    foreach (var line in logOutput) //skipped header
                    {

                        string[] columns = line.Split(',');

                        string time = columns[0];
                        string tempC = columns[1];
                        string humidity = columns[2];


                        DewPointCalc dewPointCalc = new DewPointCalc(Convert.ToDouble(tempC), Convert.ToDouble(humidity));

                        double dewPoint = dewPointCalc.DewPointCalculator(Convert.ToDouble(tempC), Convert.ToDouble(humidity));


                        string newLine = 
                            string.Join
                            (",", new string[]
                                {
                                    time,
                                    tempC,
                                    humidity,
                                    dewPoint.ToString(),
                                }
                            );
                        fileOutput.Add(newLine);
                        
                    }


                    var existing = File.Exists(FilePathOutput)
                        ? new HashSet<string>(File.ReadAllLines(FilePathOutput))
                        : new HashSet<string>();

                    foreach (var line in fileOutput.Skip(1))
                    {
                        if (!existing.Contains(line))
                        {
                            File.AppendAllText(FilePathOutput, line + Environment.NewLine);
                        }
                    }

                }
                ;
            }

            catch (Exception ex)

            { Console.WriteLine(ex.ToString()); }

        }
    }
}
