using AOP_Fundamentals.Aspects.Postsharps;
using AOP_Fundamentals.CrossCuttings.Abstract;
using AOP_Fundamentals.Entities;
using AOP_Fundamentals.Repository.Abstract;
using AOP_Fundamentals.Services.Abstract;

namespace AOP_Fundamentals.Services.Concrete;

public class LoyaltyRedemptionServiceRefactored : ILoyaltyRedemptionService
{
    readonly ILoyaltyDataService _dataService;
    readonly IExceptionHandler _exceptionHandler;
    readonly ITransactionManager _transactionManager;

    public LoyaltyRedemptionServiceRefactored(ILoyaltyDataService dataService, IExceptionHandler exceptionHandler, ITransactionManager transactionManager)
    {
        _dataService = dataService;
        _exceptionHandler = exceptionHandler;
        _transactionManager = transactionManager;
    }

    // new aspect - logging
    [LoggingAspect]
    [DefensiveProgrammingAspect]
    public void Redeem(Invoice invoice, int numberOfDays)
    {
        _exceptionHandler.Wrapper(() => {
            _transactionManager.Wrapper(() => {
                var pointsPerDay = 10;
                if (invoice.Vehicle.Size >= Size.Luxury)
                    pointsPerDay = 15;
                var points = numberOfDays*pointsPerDay;
                _dataService.SubtractPoints(
                    invoice.Customer.Id, points);
                invoice.Discount =
                    numberOfDays*invoice.CostPerDay;

            });
        });
    }
}