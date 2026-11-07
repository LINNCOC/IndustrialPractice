using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using industrialpractice.Common;


namespace industrialpractice.Tasks.Level1
{
    /// <summary>
    /// Задание 3: Калькулятор.
    /// </summary>
    public class Task03_Calculator : ITask
    {
        /// <summary>
        /// Название задания.
        /// </summary>
        public string Title => "Калькулятор с обработкой деления на ноль";
        /// <summary>
        /// Описание задания.
        /// </summary>
        public string Description => "принимать два числа и оператор (`+ - * /`), выводить результат.";
        /// <summary>
        /// Требования к заданию.
        /// </summary>
        public string[] Requirements => new[] { "Оператор обрабатывать через `switch`.", 
            "При делении на ноль — вывести сообщение об ошибке, не ронять приложение.",
            "Некорректный оператор — вывести «Неизвестная операция».", 
            "Ввод чисел — через `double.Parse` или `TryParse`.  " };
        /// <summary>
        /// Запуск задания.
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Введите первое число");
            string firstChoice = Console.ReadLine();
            if (!double.TryParse(firstChoice, out double num1))
            {
                Console.WriteLine("Вы ввели некорректное значение. ");
                return;
            }
            Console.WriteLine("Введите второе число");
            string secondChoice = Console.ReadLine();
            if (!double.TryParse(secondChoice, out double num2))
            {
                Console.WriteLine("Вы ввели некорректное значение. ");
                return;
            }
            Console.WriteLine("Выберите нужную операцию: +, -, *, /");
            string operation = Console.ReadLine();
            switch (operation)
            {
                case "+": Console.WriteLine($"{num1} + {num2} = {num1 + num2}"); break;
                case "-": Console.WriteLine($"{num1} - {num2} = {num1 - num2}"); break;
                case "*": Console.WriteLine($"{num1} * {num2} = {num1 * num2}"); break;
                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine("Ошибка. На ноль делить нельзя!"); break;
                    }
                    else
                    {
                        Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
                    }
                    break;
                default: Console.WriteLine("Ошибка. Неизвестный оператор"); break;
            }
        }
    }
}
