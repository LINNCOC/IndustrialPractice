using System;
using System.Collections.Generic;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level2
{
    /// <summary>
    /// Задание 23: Nullable-типы, ??, ?..
    /// </summary>
    public class Task23_NullableTypes : ITask
    {
        public string Title => "Nullable-типы, ??, ?.";
        public string Description => "Продемонстрировать работу с nullable.";
        public string[] Requirements => new[] {
            "Метод int? FindValue(string key) — возвращает null, если ключа нет.",
            "Использовать ?? для значения по умолчанию.",
            "Использовать ?. для безопасного доступа к свойству объекта, который может быть null.",
            "Использовать HasValue / Value с проверкой.",
            "Продемонстрировать на примере с найденным и ненайденным ключом."
        };

        public void Run()
        {
            Console.WriteLine("--- Поиск 'apple' ---");
            int? val1 = FindValue("apple");
            Console.WriteLine($"?? (по умолчанию 0): {val1 ?? 0}");
            if (val1.HasValue) Console.WriteLine($"HasValue/Value: {val1.Value}");

            Console.WriteLine("\n--- Поиск 'cherry' ---");
            int? val2 = FindValue("cherry");
            Console.WriteLine($"?? (по умолчанию -1): {val2 ?? -1}");
            if (!val2.HasValue) Console.WriteLine("HasValue: значение не найдено");

            Console.WriteLine("\n--- Оператор ?. ---");
            string nullString = null;
            Console.WriteLine($"Длина строки (null): {nullString?.Length ?? 0}");
        }

        private int? FindValue(string key)
        {
            var dict = new Dictionary<string, int> { { "apple", 10 }, { "banana", 20 } };
            if (dict.ContainsKey(key)) return dict[key];
            return null;
        }
    }
}