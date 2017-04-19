using PT4;
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
            Task("LinqBegin29");
            var d = GetInt();
            var k = GetInt();
            var a = GetEnumerableInt();

            var first = a.TakeWhile(x => x <= d);
            var second = a.Skip(k - 1);
            var result = first.Union(second).OrderByDescending(x => x);
            result.Put();
        }
    }
}
