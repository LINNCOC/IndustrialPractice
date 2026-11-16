using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level3
{
    /// <summary>
    /// Задание 41: Task.WhenAll — параллельно 10 задач.
    /// </summary>
    public class Task41_TaskWhenAll : ITask
    {
        public string Title => "Task.WhenAll — параллельно 10 задач";
        public string Description => "Запустить 10 задач параллельно и сравнить с последовательным выполнением.";
        public string[] Requirements => new[] {
            "Метод Task<int> WorkAsync(int id) — Task.Delay(500), возвращает id.",
            "Последовательный запуск 10 задач в цикле с await.",
            "Параллельный запуск через Task.WhenAll.",
            "Замерить время обоих вариантов через Stopwatch.",
            "Вывести оба времени и объяснить разницу."
        };

        public void Run()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        private async Task RunAsync()
        {
            Console.WriteLine("Последовательный запуск (10 задач по 500мс)...");
            var sw1 = Stopwatch.StartNew();
            var results1 = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                results1.Add(await WorkAsync(i));
            }
            sw1.Stop();

            Console.WriteLine("Параллельный запуск (10 задач по 500мс)...");
            var sw2 = Stopwatch.StartNew();
            var tasks = new List<Task<int>>();
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(WorkAsync(i));
            }
            int[] results2 = await Task.WhenAll(tasks);
            sw2.Stop();

            Console.WriteLine($"\nПоследовательно: {sw1.ElapsedMilliseconds} мс");
            Console.WriteLine($"Параллельно:     {sw2.ElapsedMilliseconds} мс");

            /*
            Почему разница?
            В последовательном варианте мы ждем окончания каждой задачи по очереди: 10 * 500 = 5000 мс.
            В параллельном варианте задачи запускаются одновременно, и мы ждем самую долгую из них: ~500 мс.
            */
        }

        private async Task<int> WorkAsync(int id)
        {
            await Task.Delay(500);
            return id;
        }
    }
}