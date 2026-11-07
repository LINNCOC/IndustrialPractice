using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using industrialpractice.Common;


namespace industrialpractice.Tasks.Level1
{
    /// <summary>
    /// Задание 7: Реверс строки
    /// </summary>
    public class Task07_StringReverse : ITask
    {
        /// <summary>
        /// Название задания.
        /// </summary>
        public string Title => "Реверс строки без LINQ";
        /// <summary>
        /// Описание задания.
        /// </summary>
        public string Description => "Перевернуть введённую строку";
        /// <summary>
        /// Требования к заданию.
        /// </summary>
        public string[] Requirements => new[] { "Не использовать `Array.Reverse` и LINQ.",
            "Реализовать через цикл `for` от конца к началу (или через `char[]` и swap)",
            "Пустая строка и строка из одного символа — обрабатываются корректно" };
        /// <summary>
        /// Запуск задания.
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Введите любое слово");
            string UserSentence = Console.ReadLine();
            if (string.IsNullOrEmpty(UserSentence))
            {
                Console.WriteLine("Ошибка: строка не может быть пустой.");
                return;
            }
            Console.WriteLine($"Твоя строка: {UserSentence} - {ReverseString(UserSentence)}");
        }
        private string ReverseString(string input)
        {
            string result = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                result += input[i];
            }
            return result;
        }
    }
}
