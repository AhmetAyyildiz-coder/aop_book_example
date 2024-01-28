using AOP_Fundamentals.Aspects.Postsharps;
using AOP_Fundamentals.CrossCuttings.Abstract;
using AOP_Fundamentals.Entities;
using AOP_Fundamentals.Repository.Abstract;
using AOP_Fundamentals.Services.Abstract;

namespace AOP_Fundamentals.Services.Concrete;

public class LoyaltyRedemptionServiceRefactored : ILoyaltyRedemptionService
{
    readonly ILoyaltyDataService _dataService;

    public LoyaltyRedemptionServiceRefactored(ILoyaltyDataService dataService)
    {
        _dataService = dataService;
    }

    // new aspect - logging
    [LoggingAspect]
    [ExceptionAspect]
    [DefensiveProgrammingAspect]
    [TransactionalAspect]
    public void Redeem(Invoice invoice, int numberOfDays)
    {
        var pointsPerDay = 10;
        if (invoice.Vehicle.Size >= Size.Luxury)
            pointsPerDay = 15;
        var points = numberOfDays * pointsPerDay;
        _dataService.SubtractPoints(
            invoice.Customer.Id, points);
        invoice.Discount =
            numberOfDays * invoice.CostPerDay;
    }
}