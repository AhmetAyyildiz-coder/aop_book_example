using AOP_Fundamentals.Entities;

namespace AOP_Fundamentals.Services.Abstract;


/// <summary>
/// Müşteri sadakat puanlarının biriktirilmesini sağlayan servis arayüzü.
/// </summary>
public interface ILoyaltyAccrualService
{
    /// <summary>
    /// Bir kiralama anlaşması için müşteriye sadakat puanları biriktirir.
    /// </summary>
    /// <param name="agreement">Puan biriktirme işlemi yapılacak kiralama anlaşması.</param>
    void Accrue(RentalAgreement agreement);
}