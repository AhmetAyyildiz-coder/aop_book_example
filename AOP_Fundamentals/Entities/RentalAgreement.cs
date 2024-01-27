namespace AOP_Fundamentals.Entities;



/// <summary>
/// Kiralama anlaşmasıdır. 
/// </summary>
public class RentalAgreement {
    public Guid Id { get; set; }
    public Customer Customer { get; set; }
    public Vehicle Vehicle { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}


/// <summary>
/// Müşteriler 
/// </summary>
public class Customer {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string DriversLicense { get; set; }
    public DateTime DateOfBirth { get; set; }
}


/// <summary>
/// Araçlar
/// </summary>
public class Vehicle {
    public Guid Id { get; set; }
    /// <summary>
    ///  Araç üreticisinin (marka) adını temsil eder.
    /// </summary>
    public string Make { get; set; }
    public string Model { get; set; }
    public Size Size { get; set; }
    /// <summary>
    ///  Araçın VIN (Vehicle Identification Number - Araç Tanımlama Numarası) 
    /// </summary>
    public string Vin { get; set; }
}
public enum Size {
    Compact = 0, Midsize, FullSize, Luxury, Truck, SUV
}

public class Invoice {
    public Guid Id { get; set; }
    public Customer Customer { get; set; }
    public Vehicle Vehicle { get; set; }
    public decimal CostPerDay { get; set; }
    public decimal Discount { get; set; }
}