using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level1
{
    /// <summary>
    /// Задание 2: Примитивные типы.
    /// </summary>
    public class Task02_Primitives : ITask
    {
     /// <summary>
     /// Название задания.
     /// </summary>
    public string Title => "Переменные примитивных типов";
    /// <summary>
    /// Описание задания.
    /// </summary>
    public string Description => "Объявить переменные всех примитивных типов и вывести их значения и типы.";
    /// <summary>
    /// Требования к заданию.
    /// </summary>
    public string[] Requirements => new[] { "Объявить минимум: `int`, `long`, `double`, `float`, `decimal`, `bool`, `char`, `string`",
        "Для каждой переменной вывести значение и `GetType().Name`",
        "`decimal` — с суффиксом `m`, `float` — с `f`" };
    /// <summary>
    /// Запуск задания.
    /// </summary>
        public void Run()
        {
            int i = 2;
            long l = 5;
            double d = 4.3;
            float f = 3.4f;
            decimal dec = 21431414m;
            bool b = true;
            char c = 'A';
            string str = "string";

            object[] data = { i, l, d, f, dec, b, c, str };
            foreach(var item in data)
            {
                Console.WriteLine($"Тип объекта: {item.GetType().Name}, значение: {item}");
            }
        }
    }
}
