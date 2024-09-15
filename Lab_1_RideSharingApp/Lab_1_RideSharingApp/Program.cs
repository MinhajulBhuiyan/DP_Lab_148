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
            // Create a Payment Method
            IPaymentMethod paymentMethod = new CreditCardPayment();

            // Create a Rider
            Rider rider = new Rider(1, "Alice", "Downtown", paymentMethod);
            rider.DisplayInfo();

            // Create a Driver
            Driver driver = new Driver(2, "Bob", "Uptown", "Sedan");
            driver.DisplayInfo();

            // Create a Trip
            Trip trip = new Trip(101, "Downtown", "Airport", RideType.Luxury, 15);
            Console.WriteLine($"Trip created: From {trip.PickupLocation} to {trip.DropOffLocation}, Fare: {trip.Fare}");

            // Rider requests a ride
            rider.RequestRide("Downtown", "Airport", RideType.Luxury);

            // Driver accepts the ride
            driver.AcceptRide(trip);

            // Start and Complete Trip
            driver.StartTrip(trip);
            driver.CompleteTrip(trip);

            // Rider makes payment
            rider.MakePayment(trip);

            // Ratings
            rider.RateDriver(driver, 4.5);
            driver.RateRider(rider, 5);

            // Create Admin
            Admin admin = new Admin(3, "Admin Joe");
            admin.DisplayInfo();
            admin.ViewTripHistory(trip);
            Console.ReadLine();
        }
    }

}
