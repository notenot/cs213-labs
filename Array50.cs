using PT4;
using System.Linq;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("Array50");
            var array = GetEnumerableInt().ToArray();
            var count = 0;

            for (var i = 0; i < array.Length; ++i)
                for (var j = 0; j < i; ++j)
                    if (array[j] > array[i])
                        ++count;
            
            Put(count);
        }
    }
}
