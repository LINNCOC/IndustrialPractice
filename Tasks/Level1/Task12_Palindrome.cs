using System;
using industrialpractice.Common;
using System.Text;

namespace industrialpractice.Tasks.Level1
{
    /// <summary>
    /// Задание 12: Проверка на палиндром.
    /// </summary>
    public class Task12_Palindrome : ITask
    {
        public string Title => "Палиндром (без учёта регистра/пробелов)";
        public string Description => "Проверить, является ли строка палиндромом.";
        public string[] Requirements => new[] { "Игнорировать регистр (ToLower/ToUpper)", "Игнорировать пробелы и знаки пунктуации", "Не использовать LINQ Reverse", "Пустая строка и строка из одного символа — палиндром" };

        public void Run()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Пустая строка — это палиндром.");
                return;
            }

            StringBuilder clean = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c))
                {
                    clean.Append(char.ToLower(c));
                }
            }

            string s = clean.ToString();
            bool isPalindrome = true;

            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }

            Console.WriteLine($"Строка «{input}» — это палиндром: {isPalindrome}");
        }
    }
}