namespace AOP_Fundamentals.Repository.Abstract;


/// <summary>
/// Müşteri sadakat puanlarını yöneten bir veri servisi arayüzü.
/// </summary>
public interface ILoyaltyDataService
{
    /// <summary>
    /// Belirli bir müşteriye sadakat puanı ekler.
    /// </summary>
    /// <param name="customerId">Sadakat puanları eklenen müşterinin benzersiz kimliği.</param>
    /// <param name="points">Eklenen sadakat puanı miktarı.</param>
    void AddPoints(Guid customerId, int points);
    
    /// <summary>
    /// Belirli bir müşterinin sadakat puanından belirtilen miktar kadar puan çıkarır.
    /// </summary>
    /// <param name="customerId">Sadakat puanları çıkarılan müşterinin benzersiz kimliği.</param>
    /// <param name="points">Çıkarılan sadakat puanı miktarı.</param>
    void SubtractPoints(Guid customerId, int points);
}