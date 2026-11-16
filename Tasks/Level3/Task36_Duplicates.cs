using System;
using System.Collections.Generic;
using System.Linq;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level3
{
    /// <summary>
    /// Задание 36: Дубликаты в List (HashSet + GroupBy).
    /// </summary>
    public class Task36_Duplicates : ITask
    {
        public string Title => "Дубликаты в List (HashSet + GroupBy)";
        public string Description => "Найти дубликаты в списке чисел двумя способами.";
        public string[] Requirements => new[] {
            "Способ 1: через HashSet<int> — при добавлении проверять Contains.",
            "Способ 2: через LINQ GroupBy(x => x).Where(g => g.Count() > 1).",
            "Оба способа оформить отдельными методами.",
            "Продемонстрировать на списке с повторяющимися значениями."
        };

        public void Run()
        {
            var list = new List<int> { 1, 2, 3, 2, 4, 5, 1, 6, 3, 3 };
            Console.WriteLine("Список: " + string.Join(", ", list));

            var dup1 = FindDuplicatesHashSet(list);
            var dup2 = FindDuplicatesLinq(list);

            Console.WriteLine($"HashSet: {string.Join(", ", dup1)}");
            Console.WriteLine($"LINQ:    {string.Join(", ", dup2)}");
        }

        private HashSet<int> FindDuplicatesHashSet(List<int> list)
        {
            var seen = new HashSet<int>();
            var duplicates = new HashSet<int>();
            foreach (var item in list)
            {
                if (!seen.Add(item)) 
                    duplicates.Add(item);
            }
            return duplicates;
        }

        private List<int> FindDuplicatesLinq(List<int> list)
        {
            return list.GroupBy(x => x)
                       .Where(g => g.Count() > 1)
                       .Select(g => g.Key)
                       .ToList();
        }
    }
}