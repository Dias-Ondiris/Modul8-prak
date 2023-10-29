using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Modul8_prak
{
    public class SalesForecast
    {
        public double[] ReadSalesData(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                var sales = new List<double>();

                foreach (var line in lines)
                {
                    if (double.TryParse(line, out double sale))
                    {
                        sales.Add(sale);
                    }
                    else
                    {
                        Console.WriteLine($"Не удалось прочитать значение: {line}");
                    }
                }

                return sales.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
                return new double[0];
            }
        }

        public (double a, double b) CalculateLinearRegressionCoefficients(double[] sales)
        {
            int n = sales.Length;
            double sumX = 0, sumY = 0, sumXxY = 0, sumXxX = 0;

            for (int i = 0; i < n; i++)
            {
                sumX += i + 1;
                sumY += sales[i];
                sumXxY += (i + 1) * sales[i];
                sumXxX += (i + 1) * (i + 1);
            }

            double a = (n * sumXxY - sumX * sumY) / (n * sumXxX - sumX * sumX);
            double b = (sumY - a * sumX) / n;

            return (a, b);
        }

        public double[] ForecastSales(double[] sales, int monthsToForecast)
        {
            var (a, b) = CalculateLinearRegressionCoefficients(sales);
            double[] forecast = new double[monthsToForecast];

            for (int i = 0; i < monthsToForecast; i++)
            {
                forecast[i] = a * (sales.Length + i + 1) + b;
            }

            return forecast;
        }
    }
}
