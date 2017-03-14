using PT4;
using System;
using System.Linq;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("Matrix28");
            var m = GetInt();
            var n = GetInt();

            var row = GetEnumerableDouble(n);
            for (var i = 1; i < m; ++i)
                row = row.Zip(GetEnumerableDouble(n), Math.Max);

            Put(row.Min());
        }
    }
}
