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
        
        // logging
        Console.WriteLine("Redeem: {0}", DateTime.Now);
        Console.WriteLine("Invoice: {0}", invoice.Id);
        
        // Günlük puan miktarı belirlenir, lüks araçlar için farklı bir puan uygulanabilir.
        var pointsPerDay = 10;
        if (invoice.Vehicle.Size >= Size.Luxury)
            pointsPerDay = 15;


        
        // Kazanılacak toplam puan miktarı hesaplanır ve müşterinin puanlarından çıkarılır.
        var points = numberOfDays*pointsPerDay;
        _loyaltyDataService.SubtractPoints(invoice.Customer.Id, points);
        
        
        // Faturaya indirim uygulanır.
        invoice.Discount = numberOfDays * invoice.CostPerDay;
        
        // logging 
        Console.WriteLine("Redeem complete: {0}", DateTime.Now);
        
    }
}