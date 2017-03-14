using PT4;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("String67");
            var encrypted = new StringBuilder(GetString());
            var decrypted = new StringBuilder();
            var length = encrypted.Length;

            for (var i = 0; i < length; ++i)
            {
                decrypted.Append(i % 2 == 0 ? 
                    encrypted[encrypted.Length - 1] : encrypted[0]);
                encrypted.Remove(i % 2 == 0 ? 
                    encrypted.Length - 1 : 0, 1); 
            }

            Put(decrypted.ToString());
        }
    }
}
