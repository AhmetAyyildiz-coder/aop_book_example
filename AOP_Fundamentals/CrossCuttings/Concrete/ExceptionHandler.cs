
namespace AOP_Fundamentals.CrossCuttings.Concrete;

public class ExceptionHandler
{
    public void Wrapper(Action action)
    {
        Console.WriteLine("Handle");
    }

    public static bool Handle(Exception argsException)
    {
        return true;
    }
}