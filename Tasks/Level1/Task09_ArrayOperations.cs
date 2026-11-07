using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using industrialpractice.Common;


namespace industrialpractice.Tasks.Level1
{
    /// <summary>
    /// Задание 9: Массивы: min/max/sum/avg.
    /// </summary>
    public class Task09_ArrayOperations : ITask
    {
        /// <summary>
        /// Название задания.
        /// </summary>
        public string Title => "Массивы: min/max/sum/avg";
        /// <summary>
        /// Описание задания.
        /// </summary>
        public string Description => "Для массива чисел найти минимум, максимум, сумму и среднее.";
        /// <summary>
        /// Требования к заданию.
        /// </summary>
        public string[] Requirements => new[] { "Заполнить массив (например, случайными числами 1–100, размер 20)",
            "Реализовать **без LINQ** (`Min/Max/Sum/Average` запрещены)",
            "Оформить 4 отдельных метода.",
            "Пустой массив — обработать (вернуть ошибку или 0, но не падать)."};
        /// <summary>
        /// Запуск задания.
        /// </summary>
        public void Run()
        {
            int[] array = new int[20];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 101); 
            }

            Console.WriteLine("Исходный массив:");
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine();

            Console.WriteLine($"Минимум: {FindMin(array)}");
            Console.WriteLine($"Максимум: {FindMax(array)}");
            Console.WriteLine($"Сумма: {FindSum(array)}");
            Console.WriteLine($"Среднее арифметическое: {FindAverage(array)}");
        }
        private int FindMin(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0; 
            int min = arr[0];
            foreach (int num in arr)
            {
                if (num < min) min = num;
            }
            return min;
        }
        private int FindMax(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;
            int max = arr[0];
            foreach (int num in arr)
            {
                if (num > max) max = num;
            }
            return max;
        }
        private int FindSum(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;

            int sum = 0;
            foreach (int num in arr)
            {
                sum += num;
            }
            return sum;
        }
        private double FindAverage(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;
            int sum = FindSum(arr);
            return (double)sum / arr.Length;
        }
    }
}
