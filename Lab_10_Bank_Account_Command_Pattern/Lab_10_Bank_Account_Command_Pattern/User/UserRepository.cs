using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_Bank_Account_Command_Pattern
{
    // Repository Pattern for User Management
    class UserRepository
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();

        public void RegisterUser(string userName, string email, string accountNumber, decimal initialDeposit)
        {
            if (users.ContainsKey(userName))
            {
                Console.WriteLine("User already exists!");
                return;
            }
            User newUser = new User(userName, email);
            newUser.BankAccount = new BankAccount(accountNumber, initialDeposit);
            users[userName] = newUser;
            Console.WriteLine("User registered successfully.");
        }

        public User AuthenticateUser(string userName)
        {
            if (users.ContainsKey(userName))
            {
                return users[userName];
            }
            Console.WriteLine("User not found.");
            return null;
        }
    }
}
