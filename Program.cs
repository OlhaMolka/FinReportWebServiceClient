using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinReportWebServiceClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // Задаємо базову адресу API
                    client.BaseAddress = new Uri("http://localhost:5269");

                    // Створюємо URL з параметрами запиту
                    string url = "/api/finreport/reportIds?dateBegin=2024-01-01&dateEnd=2024-12-31";

                    // Викликаємо метод API для отримання ID звітів
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        // Отримуємо результат і виводимо на консоль
                        var reportIds = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Отримання ID звітів:");
                        Console.WriteLine(reportIds);
                    }
                    else
                    {
                        Console.WriteLine($"Помилка: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

            Console.WriteLine("\nНатисніть Enter для завершення...");
            Console.ReadLine();
        }
    }
}
