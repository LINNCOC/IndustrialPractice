using System;
using System.Collections.Generic;
using System.Linq;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level2
{
    /// <summary>
    /// Задание 25: Интерфейс IShape + сортировка фигур.
    /// </summary>
    public class Task25_ShapeSorting : ITask
    {
        public string Title => "Интерфейс IShape + сортировка фигур";
        public string Description => "Реализовать интерфейс фигур и отсортировать их.";
        public string[] Requirements => new[] {
            "IShape с методами Area() и Perimeter().",
            "Классы Circle, Rectangle, Triangle — реализуют IShape.",
            "Создать List<IShape> из 5+ фигур.",
            "Отсортировать по площади (через List.Sort с лямбдой или OrderBy).",
            "Вывести фигуры с площадями до и после сортировки."
        };

        public void Run()
        {
            List<IShape> shapes = new List<IShape>
            {
                new Circle(5), new Rectangle(4, 5), new Triangle(3, 4, 5),
                new Circle(2), new Rectangle(10, 2)
            };

            Console.WriteLine("До сортировки:");
            foreach (var s in shapes) Console.WriteLine(s);

            shapes.Sort((a, b) => a.Area().CompareTo(b.Area()));

            Console.WriteLine("\nПосле сортировки (по возрастанию площади):");
            foreach (var s in shapes) Console.WriteLine(s);
        }
    }

    public interface IShape
    {
        double Area();
        double Perimeter();
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }
        public Circle(double r) { Radius = r; }
        public double Area() => Math.PI * Radius * Radius;
        public double Perimeter() => 2 * Math.PI * Radius;
        public override string ToString() => $"Circle(r={Radius}), Area={Area():F2}";
    }

    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(double w, double h) { Width = w; Height = h; }
        public double Area() => Width * Height;
        public double Perimeter() => 2 * (Width + Height);
        public override string ToString() => $"Rectangle({Width}x{Height}), Area={Area():F2}";
    }

    public class Triangle : IShape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public Triangle(double a, double b, double c) { A = a; B = b; C = c; }
        public double Area()
        {
            double p = Perimeter() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
        public double Perimeter() => A + B + C;
        public override string ToString() => $"Triangle({A},{B},{C}), Area={Area():F2}";
    }
}