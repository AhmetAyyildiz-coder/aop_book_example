using AOP_Fundamentals.Entities;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace AOP_Fundamentals.Aspects.Postsharps;


[PSerializable]
public class LoggingAspect : OnMethodBoundaryAspect
{
    // metoda giriş yapıldığında çalışsın
    public override void OnEntry(MethodExecutionArgs args)
    {
        foreach (var argument in args.Arguments)
        {
            if (argument.GetType() == typeof(RentalAgreement))
            {
                Console.WriteLine("Customer: {0}",
                    ((RentalAgreement)argument).Customer.Id);
                Console.WriteLine("Vehicle: {0}",
                    ((RentalAgreement)argument).Vehicle.Id);
            }

            if (argument.GetType() == typeof(Invoice))
            {
                Console.WriteLine("Invoice: {0}", ((Invoice)argument).Id);
            }
        }
    }
    
    public override void OnSuccess(MethodExecutionArgs args) {
        Console.WriteLine("{0} complete: {1}",
            args.Method.Name, DateTime.Now);
    }
}