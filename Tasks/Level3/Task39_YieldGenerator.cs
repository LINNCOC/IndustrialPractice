using System;
using System.Collections.Generic;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level3
{
    /// <summary>
    /// Задание 39: yield return — генератор чётных чисел.
    /// </summary>
    public class Task39_YieldGenerator : ITask
    {
        public string Title => "yield return — генератор чётных чисел";
        public string Description => "Реализовать генератор чётных чисел через yield return.";
        public string[] Requirements => new[] {
            "Метод IEnumerable<int> GetEvenNumbers(int max) — возвращает чётные числа до max.",
            "Реализовать именно через yield return, без промежуточного списка.",
            "Продемонстрировать работу в foreach.",
            "Дополнительно: показать ленивость — вывести сообщение внутри генератора и убедиться, что оно печатается по одному."
        };

        public void Run()
        {
            Console.WriteLine("Запускаем генератор...");
            foreach (var num in GetEvenNumbers(10))
            {
                Console.WriteLine($"Получено: {num}");
            }
        }

        private IEnumerable<int> GetEvenNumbers(int max)
        {
            for (int i = 0; i <= max; i += 2)
            {
                Console.WriteLine($"  [Генератор]: подготавливаю {i}");
                yield return i; 
            }
        }
    }
}