using AOP_Fundamentals.CrossCuttings.Abstract;

namespace AOP_Fundamentals.CrossCuttings.Concrete;

public class TransactionManager : ITransactionManager
{
    public void Wrapper(Action action)
    {
        Console.WriteLine("Success");
    }
}