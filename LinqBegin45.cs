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
            Task("LinqBegin45");
            var l1 = GetInt();
            var l2 = GetInt();

            var first = GetEnumerableString()
                .Where(s => s.Length == l1);
            var second = GetEnumerableString()
                .Where(s => s.Length == l2);
            var result = first.Concat(second)
                .OrderByDescending(s => s);

            result.Put();
        }
    }
}
