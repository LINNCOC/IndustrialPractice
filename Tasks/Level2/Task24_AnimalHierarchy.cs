using System;
using System.Collections.Generic;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level2
{
    /// <summary>
    /// Задание 24: ООП: Animal → Dog/Cat/Bird.
    /// </summary>
    public class Task24_AnimalHierarchy : ITask
    {
        public string Title => "ООП: Animal → Dog/Cat/Bird";
        public string Description => "Построить иерархию животных.";
        public string[] Requirements => new[] {
            "Абстрактный класс Animal: свойство Name, абстрактный метод MakeSound(), переопределённый ToString().",
            "Классы Dog, Cat, Bird — наследники, реализуют MakeSound().",
            "Bird дополнительно имеет метод Fly().",
            "Продемонстрировать полиморфизм: List<Animal> с разными животными, вызов MakeSound() в цикле."
        };

        public void Run()
        {
            List<Animal> animals = new List<Animal>
            {
                new Dog { Name = "Шарик" },
                new Cat { Name = "Мурка" },
                new Bird { Name = "Кеша" }
            };

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
                animal.MakeSound();

                if (animal is Bird bird)
                {
                    bird.Fly();
                }
                Console.WriteLine();
            }
        }
    }

    public abstract class Animal
    {
        public string Name { get; set; }
        public abstract void MakeSound();
        public override string ToString() => $"Животное: {Name}";
    }

    public class Dog : Animal
    {
        public override void MakeSound() => Console.WriteLine("Гав-гав!");
    }

    public class Cat : Animal
    {
        public override void MakeSound() => Console.WriteLine("Мяу-мяу!");
    }

    public class Bird : Animal
    {
        public override void MakeSound() => Console.WriteLine("Чирик-чирик!");
        public void Fly() => Console.WriteLine("Я лечу!");
    }
}