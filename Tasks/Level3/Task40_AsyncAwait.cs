using System;
using System.Threading.Tasks;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level3
{
    /// <summary>
    /// Задание 40: async/await + обработка исключений.
    /// </summary>
    public class Task40_AsyncAwait : ITask
    {
        public string Title => "async/await + обработка исключений";
        public string Description => "Асинхронный метод с эмуляцией «скачивания».";
        public string[] Requirements => new[] {
            "async Task<string> DownloadAsync(string url) — внутри Task.Delay(1000).",
            "Имитировать ошибку: если url пустой — бросить ArgumentException.",
            "В Main вызвать через await внутри try/catch.",
            "Продемонстрировать успешный и ошибочный вызов."
        };

        public void Run()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        private async Task RunAsync()
        {
            try
            {
                Console.WriteLine("Попытка 1 (успешная):");
                string result = await DownloadAsync("https://example.com/data");
                Console.WriteLine($"Результат: {result}\n");

                Console.WriteLine("Попытка 2 (с ошибкой):");
                string result2 = await DownloadAsync("");
                Console.WriteLine($"Результат: {result2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Поймали ошибку: {ex.Message}");
            }
        }

        private async Task<string> DownloadAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException("URL не может быть пустым!");

            await Task.Delay(1000); 
            return $"Данные с {url} успешно загружены";
        }
    }
}