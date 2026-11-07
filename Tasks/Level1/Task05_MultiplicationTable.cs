using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using industrialpractice.Common;


namespace industrialpractice.Tasks.Level1
{
    /// <summary>
    /// Задание 5: Таблица умножения.
    /// </summary>
    public class Task05_MultiplicationTable : ITask
    {
        /// <summary>
        /// Название задания.
        /// </summary>
        public string Title => "Таблица умножения 10×10";
        /// <summary>
        /// Описание задания.
        /// </summary>
        public string Description => "Вывести таблицу умножения 10×10.  ";
        /// <summary>
        /// Требования к заданию.
        /// </summary>
        public string[] Requirements => new[] { "Использовать вложенные циклы `for`.",
            "Выровнять столбцы.",
            "Заголовки строк/столбцов — не обязательны, но приветствуются." };
        /// <summary>
        /// Запуск задания.
        /// </summary>
        public void Run()
        {
            for (int i = 1; i <= 10; i++)
            {
                for(int j = 1; j <= 10; j++)
                {
                    Console.Write($"{i * j,4}");
                }
                Console.WriteLine();
            }
        }
    }
}
