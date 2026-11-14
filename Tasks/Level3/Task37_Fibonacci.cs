using System;
using System.Collections.Generic;
using System.Diagnostics;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level3
{
    /// <summary>
    /// Задание 37: Мемоизация Фибоначчи через Dictionary.
    /// </summary>
    public class Task37_Fibonacci : ITask
    {
        public string Title => "Мемоизация Фибоначчи через Dictionary";
        public string Description => "Реализовать мемоизированную функцию Фибоначчи.";
        public string[] Requirements => new[] {
            "Обычная рекурсивная версия (для сравнения на маленьком N).",
            "Мемоизированная версия с Dictionary<int, long>.",
            "Замерить время обеих на N = 30–35 через Stopwatch.",
            "Вывести оба времени и разницу."
        };

        public void Run()
        {
            int n = 35;
            Console.WriteLine($"Считаем Фибоначчи({n})...\n");

            var sw1 = Stopwatch.StartNew();
            long res1 = FibRecursive(n);
            sw1.Stop();

            var cache = new Dictionary<int, long>();
            var sw2 = Stopwatch.StartNew();
            long res2 = FibMemo(n, cache);
            sw2.Stop();

            Console.WriteLine($"Обычная рекурсия: {res1} ({sw1.ElapsedMilliseconds} мс)");
            Console.WriteLine($"Мемоизация:       {res2} ({sw2.ElapsedMilliseconds} мс)");
            Console.WriteLine($"Результаты равны: {res1 == res2}");
        }

        private long FibRecursive(int n)
        {
            if (n <= 1) return n;
            return FibRecursive(n - 1) + FibRecursive(n - 2);
        }

        private long FibMemo(int n, Dictionary<int, long> cache)
        {
            if (n <= 1) return n;
            if (cache.ContainsKey(n)) return cache[n];

            long result = FibMemo(n - 1, cache) + FibMemo(n - 2, cache);
            cache[n] = result;
            return result;
        }
    }
}