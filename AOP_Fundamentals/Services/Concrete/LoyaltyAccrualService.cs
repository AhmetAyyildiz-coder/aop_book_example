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
        var rentalTimeSpan =
            (agreement.EndDate.Subtract(agreement.StartDate));
        var numberOfDays = (int) Math.Floor(rentalTimeSpan.TotalDays);
        var pointsPerDay = 1;
        if (agreement.Vehicle.Size >= Size.Luxury)
            pointsPerDay = 2;
        var points = numberOfDays*pointsPerDay;
        _loyaltyDataService.AddPoints(agreement.Customer.Id, points);
    }
}