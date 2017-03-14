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
            Task("Matrix43");
            var m = GetInt();
            var n = GetInt();

            var mat = GetEnumerableDouble(n * m).ToArray();
            var count = 0;

            for (var i = 0; i < n; ++i) 
            {
                var isSorted = true; 

                for (var j = 0; j < m - 1; ++j) 
                    isSorted = isSorted && mat[j * n + i] > mat[(j + 1) * n + i];

                if (isSorted)
                    ++count;
            }

            Put(count);
        }
    }
}
