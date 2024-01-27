using AOP_Fundamentals.CrossCuttings.Abstract;
using AOP_Fundamentals.Entities;
using AOP_Fundamentals.Repository.Abstract;
using AOP_Fundamentals.Services.Abstract;

namespace AOP_Fundamentals.Services.Concrete;

public class LoyaltyAccrualServiceRefactored : ILoyaltyAccrualService
{
    readonly ILoyaltyDataService _dataService;
    readonly IExceptionHandler _exceptionHandler;
    readonly ITransactionManager _transactionManager;

    public LoyaltyAccrualServiceRefactored(ILoyaltyDataService dataService, IExceptionHandler exceptionHandler,
        ITransactionManager transactionManager)
    {
        _dataService = dataService;
        _exceptionHandler = exceptionHandler;
        _transactionManager = transactionManager;
    }

    public void Accrue(RentalAgreement agreement)
    {
        // defensive programming
        if (agreement == null)
            throw new ArgumentNullException("agreement");
        // logging
        Console.WriteLine("Accrue: {0}", DateTime.Now);
        Console.WriteLine("Customer: {0}", agreement.Customer.Id);
        Console.WriteLine("Vehicle: {0}", agreement.Vehicle.Id);
        // exception handling
        _exceptionHandler.Wrapper(() =>
        {
            _transactionManager.Wrapper(() =>
            {
                var rentalTime = (agreement.EndDate
                    .Subtract(agreement.StartDate));
                var numberOfDays =
                    (int)Math.Floor(rentalTime.TotalDays);
                var pointsPerDay = 1;
                if (agreement.Vehicle.Size >= Size.Luxury)
                    pointsPerDay = 2;
                var points = numberOfDays * pointsPerDay;
                _dataService.AddPoints(
                    agreement.Customer.Id, points);
                // logging
                Console.WriteLine("Accrue complete: {0}",
                    DateTime.Now);
            });
        });
    }
}