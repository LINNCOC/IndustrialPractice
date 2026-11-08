using System;
using industrialpractice.Common;

namespace industrialpractice.Tasks.Level2
{
    /// <summary>
    /// Задание 30: BankAccount + свой Exception.
    /// </summary>
    public class Task30_BankAccount : ITask
    {
        public string Title => "BankAccount + свой Exception";
        public string Description => "Реализовать банковский счёт с собственным исключением.";
        public string[] Requirements => new[] {
            "Класс BankAccount с приватным балансом.",
            "Методы Deposit(decimal), Withdraw(decimal).",
            "Свой класс InsufficientFundsException : Exception.",
            "Withdraw бросает исключение, если сумма больше баланса.",
            "Продемонстрировать: успешное снятие и попытку снять больше баланса (с try/catch)."
        };

        public void Run()
        {
            var account = new BankAccount();
            account.Deposit(1000m);
            Console.WriteLine($"Баланс после депозита: {account.Balance}");

            try
            {
                account.Withdraw(500m);
                Console.WriteLine($"Успешно снято 500. Баланс: {account.Balance}");

                account.Withdraw(2000m); 
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }

    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new InsufficientFundsException($"Недостаточно средств. Баланс: {Balance}, запрошено: {amount}");

            Balance -= amount;
        }
    }
}