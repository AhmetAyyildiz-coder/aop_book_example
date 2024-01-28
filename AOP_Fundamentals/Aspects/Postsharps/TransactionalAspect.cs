using System.Transactions;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace AOP_Fundamentals.Aspects.Postsharps;

[PSerializable]
public class TransactionalAspect : MethodInterceptionAspect
{
    /*
     * Method interception kullanma sebebimiz akışa devam edebilmeyi, ya da akışa müdahele edebilmeyi sağlar.
     * Execute Flow 
     */
    public override void OnInvoke(MethodInterceptionArgs args)
    {
        using (var scope = new TransactionScope())
        {
            Console.WriteLine("Transaction Start");

            try
            {
                args.Proceed(); // var olan akışa devam et diyoruz. 
            }
            catch (Exception e)
            {
                // eğer catch'e düştüyse akışta - execute sırasında bir hata oluştu diyoruz.
                Console.WriteLine(e);
                throw;
            }
        }
    }
}