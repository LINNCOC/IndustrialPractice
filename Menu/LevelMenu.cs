using industrialpractice.Common;
using industrialpractice.Tasks.Level1;
using industrialpractice.Tasks.Level2;
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
                Console.WriteLine("11. Диагональ матрицы N×N");
                Console.WriteLine("12. Палиндром (без учёта регистра/пробелов)");
                Console.WriteLine("13. Счётчик вхождений слов");
                Console.WriteLine("14. Возраст по дате рождения");
                Console.WriteLine("15. Git: локальный репозиторий");


                Console.WriteLine("0. Назад");
                Console.WriteLine("\nВыберите номер");
                string UserChoiceForLevel1 = Console.ReadLine();
                switch (UserChoiceForLevel1)
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
                    case "11": RunTask(new Task11_MatrixDiagonal());
                        break;
                    case "12": RunTask(new Task12_Palindrome());
                        break;
                    case "13": RunTask(new Task13_WordCounter());
                        break;
                    case "14": RunTask(new Task14_AgeCalculator());
                        break;
                    case "15": Console.WriteLine("Задание 15 выполнено через Git. См. файл git-notes.md.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void ShowLevel2Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Уровень 2: Средний ---");
                Console.WriteLine("16. Методы расширения для `string`");
                Console.WriteLine("17. `StringBuilder` vs конкатенация (замер)");
                Console.WriteLine("18. TryParse vs try/catch");
                Console.WriteLine("19. Свой стек/очередь на массиве");
                Console.WriteLine("20. Обобщения: Swap<T>, Max<T>");
                Console.WriteLine("21. enum дни недели");
                Console.WriteLine("22. params-метод + перегрузка");
                Console.WriteLine("23. Nullable-типы, ??, ?.");
                Console.WriteLine("24. ООП: Animal → Dog/Cat/Bird");
                Console.WriteLine("25. Интерфейс IShape + сортировка фигур");
                Console.WriteLine("26. Паттерн «Стратегия» (скидки)");
                Console.WriteLine("27. IComparable / IComparer<T> для Student");
                Console.WriteLine("28. Equals / GetHashCode для Point");
                Console.WriteLine("29. Паттерн «Фабрика» (уведомления)");
                Console.WriteLine("30. BankAccount + свой Exception");
                Console.WriteLine("31. IDisposable + using");
                Console.WriteLine("32. Свойства с валидацией (Temperature)");
                Console.WriteLine("33. LINQ: сотрудники (top-3, avg по отделу, фильтр)");
                Console.WriteLine("34. LINQ: группировка слов по первой букве");
                Console.WriteLine("35. Git: `.gitignore`, `.editorconfig`, PR, Conventional Commits, rebase");

                Console.WriteLine("0. Назад");
                Console.WriteLine("\nВыберите номер");

                string UserChoiceForLevel2 = Console.ReadLine();
                switch (UserChoiceForLevel2)
                {
                    case "16": RunTask (new Task16_StringExtensions()); break;
                    case "17": RunTask (new Task17_StringBuilderVsConcat()); break;
                    case "18": RunTask (new Task18_TryParseVsTryCatch()); break;
                    case "19": RunTask (new Task19_MyCollections()); break;
                    case "20": RunTask (new Task20_Generics()); break;
                    case "21": RunTask (new Task21_WeekdaysEnum()); break;
                    case "22": RunTask (new Task22_ParamsOverload()); break;
                    case "23": RunTask (new Task23_NullableTypes()); break;
                    case "24": RunTask (new Task24_AnimalHierarchy()); break;
                    case "25": RunTask (new Task25_ShapeSorting()); break;
                    case "26": RunTask (new Task26_StrategyPattern()); break;
                    case "27": RunTask (new Task27_StudentSorting()); break;
                    case "28": RunTask (new Task28_PointEquals()); break;
                    case "29": RunTask (new Task29_FactoryPattern()); break;
                    case "30": RunTask (new Task30_BankAccount()); break;
                    case "31": RunTask (new Task31_DisposableFileWriter()); break;
                    case "32": RunTask (new Task32_Temperature()); break;
                    case "33": RunTask (new Task33_LinqEmployees()); break;
                    case "34": RunTask (new Task34_LinqGrouping()); break;
                    case "35": Console.WriteLine("Задание 35 выполнено через Git"); break;
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
