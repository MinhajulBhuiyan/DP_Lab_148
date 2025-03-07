using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_Bank_Account_Command_Pattern
{
    class WithdrawCommand : ICommand
    {
        private readonly string _accountNumber;
        private readonly decimal _amount;
        private readonly Dictionary<string, BankAccount> _accounts;

        public WithdrawCommand(string accountNumber, decimal amount, Dictionary<string, BankAccount> accounts)
        {
            _accountNumber = accountNumber;
            _amount = amount;
            _accounts = accounts;
        }

        public void Execute()
        {
            if (_accounts.ContainsKey(_accountNumber))
            {
                var success = _accounts[_accountNumber].Withdraw(_amount);
                if (success)
                {
                    Console.WriteLine($"Withdrew {_amount:C} from account {_accountNumber}");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }
}
