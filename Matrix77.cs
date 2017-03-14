using PT4;
using System.Collections.Generic;
using System.Linq;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("Matrix77");
            var m = GetInt();
            var n = GetInt();
            var mat = new List<List<double>>();

            for (var i = 0; i < n; ++i)
                mat.Add(new List<double>());

            for (var i = 0; i < m; ++i)
                for (var j = 0; j < n; ++j)
                    mat[j].Add(GetDouble());

            var sorted = mat.OrderByDescending(x => x[m - 1]).ToList();
            for (var i = 0; i < m; ++i)
                for (var j = 0; j < n; ++j)
                    Put(sorted[j][i]);
        }
    }
}
