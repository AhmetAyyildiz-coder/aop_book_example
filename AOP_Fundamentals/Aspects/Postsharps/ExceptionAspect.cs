using AOP_Fundamentals.CrossCuttings.Concrete;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace AOP_Fundamentals.Aspects.Postsharps;

[PSerializable]
public class ExceptionAspect : OnExceptionAspect
{
    // execute flow içerisinde bir hata olduğunda yakalaması için 
    public override void OnException(MethodExecutionArgs args)
    {
        if (ExceptionHandler.Handle(args.Exception))
        {
            args.FlowBehavior = FlowBehavior.Continue; // akışa devam et diyoruz. aynı args.process misali. 
        }
    }
}