using System;
using System.Collections.Generic;
using System.Linq;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level2
{
    /// <summary>
    /// Задание 33: LINQ: сотрудники (top-3, avg по отделу, фильтр).
    /// </summary>
    public class Task33_LinqEmployees : ITask
    {
        public string Title => "LINQ: сотрудники (top-3, avg по отделу, фильтр)";
        public string Description => "LINQ-запросы по списку сотрудников.";
        public string[] Requirements => new[] {
            "Класс Employee: Name, Age, Salary, Department.",
            "Список из 10+ сотрудников.",
            "Запросы через LINQ: топ-3 по зарплате (убывание); средняя зарплата по каждому отделу (GroupBy + Average); сотрудники старше 30 (Where).",
            "Вывести результаты."
        };

        public void Run()
        {
            var employees = new List<Employee>
            {
                new Employee { Name = "Иван", Age = 25, Salary = 50000, Department = "IT" },
                new Employee { Name = "Анна", Age = 32, Salary = 80000, Department = "IT" },
                new Employee { Name = "Пётр", Age = 45, Salary = 120000, Department = "Management" },
                new Employee { Name = "Мария", Age = 28, Salary = 60000, Department = "HR" },
                new Employee { Name = "Сергей", Age = 35, Salary = 90000, Department = "IT" },
                new Employee { Name = "Ольга", Age = 41, Salary = 110000, Department = "Management" },
                new Employee { Name = "Дмитрий", Age = 29, Salary = 55000, Department = "Sales" },
                new Employee { Name = "Елена", Age = 38, Salary = 75000, Department = "Sales" },
                new Employee { Name = "Алексей", Age = 22, Salary = 40000, Department = "HR" },
                new Employee { Name = "Татьяна", Age = 31, Salary = 85000, Department = "IT" }
            };

            Console.WriteLine("--- Топ-3 по зарплате ---");
            var top3 = employees.OrderByDescending(e => e.Salary).Take(3);
            foreach (var e in top3) Console.WriteLine($"{e.Name}: {e.Salary}");

            Console.WriteLine("\n--- Средняя зарплата по отделам ---");
            var avgByDept = employees.GroupBy(e => e.Department)
                                     .Select(g => new { Dept = g.Key, Avg = g.Average(e => e.Salary) });
            foreach (var g in avgByDept) Console.WriteLine($"{g.Dept}: {g.Avg:F0}");

            Console.WriteLine("\n--- Сотрудники старше 30 ---");
            var older = employees.Where(e => e.Age > 30);
            foreach (var e in older) Console.WriteLine($"{e.Name} ({e.Age} лет)");
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
    }
}