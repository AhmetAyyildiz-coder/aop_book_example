using System.Transactions;
using AOP_Fundamentals.Entities;
using AOP_Fundamentals.Repository.Abstract;
using AOP_Fundamentals.Services.Abstract;

namespace AOP_Fundamentals.Services.Concrete;



/// <summary>
/// Müşteriye sadakat puanları biriktirme işlemlerini yöneten servis sınıfı.
/// </summary>
public class LoyaltyAccrualService : ILoyaltyAccrualService
{
    private readonly ILoyaltyDataService _loyaltyDataService;

    /// <summary>
    /// LoyaltyAccrualService sınıfının yapıcı metodudur.
    /// </summary>
    /// <param name="loyaltyDataService">Sadakat puanları veri servisi.</param>
    public LoyaltyAccrualService(ILoyaltyDataService loyaltyDataService)
    {
        _loyaltyDataService = loyaltyDataService ?? throw new ArgumentNullException(nameof(loyaltyDataService));
    }

    /// <summary>
    /// Müşteriye sadakat puanları biriktirme işlemini gerçekleştirir.
    /// </summary>
    /// <param name="agreement">Bir kiralama anlaşması örneği.</param>
    /// <exception cref="ArgumentNullException">agreement parametresi null ise fırlatılır.</exception>
    public void Accrue(RentalAgreement agreement)
    {
        // defensive programming
        if (agreement == null) throw new ArgumentNullException(nameof(agreement));

        // logging
        Console.WriteLine("Accrue: {0}", DateTime.Now);
        Console.WriteLine("Customer: {0}", agreement.Customer.Id);
        Console.WriteLine("Vehicle: {0}", agreement.Vehicle.Id);

        // transaction implementation
        try
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    var rentalTime = (agreement.EndDate.Subtract(agreement.StartDate));
                    var numberOfDays = (int)Math.Floor(rentalTime.TotalDays);
                    var pointsPerDay = 1;

                    // Lüks araçlar için günlük puan miktarı farklıdır.
                    if (agreement.Vehicle.Size >= Size.Luxury)
                        pointsPerDay = 2;

                    var points = numberOfDays * pointsPerDay;
                    _loyaltyDataService.AddPoints(agreement.Customer.Id, points);
                    scope.Complete();
                }
                catch
                {
                    // Hata durumunda loglama yapılabilir.
                    throw;
                }
            }
        }
        catch (Exception e)
        {
            // TransactionScope veya genel bir hata durumunda loglama yapılabilir.
            Console.WriteLine(e);
            throw;
        }

        // logging
        Console.WriteLine("Accrue complete: {0}", DateTime.Now);
    }
}
