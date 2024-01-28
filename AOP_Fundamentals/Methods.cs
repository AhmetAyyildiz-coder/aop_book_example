using AOP_Fundamentals.CrossCuttings.Concrete;
using AOP_Fundamentals.Entities;
using AOP_Fundamentals.Repository.Concrete;
using AOP_Fundamentals.Services.Concrete;

namespace AOP_Fundamentals;

public static class Methods
{
    /// <summary>
    ///  Sadakat puanları eklemeyi simüle eden bir metottur.
    /// </summary>
    /// /// <remarks>
    /// Bu metot, sadakat puanlarını eklemek için kullanılan servisin ve sahte (fake) veri servisinin
    /// bir örneğini oluşturur. Ardından, bir kiralama anlaşması oluşturarak bu anlaşma üzerinden
    /// müşteriye sadakat puanları ekler.
    /// </remarks>
    public static void SimulateAddingPoints()
    {
        // Sahte (fake) veri servisi oluşturulur.
        var dataService = new FakeLoyaltyDataService();

        // Sadakat puanları biriktirme servisi oluşturulur ve sahte veri servisi enjekte edilir.
        var service = new LoyaltyAccrualService(dataService);


        var rentalAgreement = new RentalAgreement
        {
            Customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Matthew D. Groves",
                DateOfBirth = new DateTime(1980, 2, 10),
                DriversLicense = "RR123456"
            },
            Vehicle = new Vehicle
            {
                Id = Guid.NewGuid(),
                Make = "Honda",
                Model = "Accord",
                Size = Size.Compact,
                Vin = "1HABC123"
            },
            StartDate = DateTime.Now.AddDays(-3),
            EndDate = DateTime.Now
        };
        service.Accrue(rentalAgreement);
    }


    /// <summary>
    /// Sadakat puanları kullanarak ödül kazanmayı simüle eden bir metottur.
    /// </summary>
    /// <remarks>
    /// Bu metot, sadakat puanlarını kullanarak müşterinin belirli bir faturadan ödül kazanmasını simüle eder.
    /// Önce, sahte (fake) veri servisi ve sadakat puanları kullanarak ödül kazanma servisi oluşturulur.
    /// Daha sonra, bir fatura örneği oluşturularak bu fatura üzerinden belirli bir gün sayısı için
    /// müşterinin sadakat puanlarından ödül kazanması gerçekleştirilir.
    /// </remarks>
    public static void SimulateRemovingPoints()
    {
        // Sahte (fake) veri servisi oluşturulur.
        var dataService = new FakeLoyaltyDataService();

        // Sadakat puanları kullanarak ödül kazanma servisi oluşturulur ve sahte veri servisi enjekte edilir.
        var service = new LoyaltyRedemptionServiceRefactored(dataService:dataService,new ExceptionHandler(),new TransactionManager());

        // Simülasyon için bir fatura örneği oluşturulur.
        var invoice = new Invoice
        {
            Customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Jacob Watson",
                DateOfBirth = new DateTime(1977, 4, 15),
                DriversLicense = "RR009911"
            },
            Vehicle = new Vehicle
            {
                Id = Guid.NewGuid(),
                Make = "Cadillac",
                Model = "Sedan",
                Size = Size.Luxury,
                Vin = "2BDI"
            },
            CostPerDay = 29.95m,
            Id = Guid.NewGuid()
        };

        // Sadakat puanları kullanarak müşterinin belirli bir gün sayısı için ödül kazanması gerçekleştirilir.
        service.Redeem(invoice, 3);
    }

}