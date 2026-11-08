using System;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level2
{
    /// <summary>
    /// Задание 21: enum дни недели.
    /// </summary>
    public class Task21_WeekdaysEnum : ITask
    {
        public string Title => "enum дни недели";
        public string Description => "Описать дни недели через enum и определить тип дня.";
        public string[] Requirements => new[] {
            "enum DayOfWeek { Monday, ..., Sunday }.",
            "Метод IsWeekend(DayOfWeek day) — true для субботы и воскресенья.",
            "Метод GetRussianName(DayOfWeek day) — возвращает название на русском.",
            "Продемонстрировать на всех 7 днях."
        };

        public void Run()
        {
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine($"{day}: {GetRussianName(day)}, Выходной: {IsWeekend(day)}");
            }
        }

        private bool IsWeekend(DayOfWeek day)
        {
            return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
        }

        private string GetRussianName(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday: return "Понедельник";
                case DayOfWeek.Tuesday: return "Вторник";
                case DayOfWeek.Wednesday: return "Среда";
                case DayOfWeek.Thursday: return "Четверг";
                case DayOfWeek.Friday: return "Пятница";
                case DayOfWeek.Saturday: return "Суббота";
                case DayOfWeek.Sunday: return "Воскресенье";
                default: return "Неизвестно";
            }
        }
    }

    /// <summary>
    /// Дни недели.
    /// </summary>
    public enum DayOfWeek
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }
}