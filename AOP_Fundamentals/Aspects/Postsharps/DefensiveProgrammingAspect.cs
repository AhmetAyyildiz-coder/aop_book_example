using PostSharp.Aspects;
using PostSharp.Serialization;

namespace AOP_Fundamentals.Aspects.Postsharps;

[PSerializable]
public class DefensiveProgrammingAspect : OnMethodBoundaryAspect
{
    public override void OnEntry(MethodExecutionArgs args)
    {
        var parameters = args.Method.GetParameters();
        
        var arguments = args.Arguments;
        
        for (int i = 0; i < arguments.Count; i++) {
            if (arguments[i] == null)
                throw new ArgumentNullException(parameters[i].Name);
            if (arguments[i].GetType()! == typeof(int)
                && (int)arguments[i] <= 0)
                throw new ArgumentException("", parameters[i].Name);
        }
    }
}