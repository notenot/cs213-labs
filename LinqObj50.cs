using System;
using PT4;
using System.Linq;
using System.IO;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        // Для чтения набора строк из исходного текстового файла
        // в массив a типа string[] используйте оператор:
        //
        //   a = File.ReadAllLines(GetString(), Encoding.Default);
        //
        // Для записи последовательности s типа IEnumerable<string>
        // в результирующий текстовый файл используйте оператор:
        //
        //   File.WriteAllLines(GetString(), s.ToArray(), Encoding.Default);
        //
        // При решении задач группы LinqObj доступны следующие
        // дополнительные методы расширения, определенные в задачнике:
        //
        //   Show() и Show(cmt) - отладочная печать последовательности,
        //     cmt - строковый комментарий;
        //
        //   Show(e => r) и Show(cmt, e => r) - отладочная печать
        //     значений r, полученных из элементов e последовательности,
        //     cmt - строковый комментарий.

        public static void Solve()
        {
            Task("LinqObj50");
            var inFileName = GetString();
            var outFileName = GetString();

            var file = File.ReadLines(inFileName, Encoding.Default)
                .Select(x => x.Split())
                .Select(x => new
                {
                    surname = x[0],
                    initials = x[1],
                    rating = Convert.ToInt32(x[2]) +
                             Convert.ToInt32(x[3]) +
                             Convert.ToInt32(x[4])
                });

            var result = file
                .GroupBy(x => 1)
                .Select(x =>
                {
                    var first = x.Select(y => y.rating)
                                 .Distinct()
                                 .OrderByDescending(y => y).Take(2);
                    var students = x.Where(y => first.Contains(y.rating));

                    return new [] { $"{first.First()} {first.Last()}"}
                        .Concat(students.Select(
                            y => $"{y.surname} {y.initials} {y.rating}"));
                })
                .Aggregate(Enumerable.Empty<string>(), (all, cur) =>
                    all.Concat(cur));

            File.WriteAllLines(outFileName, result, Encoding.Default);
        }
    }
}
