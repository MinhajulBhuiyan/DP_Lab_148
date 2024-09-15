using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_RideSharingApp
{
    public class DigitalWalletPayment : IPaymentMethod
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing digital wallet payment of {amount}");
        }
    }
}
