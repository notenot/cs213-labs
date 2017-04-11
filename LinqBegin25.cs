using PT4;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace PT4Tasks
{
    public class MyTask : PT
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
            Task("LinqBegin25");
            var k1 = GetInt();
            var k2 = GetInt();
            var a = GetEnumerableInt();

            var result = a.Skip(k1 - 1).Take(k2 - k1 + 1)
                .Where(x => x > 0).Sum();
            Put(result);
        }
    }
}
