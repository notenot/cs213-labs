using PT4;
using System;
using System.Linq;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        // ѕри решении задач группы LinqBegin доступны следующие
        // дополнительные методы, определенные в задачнике:
        //
        //   GetEnumerableInt() - ввод числовой последовательности;
        //
        //   GetEnumerableString() - ввод строковой последовательности;
        //
        //   Put() (метод расширени€) - вывод последовательности;
        //
        //   Show() и Show(cmt) (методы расширени€) - отладочна€ печать
        //     последовательности, cmt - строковый комментарий;
        //
        //   Show(e => r) и Show(cmt, e => r) (методы расширени€) -
        //     отладочна€ печать значений r, полученных из элементов e
        //     последовательности, cmt - строковый комментарий.

        public static void Solve()
        {
            Task("LinqBegin55");
            var a = GetEnumerableInt();
            var b = GetEnumerableInt();

            var result = a.GroupJoin(b, x => x.ToString().Last(),
                x => x.ToString().Last(), 
                (xa, xb) => xb.DefaultIfEmpty(0)
                .Select(x => xa + ":" + x)).SelectMany(x => x)
                .OrderByDescending(x => Convert.ToInt32(x.Split(':').First()))
                .ThenBy(x => Convert.ToInt32(x.Split(':').Last()));
            result.Show().Put();
        }
    }
}
