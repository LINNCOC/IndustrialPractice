using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level1
{
    /// <summary>
    /// Задание 6: Суммац цифр числа.
    /// </summary>
    public class Task06_DigitsSum : ITask
    {
        /// <summary>
        /// Название задания.
        /// </summary>
        public string Title => "Сумма цифр числа (строка + арифметика)";
        /// <summary>
        /// Описание задания.
        /// </summary>
        public string Description => "Найти сумму цифр введённого числа (например, 1234 → 10).";
        /// <summary>
        /// Требования к заданию.
        /// </summary>
        public string[] Requirements => new[] { "Способ 1 (строка): число → `ToString()` → пройти по символам → `int.Parse` каждой цифры",
            "Способ 2 (арифметика): цикл `while (n > 0) { sum += n % 10; n /= 10; }`",
            "Оба способа оформить отдельными методами",
            "Отрицательные числа — брать модуль"};
        /// <summary>
        /// Запуск задания.
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Введите набор чисел");
            string UserNumbers = Console.ReadLine();
            if (!int.TryParse(UserNumbers, out int num1))
            {
                Console.WriteLine("Ошибка. Неверное значение"); return;
            }
            int finalnum = Math.Abs(num1);
            Console.WriteLine($"Первый способ - {SumDigitsString(finalnum)}");
            Console.WriteLine($"Второй способ - {SumDigitsMath(finalnum)}");
        }
        private int SumDigitsString(int n)
        {
            string s = n.ToString();
            int sum = 0;
            foreach (char c in s)
            {
                sum += int.Parse(c.ToString()); 
            }
            return sum;
        }
        private int SumDigitsMath(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10; 
                n /= 10;       
            }
            return sum;
        }
    }
}
