namespace AOP_Fundamentals.CrossCuttings.Abstract;

public interface IExceptionHandler
{
    void Wrapper(Action action);
    bool Handle(Exception argsException);
}