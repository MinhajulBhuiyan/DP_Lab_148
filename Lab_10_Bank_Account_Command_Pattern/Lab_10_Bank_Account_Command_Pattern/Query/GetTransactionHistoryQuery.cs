using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_Bank_Account_Command_Pattern
{
    class GetTransactionHistoryQuery : IQuery<List<Transaction>>
    {
        private readonly string _accountNumber;
        private readonly Dictionary<string, BankAccount> _accounts;

        public GetTransactionHistoryQuery(string accountNumber, Dictionary<string, BankAccount> accounts)
        {
            _accountNumber = accountNumber;
            _accounts = accounts;
        }

        public List<Transaction> Execute()
        {
            if (_accounts.ContainsKey(_accountNumber))
            {
                return _accounts[_accountNumber].GetTransactionHistory();
            }
            Console.WriteLine("Account not found.");
            return new List<Transaction>();
        }
    }
}
