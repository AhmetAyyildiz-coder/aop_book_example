using System.Transactions;
using AOP_Fundamentals.Entities;
using AOP_Fundamentals.Repository.Abstract;
using AOP_Fundamentals.Services.Abstract;

namespace AOP_Fundamentals.Services.Concrete;




public class LoyaltyAccrualService : ILoyaltyAccrualService
{
    private  ILoyaltyDataService  _loyaltyDataService;

    public LoyaltyAccrualService(ILoyaltyDataService loyaltyDataService)
    {
        _loyaltyDataService = loyaltyDataService;
    }

    public void Accrue(RentalAgreement agreement) {
        // defensive programming
        if(agreement == null) throw new ArgumentNullException("agreement");
        
        // logging
        Console.WriteLine("Accrue: {0}", DateTime.Now);
        Console.WriteLine("Customer: {0}", agreement.Customer.Id);
        Console.WriteLine("Vehicle: {0}", agreement.Vehicle.Id);
        
        //transaction imp.
        using (var scope = new TransactionScope()) {
            try {
                var rentalTime =
                    (agreement.EndDate.Subtract(agreement.StartDate));var numberOfDays = (int) Math.Floor(rentalTime.TotalDays);
                var pointsPerDay = 1;
                if (agreement.Vehicle.Size >= Size.Luxury)
                    pointsPerDay = 2;
                var points = numberOfDays*pointsPerDay;
                _loyaltyDataService.AddPoints(agreement.Customer.Id, points);
                scope.Complete();
            }
            catch {
                throw;
            }
        }
        // logging
        Console.WriteLine("Accrue complete: {0}", DateTime.Now);
    }
}