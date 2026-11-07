using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using industrialpractice.Common;
using System.Diagnostics;


namespace industrialpractice.Tasks.Level1
{
    /// <summary>
    /// Задание 10: Сортировка пузырьком.
    /// </summary>
    public class Task10_BubbleSorting : ITask
    {
        /// <summary>
        /// Название задания.
        /// </summary>
        public string Title => "Сортировка пузырьком + вставками";
        /// <summary>
        /// Описание задания.
        /// </summary>
        public string Description => "Отсортировать массив двумя алгоритмами";
        /// <summary>
        /// Требования к заданию.
        /// </summary>
        public string[] Requirements => new[] { "Реализовать `BubbleSort` и `InsertionSort` отдельными методами",
            "Оба — без LINQ и `Array.Sort`",
            "Замерить время каждого через `Stopwatch` на массиве 10 000 элементов",
            "Вывести оба времени"};
        /// <summary>
        /// Запуск задания.
        /// </summary>
        public void Run()
        {
            int size = 10000;
            Random rnd = new Random();

            int[] array1 = new int[size];
            int[] array2 = new int[size];

            for (int i = 0; i < size; i++)
            {
                int num = rnd.Next(1, 10000);
                array1[i] = num;
                array2[i] = num;
            }

            Console.WriteLine($"Массив из {size} элементов создан. Начинаем сортировку...\n");

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            BubbleSort(array1);
            sw1.Stop();
            Console.WriteLine($"BubbleSort: {sw1.ElapsedMilliseconds} мс");

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            InsertionSort(array2);
            sw2.Stop();
            Console.WriteLine($"InsertionSort: {sw2.ElapsedMilliseconds} мс");

            bool isEqual = true;
            for (int i = 0; i < size; i++)
            {
                if (array1[i] != array2[i])
                {
                    isEqual = false;
                    break;
                }
            }
            Console.WriteLine(isEqual ? "\nОба массива отсортированы одинаково." : "\nОшибка: массивы отличаются.");
        }
        private void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        private void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }
    }
}
