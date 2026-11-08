using System;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level2
{
    /// <summary>
    /// Задание 20: Обобщения: Swap<T>, Max<T> с IComparable<T>.
    /// </summary>
    public class Task20_Generics : ITask
    {
        public string Title => "Обобщения: Swap<T>, Max<T>";
        public string Description => "Написать обобщённые методы.";
        public string[] Requirements => new[] {
            "Swap<T>(ref T a, ref T b) — меняет значения местами.",
            "Max<T>(T a, T b) where T : IComparable<T> — возвращает большее.",
            "Продемонстрировать на int, string, double.",
            "Swap — без ограничений, Max — с ограничением."
        };

        public void Run()
        {
            int a = 5, b = 10;
            Swap(ref a, ref b);
            Console.WriteLine($"Swap int: a={a}, b={b}");

            string s1 = "apple", s2 = "banana";
            Swap(ref s1, ref s2);
            Console.WriteLine($"Swap string: s1={s1}, s2={s2}");

            double d1 = 3.14, d2 = 2.71;
            Swap(ref d1, ref d2);
            Console.WriteLine($"Swap double: d1={d1}, d2={d2}");

            Console.WriteLine($"Max int: {Max(5, 10)}");
            Console.WriteLine($"Max string: {Max("apple", "banana")}");
            Console.WriteLine($"Max double: {Max(3.14, 2.71)}");
        }

        private void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private T Max<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }
}