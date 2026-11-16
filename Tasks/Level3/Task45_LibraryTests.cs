using System;
using System.Collections.Generic;
using System.Linq;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level3
{
    /// <summary>
    /// Задание 45: Мини-проект «Библиотека» + юнит-тесты.
    /// </summary>
    public class Task45_LibraryTests : ITask
    {
        public string Title => "Мини-проект «Библиотека» + юнит-тесты";
        public string Description => "Классы библиотеки + тесты.";
        public string[] Requirements => new[] {
            "Классы: Book (Title, Author, IsAvailable), Reader (Name, BorrowedBooks), Library (выдача/возврат).",
            "Логика: выдача книги читателю, возврат, лимит (не больше 3 книг на читателя).",
            "Обработка: книгу уже выдали, лимит превышен — бросать исключения.",
            "Написать 5+ юнит-тестов (xUnit/NUnit) на ключевые сценарии.",
            "Все тесты должны проходить."
        };

        public void Run()
        {
            // Демонстрация работы
            var library = new Library();
            var book1 = new Book("C#", "Author");
            var book2 = new Book("Java", "Author");
            var reader = new Reader("John");

            library.AddBook(book1);
            library.AddBook(book2);

            library.Borrow(reader, book1);
            Console.WriteLine($"John взял: {book1.Title}");

            try
            {
                library.Borrow(reader, book1); // Ошибка: уже выдана
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public bool IsAvailable { get; private set; } = true;

        public Book(string title, string author) { Title = title; Author = author; }
        public void MarkBorrowed() => IsAvailable = false;
        public void MarkReturned() => IsAvailable = true;
    }

    public class Reader
    {
        public string Name { get; }
        public List<Book> BorrowedBooks { get; } = new List<Book>();
        public Reader(string name) { Name = name; }
    }

    public class Library
    {
        private readonly List<Book> _books = new List<Book>();

        public void AddBook(Book book) => _books.Add(book);

        public void Borrow(Reader reader, Book book)
        {
            if (!book.IsAvailable) throw new Exception("Книга уже выдана!");
            if (reader.BorrowedBooks.Count >= 3) throw new Exception("Лимит: не более 3 книг на читателя!");

            book.MarkBorrowed();
            reader.BorrowedBooks.Add(book);
        }

        public void Return(Reader reader, Book book)
        {
            if (!reader.BorrowedBooks.Contains(book)) throw new Exception("Этот читатель не брал эту книгу!");

            book.MarkReturned();
            reader.BorrowedBooks.Remove(book);
        }
    }
}