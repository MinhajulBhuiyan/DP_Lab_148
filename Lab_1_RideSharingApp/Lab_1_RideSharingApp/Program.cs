using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_RideSharingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create Payment Methods
            IPaymentMethod creditCardPayment = new CreditCardPayment();
            IPaymentMethod paypalPayment = new PayPalPayment();
            IPaymentMethod digitalWalletPayment = new DigitalWalletPayment();

            // Create a Rider with an initial payment method
            Rider rider = new Rider(1, "Rifaf", "Gazipur", creditCardPayment);
            rider.DisplayInfo();

            // Create a Driver
            Driver driver = new Driver(2, "Alif", "Gazipur", "Sedan");
            driver.DisplayInfo();

            // Create a Trip
            Trip trip = new Trip(101, "Gazipur", "Airport", RideType.Luxury, 15);
            Console.WriteLine($"Trip created: From {trip.PickupLocation} to {trip.DropOffLocation}, Fare: {trip.Fare}");

            // Rider requests a ride
            rider.RequestRide("Downtown", "Airport", RideType.Luxury);

            // Driver accepts the ride
            driver.AcceptRide(trip);

            // Start and complete the trip
            driver.StartTrip(trip);
            driver.CompleteTrip(trip);

            // Rider makes payment using the initial payment method (Credit Card)
            rider.MakePayment(trip);

            // Simulating a runtime payment method change
            Console.WriteLine("\n--- Rider wants to change the payment method to PayPal ---");
            rider.ChangePaymentMethod(paypalPayment);

            // Rider makes payment again using the new payment method (PayPal)
            rider.MakePayment(trip);

            // Further Simulating a runtime change to Digital Wallet
            Console.WriteLine("\n--- Rider wants to change the payment method to Digital Wallet ---");
            rider.ChangePaymentMethod(digitalWalletPayment);

            // Rider makes payment using the new method (Digital Wallet)
            rider.MakePayment(trip);

            // Ratings
            rider.RateDriver(driver, 4.5);
            driver.RateRider(rider, 5);

            // Create Admin
            Admin admin = new Admin(3, "Minhaj");
            admin.DisplayInfo();
            admin.ViewTripHistory(trip);

            Console.ReadLine();
        }
    }

}
