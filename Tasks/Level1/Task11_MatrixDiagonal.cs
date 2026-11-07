using System;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level1
{
    /// <summary>
    /// Задание 11: Сумма элементов главной диагонали матрицы.
    /// </summary>
    public class Task11_MatrixDiagonal : ITask
    {
        public string Title => "Диагональ матрицы N×N";
        public string Description => "Найти сумму элементов главной диагонали матрицы N×N.";
        public string[] Requirements => new[] { "Размер N вводится пользователем (минимум 2)", "Матрица заполняется случайными числами", "Сумма считается без LINQ, в одном цикле for", "Вывести саму матрицу и сумму" };

        public void Run()
        {
            Console.Write("Введите размер матрицы N (минимум 2): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 2)
            {
                Console.WriteLine("Ошибка: N должно быть целым числом >= 2.");
                return;
            }

            int[,] matrix = new int[n, n];
            Random rnd = new Random();
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rnd.Next(1, 10);
                    Console.Write($"{matrix[i, j],3}");
                }
                Console.WriteLine();
                sum += matrix[i, i]; 
            }

            Console.WriteLine($"\nСумма элементов главной диагонали: {sum}");
        }
    }
}