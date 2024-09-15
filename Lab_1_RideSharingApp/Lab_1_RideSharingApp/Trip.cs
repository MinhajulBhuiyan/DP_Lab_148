using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_RideSharingApp
{
    public class Trip
    {
        public int Id { get; set; }
        public string PickupLocation { get; set; }
        public string DropOffLocation { get; set; }
        public RideType RideType { get; set; }
        public double Fare { get; set; }
        public double Distance { get; set; }
        public Driver Driver { get; private set; }
        public string Status { get; private set; }

        public Trip(int id, string pickupLocation, string dropOffLocation, RideType rideType, double distance)
        {
            Id = id;
            PickupLocation = pickupLocation;
            DropOffLocation = dropOffLocation;
            RideType = rideType;
            Distance = distance;
            Fare = CalculateFare();
            Status = "Requested";
        }

        public double CalculateFare()
        {
            // Fare calculation logic based on distance, ride type, and time of day.
            return Distance * 10; // Example logic
        }

        public void AssignDriver(Driver driver)
        {
            Driver = driver;
            Status = "Driver Assigned";
        }

        public void StartTrip()
        {
            Status = "In Progress";
            Console.WriteLine("Trip has started.");
        }

        public void CompleteTrip()
        {
            Status = "Completed";
            Console.WriteLine("Trip has been completed.");
        }
    }

}
