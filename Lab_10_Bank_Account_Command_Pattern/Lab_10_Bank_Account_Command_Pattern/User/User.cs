using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_Bank_Account_Command_Pattern
{
    // User Class
    class User
    {
        public string UserName { get; }
        public string Email { get; }
        public BankAccount BankAccount { get; set; }

        public User(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }
    }
}
