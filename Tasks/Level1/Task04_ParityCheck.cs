using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using industrialpractice.Common;
using System.Threading.Tasks;

namespace industrialpractice.Tasks.Level1
{
    /// <summary>
    /// Задание 4: Проверка на четность.
    /// </summary>
    public class Task04_ParityCheck : ITask
    {
        /// <summary>
        /// Название задания.
        /// </summary>
        public string Title => "Чётность числа (два способа)";
        /// <summary>
        /// Описание задания.
        /// </summary>
        public string Description => "Определить, чётное ли введённое число.";
        /// <summary>
        /// Требования к заданию.
        /// </summary>
        public string[] Requirements => new[] { "Способ 1: через `% 2 == 0`.",
            "Способ 2: через тернарный оператор `? :`",
            "Оба способа реализовать отдельными методами.",
            "Вывести результат обоих способов. "};
        /// <summary>
        /// Запуск задания.
        /// </summary>
        public void Run()
        {
            Console.Write("Введите целое число: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Ошибка. введено не целое число.");
                return;
            }

            Console.WriteLine($"Способ 1 (через %): {IsEven(number)}");
            Console.WriteLine($"Способ 2 (через тернарный оператор): {IsEvenTernary(number)}");
        }

        private bool IsEven(int n)
        {
            return n % 2 == 0;
        }

        private bool IsEvenTernary(int n)
        {
            return n % 2 == 0 ? true : false;
        }
    }
}
