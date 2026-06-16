using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace SensorAPI
{
    internal class FetchFile
    {
        public FetchFile(string FilePathInput)
        {

            FileInfo file = new FileInfo(FilePathInput);

            foreach (var item in file.Directory.GetFiles())
            {
                Console.WriteLine($"Found data at: {file}");
            }


            //=============================================================
            // May not need these variables. May just do the cleanup and calculation in excel. idk. Excel is stupid sometimes.
            // prefer to cleanup in here though and run through windows tasks scheduler and straight into powerBI. 
            //=============================================================
            //double temperature = ("temperature").GetDouble();
            //double windspeed = weather.GetProperty("windspeed").GetDouble();
            //double weathercode = weather.GetProperty("weathercode").GetDouble();

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
        }
    }
}
