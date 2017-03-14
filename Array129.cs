using PT4;
using System.Linq;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("Array129");
            var array = GetEnumerableInt().ToList();
            var count = 1;
            var start = array.Count - 1;

            var i = 0;
            while (i < array.Count - 1)
            {
                if (array[i] != array[i + 1])
                {
                    ++i;
                    continue;
                }

                var newStart = i;
                var newCount = 0;

                while (i < array.Count - 1 
                    && array[i] == array[i + 1])
                {
                    ++newCount;
                    ++i;
                }

                if (count > newCount)
                    continue;

                count = newCount;
                start = newStart;
            }

            array.Insert(start, array[start]);
            array.ForEach(x => Put(x));
        }
    }
}
