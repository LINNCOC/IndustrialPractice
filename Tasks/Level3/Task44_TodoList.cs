using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level3
{
    /// <summary>
    /// Задание 44: Мини-проект «Todo List» (классы + JSON).
    /// </summary>
    public class Task44_TodoList : ITask
    {
        public string Title => "Мини-проект «Todo List» (классы + JSON)";
        public string Description => "Консольное приложение для списка задач с сохранением в JSON.";
        public string[] Requirements => new[] {
            "Классы: TaskItem (Id, Title, IsDone), TaskRepository (CRUD), TaskService (бизнес-логика).",
            "CRUD-операции: добавить, вывести все, отметить выполненной, удалить.",
            "Сохранение/загрузка через System.Text.Json (файл tasks.json).",
            "Меню с выбором действий.",
            "Обработка ошибок (некорректный ввод, отсутствующий файл)."
        };

        private const string FilePath = "tasks.json";

        public void Run()
        {
            var repo = new TaskRepository(FilePath);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== TODO LIST ===");
                Console.WriteLine("1. Показать все задачи");
                Console.WriteLine("2. Добавить задачу");
                Console.WriteLine("3. Отметить выполненной");
                Console.WriteLine("4. Удалить задачу");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        var tasks = repo.GetAll();
                        if (!tasks.Any()) Console.WriteLine("Список пуст.");
                        foreach (var t in tasks) Console.WriteLine($"[{t.Id}] {(t.IsDone ? "✅" : "❌")} {t.Title}");
                        break;
                    case "2":
                        Console.Write("Введите название: ");
                        repo.Add(Console.ReadLine());
                        Console.WriteLine("Добавлено!");
                        break;
                    case "3":
                        Console.Write("Введите ID: ");
                        if (int.TryParse(Console.ReadLine(), out int id1)) repo.MarkDone(id1);
                        break;
                    case "4":
                        Console.Write("Введите ID: ");
                        if (int.TryParse(Console.ReadLine(), out int id2)) repo.Delete(id2);
                        break;
                    case "0":
                        return;
                }
                Console.ReadKey();
            }
        }
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }

    public class TaskRepository
    {
        private readonly string _path;
        private List<TaskItem> _tasks;

        public TaskRepository(string path)
        {
            _path = path;
            Load();
        }

        private void Load()
        {
            _tasks = new List<TaskItem>();
            if (!File.Exists(_path)) return;

            string[] lines = File.ReadAllLines(_path);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    _tasks.Add(new TaskItem
                    {
                        Id = int.Parse(parts[0]),
                        Title = parts[1],
                        IsDone = bool.Parse(parts[2])
                    });
                }
            }
        }

        private void Save()
        {
            var lines = new List<string>();
            foreach (var t in _tasks)
            {
                lines.Add($"{t.Id}|{t.Title}|{t.IsDone}");
            }
            File.WriteAllLines(_path, lines);
        }

        public IEnumerable<TaskItem> GetAll()
        {
            return _tasks;
        }

        public void Add(string title)
        {
            int id = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
            _tasks.Add(new TaskItem { Id = id, Title = title, IsDone = false });
            Save();
        }

        public void MarkDone(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsDone = true;
                Save();
            }
        }

        public void Delete(int id)
        {
            _tasks.RemoveAll(t => t.Id == id);
            Save();
        }
    }
}