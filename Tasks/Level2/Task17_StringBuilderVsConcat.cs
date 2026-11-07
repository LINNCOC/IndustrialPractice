using industrialpractice.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace industrialpractice.Tasks.Level2
{
    /// <summary>
    /// Задание 17: `StringBuilder` vs конкатенация.
    /// </summary>
    internal class Task17_StringBuilderVsConcat : ITask
    {
        public string Title => "`StringBuilder` vs конкатенация (замер)";

        public string Description => "Сравнить производительность конкатенации через `+` и `StringBuilder`. ";

        public string[] Requirements => new[] {"Собрать строку из 10 000 (или 100 000) чисел двумя способами.",
        "Замерить время каждого через `Stopwatch`.",
        "Вывести оба времени и разницу.",
        "Объяснить в комментарии, почему `StringBuilder` быстрее."};

        public void Run()
        {
            int count = 10000;

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();

            string resultConcat = "";
            for (int i = 0; i < count; i++)
            {
                resultConcat += i.ToString();
            }

            sw1.Stop();
            Console.WriteLine($"Конкатенация (+): {sw1.ElapsedMilliseconds} мс");

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append(i);
            }
            string resultSb = sb.ToString();

            sw2.Stop();
            Console.WriteLine($"StringBuilder: {sw2.ElapsedMilliseconds} мс");

            Console.WriteLine($"\nРазница: {sw1.ElapsedMilliseconds - sw2.ElapsedMilliseconds} мс");
            Console.WriteLine($"Результаты равны: {resultConcat == resultSb}");

            /*
            Почему StringBuilder быстрее?
            Строки в C# неизменяемы. Когда мы делаем "result += i.ToString()",
            мы каждый раз создаем НОВУЮ строку в куче и копируем туда старую.
            На 10 000 итераций это создает 10 000 мусорных строк, которые потом удаляет сборщик мусора.
            StringBuilder же хранит внутри себя изменяемый массив символов (буфер).
            Он просто дописывает символы в конец этого массива, не создавая новых объектов.
            StringBuilder в десятки (а то и сотни) раз быстрее при частых изменениях строки.
            */
        }
    }
}
