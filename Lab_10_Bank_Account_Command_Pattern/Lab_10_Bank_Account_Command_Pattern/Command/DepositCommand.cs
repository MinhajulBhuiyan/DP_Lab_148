using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_Bank_Account_Command_Pattern
{
    class DepositCommand : ICommand
    {
        private readonly string _accountNumber;
        private readonly decimal _amount;
        private readonly Dictionary<string, BankAccount> _accounts;

        public DepositCommand(string accountNumber, decimal amount, Dictionary<string, BankAccount> accounts)
        {
            _accountNumber = accountNumber;
            _amount = amount;
            _accounts = accounts;
        }

        public void Execute()
        {
            if (_accounts.ContainsKey(_accountNumber))
            {
                _accounts[_accountNumber].Deposit(_amount);
                Console.WriteLine($"Deposited {_amount:C} to account {_accountNumber}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }
}
