using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_RideSharingApp
{
    public class Rider : User
    {
        public IPaymentMethod PreferredPaymentMethod { get; set; }

        public Rider(int id, string name, string location, IPaymentMethod preferredPaymentMethod)
            : base(id, name, location)
        {
            PreferredPaymentMethod = preferredPaymentMethod;
        }

        public void RequestRide(string pickupLocation, string dropOffLocation, RideType rideType)
        {
            // Logic to request a ride
            Console.WriteLine($"{Name} has requested a {rideType} ride from {pickupLocation} to {dropOffLocation}.");
        }

        public void RateDriver(Driver driver, double rating)
        {
            driver.UpdateRating(rating);
            Console.WriteLine($"{Name} rated {driver.Name} with {rating} stars.");
        }

        public void MakePayment(Trip trip)
        {
            PreferredPaymentMethod.ProcessPayment(trip.Fare);
        }

        // New method to change the payment method dynamically
        public void ChangePaymentMethod(IPaymentMethod newMethod)
        {
            PreferredPaymentMethod = newMethod;
            Console.WriteLine($"{Name} has switched to a new payment method.");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Rider: {Name}, Location: {Location}, Rating: {Rating}");
        }
    }

}
