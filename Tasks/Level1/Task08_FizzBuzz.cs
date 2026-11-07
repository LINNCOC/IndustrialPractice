using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using industrialpractice.Common;


namespace industrialpractice.Tasks.Level1
{
    /// <summary>
    /// Задание 8: FizzBuzz
    /// </summary>
    public class Task08_FizzBuzz : ITask
    {
        /// <summary>
        /// Название задания.
        /// </summary>
        public string Title => "FizzBuzz 1–100";
        /// <summary>
        /// Описание задания.
        /// </summary>
        public string Description => "Вывести числа от 1 до 100 с заменами.";
        /// <summary>
        /// Требования к заданию.
        /// </summary>
        public string[] Requirements => new[] { "Кратно 3 → `Fizz`.",
            "Кратно 5 → `Buzz`.",
            "Кратно 15 → `FizzBuzz`.",
            "Иначе — само число.",
            "Порядок проверок: сначала 15, потом 3 и 5."};
        /// <summary>
        /// Запуск задания.
        /// </summary>
        public void Run()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 15 == 0)
                    Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0)
                    Console.WriteLine("Fizz");
                else if (i % 5 == 0)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine(i);
            }
        }
    }
}
