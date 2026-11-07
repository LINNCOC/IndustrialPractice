using System;
using System.Collections.Generic;
using System.Linq; 
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level1
{
    /// <summary>
    /// Задание 13: Счётчик вхождений слов в тексте.
    /// </summary>
    public class Task13_WordCounter : ITask
    {
        public string Title => "Счётчик вхождений слов";
        public string Description => "Посчитать, сколько раз каждое слово встречается в тексте.";
        public string[] Requirements => new[] { "Использовать Dictionary<string, int>", "Разбить текст на слова (по пробелам и знакам пунктуации)", "Привести слова к нижнему регистру", "Вывести пары «слово → количество», отсортированные по убыванию количества" };

        public void Run()
        {
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();

            if (string.IsNullOrEmpty(text)) return;

            char[] separators = { ' ', '.', ',', '!', '?', ';', ':', '-', '(', ')' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string lower = word.ToLower();
                if (counts.ContainsKey(lower))
                    counts[lower]++;
                else
                    counts.Add(lower, 1);
            }

            Console.WriteLine("\nРезультаты (по убыванию):");
            foreach (var pair in counts.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}