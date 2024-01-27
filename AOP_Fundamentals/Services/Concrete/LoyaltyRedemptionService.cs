using AOP_Fundamentals.Entities;
using AOP_Fundamentals.Repository.Abstract;
using AOP_Fundamentals.Services.Abstract;

namespace AOP_Fundamentals.Services.Concrete;

public class LoyaltyRedemptionService : ILoyaltyRedemptionService
{
    readonly ILoyaltyDataService _loyaltyDataService;

    public LoyaltyRedemptionService(ILoyaltyDataService loyaltyDataService)
    {
        _loyaltyDataService = loyaltyDataService;
    }

    public void Redeem(Invoice invoice, int numberOfDays)
    {
        var pointsPerDay = 10;
        if (invoice.Vehicle.Size >= Size.Luxury)
            pointsPerDay = 15;
        var points = numberOfDays*pointsPerDay;
        _loyaltyDataService.SubtractPoints(invoice.Customer.Id, points);
        invoice.Discount = numberOfDays * invoice.CostPerDay;
    }
}