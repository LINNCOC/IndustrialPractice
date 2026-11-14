using System;
using System.Collections.Generic;
using System.Diagnostics;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level3
{
    /// <summary>
    /// Задание 38: List<T> vs LinkedList<T> (бенчмарк).
    /// </summary>
    public class Task38_ListVsLinkedList : ITask
    {
        public string Title => "List<T> vs LinkedList<T> (бенчмарк)";
        public string Description => "Сравнить вставку в середину List<T> и LinkedList<T>.";
        public string[] Requirements => new[] {
            "Создать List<int> и LinkedList<int> по 100 000 элементов.",
            "Вставить 1000 элементов в середину каждой коллекции.",
            "Замерить время через Stopwatch.",
            "Вывести оба времени и объяснить результат в комментарии."
        };

        public void Run()
        {
            int count = 100000;
            int inserts = 1000;

            var list = new List<int>(count);
            var linked = new LinkedList<int>();
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
                linked.AddLast(i);
            }

            var sw1 = Stopwatch.StartNew();
            for (int i = 0; i < inserts; i++)
                list.Insert(list.Count / 2, -1);
            sw1.Stop();

            var sw2 = Stopwatch.StartNew();
            var middleNode = linked.First;
            for (int i = 0; i < linked.Count / 2; i++)
                middleNode = middleNode.Next;

            for (int i = 0; i < inserts; i++)
                linked.AddAfter(middleNode, -1);
            sw2.Stop();

            Console.WriteLine($"List<T> вставка: {sw1.ElapsedMilliseconds} мс");
            Console.WriteLine($"LinkedList<T> вставка: {sw2.ElapsedMilliseconds} мс");

            /*
            Почему разница?
            List<T> внутри хранит массив. При вставке в середину ему нужно СДВИНУТЬ все элементы вправо,
            что занимает O(n) времени.
            LinkedList<T> хранит элементы в виде узлов, связанных ссылками. Вставка в середину
            происходит за O(1), если у тебя есть ссылка на нужный узел. НО поиск этого узла занимает O(n).
            */
        }
    }
}