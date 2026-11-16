using System;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level3
{
    /// <summary>
    /// Задание 43: Множественные типы исключений, порядок catch.
    /// </summary>
    public class Task43_ExceptionHierarchy : ITask
    {
        public string Title => "Множественные типы исключений, порядок catch";
        public string Description => "Продемонстрировать порядок обработки исключений.";
        public string[] Requirements => new[] {
            "Метод, который может бросить FormatException, DivideByZeroException или свой CustomException.",
            "Несколько catch-блоков в правильном порядке (от частного к общему).",
            "Продемонстрировать все три сценария.",
            "В конце — finally с выводом «завершено».",
            "Объяснить в комментарии, почему порядок catch важен."
        };

        public void Run()
        {
            Console.WriteLine("--- Тест 1: FormatException ---");
            TestException("abc");

            Console.WriteLine("\n--- Тест 2: DivideByZeroException ---");
            TestException("0");

            Console.WriteLine("\n--- Тест 3: CustomException ---");
            TestException("-1");
        }

        private void TestException(string input)
        {
            try
            {
                int num = int.Parse(input); 
                if (num == 0) throw new DivideByZeroException("На ноль делить нельзя!");
                if (num < 0) throw new CustomException("Отрицательное число запрещено!");

                Console.WriteLine($"Успешно: {num}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Поймано FormatException: введено не число.");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Поймано DivideByZeroException: {ex.Message}");
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"Поймано CustomException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Поймано общее Exception: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Блок finally: завершено.");
            }
        }
    }

    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }
}