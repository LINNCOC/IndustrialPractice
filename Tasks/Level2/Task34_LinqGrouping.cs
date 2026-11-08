using System;
using System.Collections.Generic;
using System.Linq;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level2
{
    /// <summary>
    /// Задание 34: LINQ: группировка слов по первой букве.
    /// </summary>
    public class Task34_LinqGrouping : ITask
    {
        public string Title => "LINQ: группировка слов по первой букве";
        public string Description => "Сгруппировать слова по первой букве.";
        public string[] Requirements => new[] {
            "Взять список слов (10+).",
            "Сгруппировать через LINQ GroupBy(w => w[0]).",
            "Отсортировать группы по первой букве.",
            "Внутри группы — отсортировать слова.",
            "Вывести «Буква: слово1, слово2, ...»."
        };

        public void Run()
        {
            var words = new List<string> { "яблоко", "банан", "арбуз", "брусника", "вишня", "авокадо", "виноград", "барбарис", "ягода", "абрикос" };

            var grouped = words.GroupBy(w => w[0])
                               .OrderBy(g => g.Key);

            foreach (var group in grouped)
            {
                var sortedWords = group.OrderBy(w => w);
                Console.WriteLine($"{group.Key}: {string.Join(", ", sortedWords)}");
            }
        }
    }
}