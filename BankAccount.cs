using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_09._11._2023
{
    // 8.1
    internal class BankAccount
    {
        private decimal balance;
        private string accountType;
        private string accountNumber;

        public BankAccount()
        {
            GenerateAccountNumber();
        }

        public BankAccount(decimal initialBalance)
        {
            balance = initialBalance;
            GenerateAccountNumber();
        }

        public BankAccount(string type)
        {
            accountType = type;
            GenerateAccountNumber();
        }

        public BankAccount(decimal initialBalance, string type)
        {
            balance = initialBalance;
            accountType = type;
            GenerateAccountNumber();
        }

        private string GenerateAccountNumber()
        {
            Random rnd = new Random();
            int number = rnd.Next(100000, 999999); // Генерация случайного шестизначного числа
            return number.ToString();
        }
    }
}
