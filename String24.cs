using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("String24");
            var bin = GetString();

            var dec = bin.Select((ch, ind) => 
                ch == '0' ? 0 : (int) Math.Pow(2, bin.Length - 1 - ind))
                .Sum();

            Put(dec.ToString());
        }
    }
}
