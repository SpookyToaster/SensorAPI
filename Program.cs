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

                    //Add header into file
                    fileOutput.Add("Time,Temp,Humidity,DewPoint");

                    //==============================================================
                    // split incoming data so calculations and re-formatting can be completed.
                    //==============================================================

                    foreach (var line in logOutput)
                    {

                        string[] columns = line.Split(',');

                        string time = columns[0];

                        if (!double.TryParse(columns[1], out double tempC)

                            ||

                            !double.TryParse(columns[2], out double humidity))
                        {
                            continue; // skip bad rows (headers, corrupt lines)
                        }

                        //calc dew point

                        DewPointCalc dewPointCalc = new DewPointCalc(tempC, humidity);
                        double dewPoint = dewPointCalc.DewPointCalculator(tempC, humidity);

                        //rebuild string for file export

                        string newLine =
                            string.Join
                            (",", new string[]
                                {
                                    time,
                                    tempC.ToString("F1", CultureInfo.InvariantCulture),
                                    humidity.ToString("F0", CultureInfo.InvariantCulture),
                                    dewPoint.ToString("F2", CultureInfo.InvariantCulture),
                                }
                            );


                        // assign string to fileoutput variable
                        fileOutput.Add(newLine);

                    }

                    bool fileCheck = File.Exists(FilePathOutput);

                    // check for duplicate values and skip if duplicate
                    // unsure if this actually works??
                    // Need to learn and test Hashset myself. 

                    var existingFile = File.Exists(FilePathOutput)
                        ? new HashSet<string>(File.ReadAllLines(FilePathOutput))
                        : new HashSet<string>();


                    // check if file exists to skip header print.
                    // For some reason won't refill missing rows. example: if row deleted, re-running does not refill. Hash issue?

                    if (fileCheck)
                    {
                        foreach (var line in fileOutput.Skip(1))
                        {
                            if (!fileCheck || !existingFile.Contains(line))
                            {
                                File.AppendAllText(FilePathOutput, line + Environment.NewLine);
                            }
                        }
                    }
                    else
                    {
                        foreach (var line in fileOutput)
                        {
                            if (!fileCheck || !existingFile.Contains(line))
                            {
                                File.AppendAllText(FilePathOutput, line + Environment.NewLine);
                            }
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
