
namespace AOP_Fundamentals.CrossCuttings.Concrete;

public class ExceptionHandler : AOP_Fundamentals.CrossCuttings.Abstract.IExceptionHandler
{
    public void Wrapper(Action action)
    {
        Console.WriteLine("Handle");
    }
}