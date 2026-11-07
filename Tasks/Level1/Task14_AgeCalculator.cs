using System;
using industrialpractice.Common;
using System.Globalization;

namespace industrialpractice.Tasks.Level1
{
    /// <summary>
    /// Задание 14: Вычисление возраста по дате рождения.
    /// </summary>
    public class Task14_AgeCalculator : ITask
    {
        public string Title => "Возраст по дате рождения";
        public string Description => "По дате рождения вычислить точный возраст в годах, месяцах и днях.";
        public string[] Requirements => new[] { "Ввод даты через DateTime.TryParse", "Учесть, что день рождения в этом году мог ещё не наступить", "Вывести «X лет, Y месяцев, Z дней»", "Некорректная дата — сообщение об ошибке, не падать" };

        public void Run()
        {
            Console.Write("Введите дату рождения (дд.мм.гггг): ");
            string input = Console.ReadLine();

            if (!DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate))
            {
                Console.WriteLine("Ошибка: неверный формат даты. Используйте дд.мм.гггг.");
                return;
            }

            DateTime today = DateTime.Today;
            if (birthDate > today)
            {
                Console.WriteLine("Ошибка: дата рождения не может быть в будущем.");
                return;
            }

            int years = today.Year - birthDate.Year;
            int months = today.Month - birthDate.Month;
            int days = today.Day - birthDate.Day;

            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(today.Year, today.Month == 1 ? 12 : today.Month - 1);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            Console.WriteLine($"Возраст: {years} лет, {months} месяцев, {days} дней");
        }
    }
}