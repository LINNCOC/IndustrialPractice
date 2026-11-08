using System;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level2
{
    /// <summary>
    /// Задание 19: Свой стек/очередь на массиве.
    /// </summary>
    public class Task19_MyCollections : ITask
    {
        public string Title => "Свой стек/очередь на массиве";
        public string Description => "Реализовать MyStack<T> и MyQueue<T> на массиве.";
        public string[] Requirements => new[] {
            "Стек: Push, Pop, Peek, Count, IsEmpty.",
            "Очередь: Enqueue, Dequeue, Peek, Count, IsEmpty.",
            "При переполнении — расширять внутренний массив (удвоение).",
            "Pop/Dequeue на пустой коллекции — бросать InvalidOperationException."
        };

        public void Run()
        {
            var stack = new MyStack<int>();
            stack.Push(1); stack.Push(2); stack.Push(3);
            Console.WriteLine($"Стек: Pop={stack.Pop()}, Peek={stack.Peek()}, Count={stack.Count}");

            var queue = new MyQueue<string>();
            queue.Enqueue("A"); queue.Enqueue("B"); queue.Enqueue("C");
            Console.WriteLine($"Очередь: Dequeue={queue.Dequeue()}, Peek={queue.Peek()}, Count={queue.Count}");

            try
            {
                var emptyStack = new MyStack<int>();
                emptyStack.Pop();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Ожидаемая ошибка: {e.Message}");
            }
        }
    }

    /// <summary>
    /// Свой стек.
    /// </summary>
    public class MyStack<T>
    {
        private T[] _items = new T[4];
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public void Push(T item)
        {
            if (Count == _items.Length)
                Array.Resize(ref _items, _items.Length * 2);
            _items[Count++] = item;
        }

        public T Pop()
        {
            if (IsEmpty) throw new InvalidOperationException("Стек пуст");
            return _items[--Count];
        }

        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Стек пуст");
            return _items[Count - 1];
        }
    }

    /// <summary>
    /// Своя очередь.
    /// </summary>
    public class MyQueue<T>
    {
        private T[] _items = new T[4];
        private int _head = 0;
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public void Enqueue(T item)
        {
            if (Count == _items.Length)
            {
                var newItems = new T[_items.Length * 2];
                for (int i = 0; i < Count; i++)
                    newItems[i] = _items[(_head + i) % _items.Length];
                _items = newItems;
                _head = 0;
            }
            _items[(_head + Count) % _items.Length] = item;
            Count++;
        }

        public T Dequeue()
        {
            if (IsEmpty) throw new InvalidOperationException("Очередь пуста");
            T item = _items[_head];
            _head = (_head + 1) % _items.Length;
            Count--;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Очередь пуста");
            return _items[_head];
        }
    }
}