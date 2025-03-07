using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_Bank_Account_Command_Pattern
{
    // Transaction Class
    class Transaction
    {
        public DateTime Date { get; }
        public string Type { get; }
        public decimal Amount { get; }

        public Transaction(string type, decimal amount)
        {
            Date = DateTime.Now;
            Type = type;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{Date}: {Type} {Amount:C}";
        }
    }
}
