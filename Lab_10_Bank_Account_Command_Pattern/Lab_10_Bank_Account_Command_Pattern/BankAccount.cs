using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_Bank_Account_Command_Pattern
{
    class BankAccount
    {
        public string AccountNumber { get; }
        private decimal Balance;
        private List<Transaction> Transactions;

        public BankAccount(string accountNumber, decimal initialDeposit)
        {
            AccountNumber = accountNumber;
            Balance = initialDeposit;
            Transactions = new List<Transaction>
        {
            new Transaction("Initial Deposit", initialDeposit)
        };
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Transactions.Add(new Transaction("Deposit", amount));
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                return false; 
            }
            Balance -= amount;
            Transactions.Add(new Transaction("Withdrawal", amount));
            return true;
        }

        public decimal GetBalance() => Balance;

        public List<Transaction> GetTransactionHistory() => Transactions;
    }
}
