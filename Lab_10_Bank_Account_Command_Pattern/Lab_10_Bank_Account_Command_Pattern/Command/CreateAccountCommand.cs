using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_Bank_Account_Command_Pattern
{
    class CreateAccountCommand : ICommand
    {
        private readonly string _accountNumber;
        private readonly decimal _initialDeposit;
        private readonly Dictionary<string, BankAccount> _accounts;

        public CreateAccountCommand(string accountNumber, decimal initialDeposit, Dictionary<string, BankAccount> accounts)
        {
            _accountNumber = accountNumber;
            _initialDeposit = initialDeposit;
            _accounts = accounts;
        }

        public void Execute()
        {
            if (!_accounts.ContainsKey(_accountNumber))
            {
                _accounts[_accountNumber] = new BankAccount(_accountNumber, _initialDeposit);
                Console.WriteLine("Account created successfully.");
            }
            else
            {
                Console.WriteLine("Account already exists.");
            }
        }
    }
}
