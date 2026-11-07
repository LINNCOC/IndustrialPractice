using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level1
{
    /// <summary>
    /// Задание 1: Вывод приветствия и текущей даты.
    /// </summary>
    public class Task01_HelloWorld : ITask
    {
        /// <summary>
        /// Название задания.
        /// </summary>
        public string Title => "Hello, World + текущая дата";
        /// <summary>
        /// Описание задания.
        /// </summary>
        public string Description => "Вывести приветствие и текущую дату";
        /// <summary>
        /// Требования к заданию.
        /// </summary>
        public string[] Requirements => new[] { "Использовать Console.WriteLine", 
            "отформатировать как `dd.MM.yyyy`", 
            "Вывести две строки: приветствие и дату" };
        /// <summary>
        /// Запуск задания.
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Hello, World"); 
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt.ToString("dd.MM.yyyy"));
        }
    }
}
