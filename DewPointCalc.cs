using System;
using System.Collections.Generic;
using System.Text;

namespace SensorAPI
{
    /// <summary>
    /// This class calculates the dew point based on the temperature and humidity using the Magnus formula.
    /// 
    /// </summary>
    public class DewPointCalc
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }

        public DewPointCalc(double temperature, double humidity)
        {
            Temperature = temperature;
            Humidity = humidity;
        }

        public double DewPointCalculator(double temperature, double humidity)
        {
            double a = 17.27;
            double b = 237.7;

            double alpha = ((a * temperature) / (b + temperature)) + Math.Log(humidity / 100.0);
            double dewPoint = (b * alpha) / (a - alpha);

            double DewPointF = (dewPoint * 9 / 5) + 32; // Convert to Fahrenheit

            return (int)Math.Round(DewPointF);
        }
    }
}
