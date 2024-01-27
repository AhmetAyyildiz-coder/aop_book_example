namespace AOP_Fundamentals.CrossCuttings.Abstract;

public interface ITransactionManager
{
    void Wrapper(Action action);
}