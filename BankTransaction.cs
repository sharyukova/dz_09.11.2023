using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_09._11._2023
{
    // 8.2
    public class BankTransaction
    {
        public readonly DateTime Date;
        public readonly decimal Amount;

        public BankTransaction(decimal amount)
        {
            Date = DateTime.Now;
            Amount = amount;
        }
    }



    public class bankAccount : IDisposable
    {
        private decimal balance;
        private Queue transactions = new Queue();



        /// <summary>
        /// Метод, отвечающий за перевод на счет 
        /// </summary>
        /// <param name="amount"> сумма, которую переведут на счет </param>
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                BankTransaction transaction = new BankTransaction(amount);
                transactions.Enqueue(transaction);
            }
            else
            {
                Console.WriteLine("Введено не больше нуля. Перевод на счет невозможен!");
            }
        }


        /// <summary>
        /// Метод, отвечающий за снятие со счета 
        /// </summary>
        /// <param name="amount"> сумма, которую снимут со счета </param>
        public void Withdraw(decimal amount)
        {
            if (amount > 0)
            {
                balance -= amount;
                BankTransaction transaction = new BankTransaction(-amount);
                transactions.Enqueue(transaction);
            }
            else 
            {
                Console.WriteLine("Введено число, не больше нуля. Снятие со счета невозможно!");
            }
        }


        // 8.3
        public void Dispose()
        {
            using (StreamWriter writer = new StreamWriter("transactions.txt")) // создание файла
            {
                while (transactions.Count > 0)
                {
                    BankTransaction transaction = (BankTransaction)transactions.Dequeue();
                    writer.WriteLine($"Date: {transaction.Date}, Amount: {transaction.Amount}");
                }
            }
            GC.SuppressFinalize(this);
        }
    }
}
