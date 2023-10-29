using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Modul8_prak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myArray = new RangeOfArray(6, 10);
            myArray[6] = 1;
            myArray[10] = 5;

            Console.WriteLine(myArray[6]); 
            Console.WriteLine(myArray[10]);

            ////////////////
            ///
            // Проверка на скидку
            var supermarket = new Supermarket();
            supermarket.AddProduct(new Product("Молоко", 60));
            supermarket.AddProduct(new Product("Хлеб", 40));
            supermarket.AddProduct(new Product("Яблоки", 100));

            decimal total = supermarket.CalculateTotal();
            Console.WriteLine($"Общая сумма: {total} руб.");
            //////////////////////
            ///
            var salesForecast = new SalesForecast();

            double[] salesData = salesForecast.ReadSalesData("sales_data.txt");

            if (salesData.Length > 0)
            {
                double[] forecast = salesForecast.ForecastSales(salesData, 3);
                Console.WriteLine("Прогноз объемов продаж на следующие три месяца:");
                foreach (var sale in forecast)
                {
                    Console.WriteLine(sale);
                }
            }
            else
            {
                Console.WriteLine("Ошибка при чтении данных.");
            }
            Console.ReadKey();
        }
    }
}
