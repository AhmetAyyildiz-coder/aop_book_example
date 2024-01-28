using PostSharp.Aspects;

namespace AOP_Fundamentals.Aspects.Postsharps;

public class LoggingAspect : OnMethodBoundaryAspect
{
    // metoda giriş yapıldığında çalışsın
    public override void OnEntry(MethodExecutionArgs args)
    {
        Console.WriteLine("{0}: {1}", args.Method.Name, DateTime.Now);
    }
    
    public override void OnSuccess(MethodExecutionArgs args) {
        Console.WriteLine("{0} complete: {1}",
            args.Method.Name, DateTime.Now);
    }
}