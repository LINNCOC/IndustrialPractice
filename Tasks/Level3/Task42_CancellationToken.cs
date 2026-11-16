using System;
using System.Threading;
using System.Threading.Tasks;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level3
{
    /// <summary>
    /// Задание 42: CancellationToken — отмена через 2 сек.
    /// </summary>
    public class Task42_CancellationToken : ITask
    {
        public string Title => "CancellationToken — отмена через 2 сек";
        public string Description => "Реализовать долгую операцию с поддержкой отмены.";
        public string[] Requirements => new[] {
            "async Task LongOperationAsync(CancellationToken token) — цикл с Task.Delay(500, token) 10 раз.",
            "В Main создать CancellationTokenSource, запустить операцию, отменить через 2 секунды.",
            "Обработать OperationCanceledException.",
            "Вывести «операция отменена»."
        };

        public void Run()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        private async Task RunAsync()
        {
            var cts = new CancellationTokenSource();

            // Отменяем через 2 секунды
            cts.CancelAfter(2000);

            try
            {
                await LongOperationAsync(cts.Token);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nОперация была отменена (OperationCanceledException).");
            }
        }

        private async Task LongOperationAsync(CancellationToken token)
        {
            for (int i = 1; i <= 10; i++)
            {
                token.ThrowIfCancellationRequested(); // Проверяем, не отменили ли операцию
                Console.WriteLine($"Шаг {i} из 10...");
                await Task.Delay(500, token);
            }
        }
    }
}