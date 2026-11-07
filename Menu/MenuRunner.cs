using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using industrialpractice.Menu;

namespace industrialpractice.Menu
{
    /// <summary>
    /// Класс, отвечающий за запуск и работу главного меню.
    /// </summary>
    public class MenuRunner
    {
        /// <summary>
        /// Запускает главное меню приложения.
        /// </summary>
        public void Run()
        {
            var levelMenu = new LevelMenu();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Практикум по C# ===");
                Console.WriteLine("1. Уровень 1 — Базовый (задания 1–15)");
                Console.WriteLine("2. Уровень 2 — Средний (задания 16–35)");
                Console.WriteLine("3. Уровень 3 — Продвинутый (задания 36–50)");
                Console.WriteLine("4. Выход");
                Console.Write("Выберите уровень: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        levelMenu.ShowLevel1Menu();
                        break;
                    case "2":
                        Console.WriteLine("В разработке");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("В разработке");
                        Console.ReadKey();
                        break;
                    case "4":
                        return; 
                    default:
                        Console.WriteLine("Неверный выбор");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
