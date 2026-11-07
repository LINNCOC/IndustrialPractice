using industrialpractice.Common;
using industrialpractice.Tasks.Level1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace industrialpractice.Menu
{
    public class LevelMenu
    {
        public void ShowLevel1Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Уровень 1: Базовый ---");
                Console.WriteLine("1. Hello, World + текущая дата");
                Console.WriteLine("2. Переменные примитивных типов");
                Console.WriteLine("3. Калькулятор с обработкой деления на ноль");
                Console.WriteLine("4. Чётность числа (два способа)");
                Console.WriteLine("5. Таблица умножения 10×10");
                Console.WriteLine("6. Сумма цифр числа (строка + арифметика)");
                Console.WriteLine("7. Реверс строки без LINQ");
                Console.WriteLine("8. FizzBuzz 1–100");
                Console.WriteLine("9. Массивы: min/max/sum/avg");
                Console.WriteLine("10. Сортировка пузырьком + вставками");

                Console.WriteLine("0. Назад");
                Console.WriteLine("\nВыберите номер");
                string UserChoice = Console.ReadLine();
                switch (UserChoice)
                {
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите Enter");
                        Console.ReadKey();
                        break;
                    case "0": Console.Clear(); return;

                    case "1": RunTask(new Task01_HelloWorld()); 
                        break;
                    case "2": RunTask(new Task02_Primitives());
                        break;
                    case "3": RunTask(new Task03_Calculator());
                        break;
                    case "4": RunTask(new Task04_ParityCheck());
                        break;
                    case "5": RunTask(new Task05_MultiplicationTable());
                        break;
                    case "6": RunTask(new Task06_DigitsSum());
                        break;
                    case "7": RunTask(new Task07_StringReverse());
                        break;
                    case "8": RunTask(new Task08_FizzBuzz());
                        break;
                    case "9": RunTask(new Task09_ArrayOperations());
                        break;
                    case "10": RunTask(new Task10_BubbleSorting());
                        break;
                }

            }
        }
        private void RunTask(ITask task)
        {
            Console.Clear();
            Console.WriteLine($"Задание: {task.Title}");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Описание: {task.Description}");
            Console.WriteLine("-----------------------------------------");
            foreach (var requirements  in task.Requirements)
            {
                Console.WriteLine($"- {requirements}");
            }
                Console.WriteLine("-----------------------------------------");
            task.Run();
                Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню");
            Console.ReadKey();
        }
    }
}
