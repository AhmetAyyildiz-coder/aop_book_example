using AOP_Fundamentals;
using AOP_Fundamentals.Entities;
using AOP_Fundamentals.Repository.Abstract;
using AOP_Fundamentals.Repository.Concrete;
using AOP_Fundamentals.Services.Abstract;
using AOP_Fundamentals.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

ServiceProvider serviceProvider = new ServiceCollection()
    .AddScoped<ILoyaltyAccrualService, LoyaltyAccrualService>()
    .AddScoped<ILoyaltyDataService, FakeLoyaltyDataService>()
    .AddScoped<ILoyaltyRedemptionService, LoyaltyRedemptionService>()
    .BuildServiceProvider();
    
    
 

Methods.SimulateAddingPoints();
Console.WriteLine();
Console.WriteLine(" ***");
Console.WriteLine();
Methods.SimulateRemovingPoints();
Console.WriteLine();
Console.WriteLine();

