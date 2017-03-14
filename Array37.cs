using PT4;
using System.Linq;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("Array37");
            var array = GetEnumerableDouble().ToList();
            var count = 0;
            
            while (array.Count > 1)
            {
                if (array[0] > array[1])
                {
                    array.Remove(array[0]);
                    continue;
                }

                ++count;
                while (array.Count > 1 && array[0] < array[1])
                    array.Remove(array[0]);
            }

            Put(count);
        }
    }
}
