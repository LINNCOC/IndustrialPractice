using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level2 
{
    /// <summary>
    /// Задание 16: Методы расширения для `string`.
    /// </summary>
    internal class Task16_StringExtensions : ITask
    {
        public string Title => "Методы расширения для `string`";

        public string Description => "Написать extension-методы для `string`."; 

        public string[] Requirements => new[] {"Реализовать в статическом классе `StringExtensions`.",
        "Методы: `IsPalindrome()`, `WordCount()`, `ReverseString()`.",
        "Методы должны быть `public static` с `this string` первым параметром.",
        "Продемонстрировать вызов на 2–3 строках."}; 

        public void Run()
        {
            string[] samples =
              {
                "А роза упала на лапу Азора",
                "Hello, world!",
                "racecar"
            };

            foreach (string s in samples)
            {
                Console.WriteLine($"Строка: \"{s}\"");
                Console.WriteLine($"  IsPalindrome: {s.IsPalindrome()}");
                Console.WriteLine($"  WordCount:    {s.WordCount()}");
                Console.WriteLine($"  Reverse:      {s.ReverseString()}");
                Console.WriteLine();
            }
        }
    }
    static class StringExtensions
    {
        public static bool IsPalindrome(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            var clean = new StringBuilder();
            foreach (char c in str)
            {
                if (char.IsLetterOrDigit(c))
                    clean.Append(char.ToLowerInvariant(c));
            }

            string s = clean.ToString();
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            }
            return true;
        }

        public static int WordCount(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;

            char[] separators =
                { ' ', '\t', '\n', '\r', '.', ',', '!', '?', ';', ':', '-', '(', ')' };

            return str.Split(separators, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static string ReverseString(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            var chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
