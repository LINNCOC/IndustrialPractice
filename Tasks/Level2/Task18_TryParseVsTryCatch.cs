using System;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level2
{
    /// <summary>
    /// Задание 18: TryParse vs try/catch.
    /// </summary>
    public class Task18_TryParseVsTryCatch : ITask
    {
        public string Title => "TryParse vs try/catch";
        public string Description => "Сравнить два способа обработки некорректного ввода числа.";
        public string[] Requirements => new[] {
            "Способ 1: int.TryParse — вернуть bool + значение через out.",
            "Способ 2: int.Parse внутри try/catch — ловить FormatException.",
            "Оба оформить отдельными методами.",
            "Продемонстрировать на корректном и некорректном вводе."
        };

        public void Run()
        {
            Console.WriteLine("Введите число:");
            string input = Console.ReadLine();

            Console.WriteLine("\nСпособ 1 (TryParse)");
            if (TryParseMethod(input, out int result1))
                Console.WriteLine($"Успешно: {result1}");
            else
                Console.WriteLine("Ошибка: неверный формат");

            Console.WriteLine("\nСпособ 2 (try/catch)");
            try
            {
                int result2 = ParseMethod(input);
                Console.WriteLine($"Успешно: {result2}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: неверный формат");
            }
        }

        private bool TryParseMethod(string str, out int val)
        {
            return int.TryParse(str, out val);
        }

        private int ParseMethod(string str)
        {
            return int.Parse(str);
        }
    }
}