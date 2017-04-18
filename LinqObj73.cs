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
            Task("LinqObj73");
            var fstInFileName = GetString();
            var sndInFileName = GetString();
            var outFileName = GetString();

            var a = File.ReadLines(fstInFileName, Encoding.Default)
                .Select(x => x.Split())
                .Select(x => new
                {
                    year = x[0],
                    code = x[1],
                    street = x[2]
                });

            var c = File.ReadLines(sndInFileName, Encoding.Default)
                .Select(x => x.Split())
                .Select(x => new
                {
                    code = x[0],
                    shop = x[1],
                    discount = x[2]
                });

            var result = a.Join(c, x => x.code, x => x.code, (x, y) => new
            {
                y.shop,
                x.street
            })
            .OrderBy(x => x.shop)
            .ThenBy(x => x.street)
            .GroupBy(x => $"{x.shop} {x.street}", (k, v) => new
            {
                shop = k,
                count = v.Count()
            })
            .Select(x => $"{x.shop} {x.count}")
            .Show();

            File.WriteAllLines(outFileName, result, Encoding.Default);
        }
    }
}
