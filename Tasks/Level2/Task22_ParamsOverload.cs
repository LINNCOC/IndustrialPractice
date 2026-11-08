using System;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level2
{
    /// <summary>
    /// Задание 22: params-метод + перегрузка.
    /// </summary>
    public class Task22_ParamsOverload : ITask
    {
        public string Title => "params-метод + перегрузка";
        public string Description => "Написать метод суммы с params и его перегрузку.";
        public string[] Requirements => new[] {
            "Sum(params int[] numbers) — сумма произвольного числа чисел.",
            "Перегрузка Sum(int[] numbers) — та же логика для массива.",
            "Продемонстрировать: Sum(1, 2, 3), Sum(new[] {1, 2, 3}), Sum().",
            "Пустой вызов — вернуть 0."
        };

        public void Run()
        {
            Console.WriteLine($"Sum(1, 2, 3) = {Sum(1, 2, 3)}");
            Console.WriteLine($"Sum(new[] {{1, 2, 3}}) = {Sum(new[] { 1, 2, 3 })}");
            Console.WriteLine($"Sum() = {Sum()}");
        }

        private int Sum(params int[] numbers)
        {
            int total = 0;
            foreach (int n in numbers) total += n;
            return total;
        }
    }
}