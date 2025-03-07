using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_Bank_Account_Command_Pattern
{
    class TransferCommand : ICommand
    {
        private readonly string _sourceAccountNumber;
        private readonly string _destinationAccountNumber;
        private readonly decimal _amount;
        private readonly Dictionary<string, BankAccount> _accounts;

        public TransferCommand(string sourceAccountNumber, string destinationAccountNumber, decimal amount, Dictionary<string, BankAccount> accounts)
        {
            _sourceAccountNumber = sourceAccountNumber;
            _destinationAccountNumber = destinationAccountNumber;
            _amount = amount;
            _accounts = accounts;
        }

        public void Execute()
        {
            if (!_accounts.ContainsKey(_sourceAccountNumber))
            {
                Console.WriteLine("Source account not found.");
                return;
            }

            if (!_accounts.ContainsKey(_destinationAccountNumber))
            {
                Console.WriteLine("Destination account not found.");
                return;
            }

            var sourceAccount = _accounts[_sourceAccountNumber];
            var destinationAccount = _accounts[_destinationAccountNumber];

            if (sourceAccount.Withdraw(_amount))
            {
                destinationAccount.Deposit(_amount);
                Console.WriteLine($"Transferred {_amount:C} from account {_sourceAccountNumber} to account {_destinationAccountNumber}");
            }
            else
            {
                Console.WriteLine("Insufficient funds in the source account.");
            }
        }
    }
}
