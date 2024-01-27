using System.Transactions;
using AOP_Fundamentals.Entities;
using AOP_Fundamentals.Repository.Abstract;
using AOP_Fundamentals.Services.Abstract;

namespace AOP_Fundamentals.Services.Concrete;


/// <summary>
/// Müşteri sadakat puanları kullanılarak ödül kazanma işlemlerini yöneten servis sınıfı.
/// </summary>
public class LoyaltyRedemptionService : ILoyaltyRedemptionService
{
    readonly ILoyaltyDataService _loyaltyDataService;

    public LoyaltyRedemptionService(ILoyaltyDataService loyaltyDataService)
    {
        _loyaltyDataService = loyaltyDataService;
    }

    /// <summary>
    /// Fatura üzerinden müşteriye sadakat puanları kullanılarak ödül kazandırma işlemini gerçekleştirir.
    /// </summary>
    /// <param name="invoice">Sadakat puanları kullanılacak fatura.</param>
    /// <param name="numberOfDays">Kazanılacak ödül gün sayısı.</param>
    public void Redeem(Invoice invoice, int numberOfDays)
    {
        // defensive programming
        if(invoice == null) throw new ArgumentNullException("invoice");       
        // logging
        Console.WriteLine("Redeem: {0}", DateTime.Now);
        Console.WriteLine("Invoice: {0}", invoice.Id);
        
        
        // transaction imp.
        using (var scope = new TransactionScope()) {
            try {
                var pointsPerDay = 10;
                if (invoice.Vehicle.Size >= Size.Luxury)
                    pointsPerDay = 15;
                var points = numberOfDays*pointsPerDay;
                _loyaltyDataService.SubtractPoints(invoice.Customer.Id, points);
                invoice.Discount = numberOfDays*invoice.CostPerDay;
                scope.Complete();
            }
            catch {
                throw;
            }
        }
        
        // logging 
        Console.WriteLine("Redeem complete: {0}", DateTime.Now);
        
    }
}