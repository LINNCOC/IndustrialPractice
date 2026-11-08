using System;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level2
{
    /// <summary>
    /// Задание 29: Паттерн «Фабрика» (уведомления).
    /// </summary>
    public class Task29_FactoryPattern : ITask
    {
        public string Title => "Паттерн «Фабрика» (уведомления)";
        public string Description => "Реализовать фабрику уведомлений.";
        public string[] Requirements => new[] {
            "Интерфейс INotification с методом Send(string message).",
            "Реализации: EmailNotification, SmsNotification, PushNotification.",
            "NotificationFactory.Create(NotificationType type) — возвращает нужную реализацию.",
            "enum NotificationType { Email, Sms, Push }.",
            "Продемонстрировать создание и отправку через фабрику."
        };

        public void Run()
        {
            var email = NotificationFactory.Create(NotificationType.Email);
            email.Send("Привет по почте!");

            var sms = NotificationFactory.Create(NotificationType.Sms);
            sms.Send("Привет по SMS!");

            var push = NotificationFactory.Create(NotificationType.Push);
            push.Send("Привет через Push!");
        }
    }

    public interface INotification
    {
        void Send(string message);
    }

    public class EmailNotification : INotification
    {
        public void Send(string message) => Console.WriteLine($"[Email] {message}");
    }

    public class SmsNotification : INotification
    {
        public void Send(string message) => Console.WriteLine($"[SMS] {message}");
    }

    public class PushNotification : INotification
    {
        public void Send(string message) => Console.WriteLine($"[Push] {message}");
    }

    public enum NotificationType { Email, Sms, Push }

    public static class NotificationFactory
    {
        public static INotification Create(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.Email: return new EmailNotification();
                case NotificationType.Sms: return new SmsNotification();
                case NotificationType.Push: return new PushNotification();
                default: throw new ArgumentException("Неизвестный тип уведомления");
            }
        }
    }
}