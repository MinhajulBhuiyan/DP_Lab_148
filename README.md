RideSharing Application Class Hierarchy:

1. User
   ├── Rider
   └── Driver

2. Payment Method Interfaces
   ├── IPaymentMethod
   │ ├── CreditCardPayment
   │ ├── PayPalPayment
   │ └── DigitalWalletPayment

3. Services
   ├── PaymentService
   └── TripService

4. Trip
   └── Trip (Contains properties related to the trip such as Fare, Distance, etc.)

5. Enums
   └── RideType
