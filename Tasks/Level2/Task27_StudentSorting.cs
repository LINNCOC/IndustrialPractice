using System;
using System.Collections.Generic;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level2
{
    /// <summary>
    /// Задание 27: IComparable / IComparer<T> для Student.
    /// </summary>
    public class Task27_StudentSorting : ITask
    {
        public string Title => "IComparable / IComparer<T> для Student";
        public string Description => "Научить Student сортироваться.";
        public string[] Requirements => new[] {
            "Класс Student: Name, AverageGrade.",
            "Реализовать IComparable<Student> — сортировка по среднему баллу (по убыванию).",
            "Реализовать IComparer<Student> ByNameComparer — сортировка по имени.",
            "Продемонстрировать обе сортировки на List<Student>."
        };

        public void Run()
        {
            var students = new List<Student>
            {
                new Student { Name = "Иван", AverageGrade = 4.5 },
                new Student { Name = "Анна", AverageGrade = 4.8 },
                new Student { Name = "Пётр", AverageGrade = 3.9 }
            };

            Console.WriteLine("Сортировка по среднему баллу (убывание):");
            students.Sort();
            foreach (var s in students) Console.WriteLine($"{s.Name}: {s.AverageGrade}");

            Console.WriteLine("\nСортировка по имени:");
            students.Sort(new ByNameComparer());
            foreach (var s in students) Console.WriteLine($"{s.Name}: {s.AverageGrade}");
        }
    }

    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public double AverageGrade { get; set; }

        public int CompareTo(Student other)
        {
            return other.AverageGrade.CompareTo(this.AverageGrade);
        }
    }

    public class ByNameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }
}