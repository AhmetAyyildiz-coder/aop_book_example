using AOP_Fundamentals.Entities;

namespace AOP_Fundamentals.Services.Abstract;


/// <summary>
/// Müşteri sadakat puanlarının kullanılarak ödül kazanılmasını sağlayan servis arayüzü.
/// </summary>
public interface ILoyaltyRedemptionService
{
    /// <summary>
    /// Fatura üzerinde belirli bir sayıda gün için müşteri sadakat puanlarının kullanılmasını gerçekleştirir.
    /// </summary>
    /// <param name="invoice">Sadakat puanlarının kullanılacağı fatura.</param>
    /// <param name="numberOfDays">Kazanılmış olan sadakat puanlarının gün sayısına dönüştürülerek kullanılacak gün sayısı.</param>
    void Redeem(Invoice invoice, int numberOfDays);
}


/*
 *Redeem uygulaması, aldığı araca (ve kullandığı ücretsiz gün sayısına) bağlı olarak puanları müşterinin hesabından çıkarır ve indirim tutarını faturaya ekler. 
 * 
 */