using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_Bank_Account_Command_Pattern
{
    public class Program
    {
        static void Main()
        {
            Dictionary<string, BankAccount> accounts = new Dictionary<string, BankAccount>();

            while (true)
            {
                Console.WriteLine("\n1. Create Account\n2. Deposit\n3. Withdraw\n4. Show Balance\n5. Show Transaction History\n6. Transfer\n7. Exit");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 7) break;

                Console.Write("Enter Account Number: ");
                string accountNumber = Console.ReadLine();

                ICommand command = null;
                IQuery<decimal> balanceQuery = null;
                IQuery<List<Transaction>> transactionQuery = null;

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Initial Deposit: ");
                        decimal initialDeposit = decimal.Parse(Console.ReadLine());
                        command = new CreateAccountCommand(accountNumber, initialDeposit, accounts);
                        break;

                    case 2:
                        Console.Write("Enter Deposit Amount: ");
                        decimal depositAmount = decimal.Parse(Console.ReadLine());
                        command = new DepositCommand(accountNumber, depositAmount, accounts);
                        break;

                    case 3:
                        Console.Write("Enter Withdrawal Amount: ");
                        decimal withdrawalAmount = decimal.Parse(Console.ReadLine());
                        command = new WithdrawCommand(accountNumber, withdrawalAmount, accounts);
                        break;

                    case 4:
                        balanceQuery = new GetBalanceQuery(accountNumber, accounts);
                        break;

                    case 5:
                        transactionQuery = new GetTransactionHistoryQuery(accountNumber, accounts);
                        break;

                    case 6:
                        Console.Write("Enter Destination Account Number: ");
                        string destinationAccountNumber = Console.ReadLine();
                        Console.Write("Enter Transfer Amount: ");
                        decimal transferAmount = decimal.Parse(Console.ReadLine());
                        command = new TransferCommand(accountNumber, destinationAccountNumber, transferAmount, accounts);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        continue;
                }

                // Execute the command or query
                command?.Execute();
                if (balanceQuery != null)
                {
                    Console.WriteLine($"Current Balance: {balanceQuery.Execute():C}");
                }
                if (transactionQuery != null)
                {
                    var history = transactionQuery.Execute();
                    foreach (var transaction in history)
                    {
                        Console.WriteLine(transaction);
                    }
                }
            }

            Console.WriteLine("Exiting the banking system.");
        }
    }
}
