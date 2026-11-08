using System;
using System.IO;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level2
{
    /// <summary>
    /// Задание 31: IDisposable + using.
    /// </summary>
    public class Task31_DisposableFileWriter : ITask
    {
        public string Title => "IDisposable + using";
        public string Description => "Реализовать IDisposable для класса, работающего с файлом.";
        public string[] Requirements => new[] {
            "Класс FileWriter с полем StreamWriter.",
            "Реализовать Dispose() (закрыть StreamWriter).",
            "Продемонстрировать использование через using.",
            "Дополнительно: продемонстрировать using-декларацию (C# 8+, using var)."
        };

        public void Run()
        {
            string path = "test_file.txt";

            using (var writer = new FileWriter(path))
            {
                writer.WriteLine("Привет из using!");
            }
            Console.WriteLine("Файл записан через классический using. Стрим закрыт.");

            string content = File.ReadAllText(path);
            Console.WriteLine($"Содержимое файла: {content}");

            File.Delete(path);
        }
    }

    public class FileWriter : IDisposable
    {
        private StreamWriter _streamWriter;
        private bool _disposed = false;

        public FileWriter(string path)
        {
            _streamWriter = new StreamWriter(path);
        }

        public void WriteLine(string text)
        {
            _streamWriter.WriteLine(text);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _streamWriter?.Dispose();
                _disposed = true;
            }
        }
    }
}