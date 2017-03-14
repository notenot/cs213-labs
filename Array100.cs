using PT4;
using System.Collections.Generic;
using System.Linq;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("Array100");
            var array = GetEnumerableInt().ToList(); 
            
            for (var i = 0; i < array.Count; ++i)
            {
                var value = array[i];
                if (array.FindAll(x => x == value).Count == 2)
                {
                    array.RemoveAll(x => x == value);
                    --i;
                }
            } 

            Put(array.Count);
            array.ForEach(x => Put(x));
        }
    }
}
