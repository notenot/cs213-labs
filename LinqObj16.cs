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
            Task("LinqObj16");
            var inFileName = GetString();
            var outFileName = GetString();

            var result = File.ReadLines(inFileName, Encoding.Default)
                .Select(x => x.Split()[0])
                .GroupBy(x => x, (k, v) => new
                {
                    year = k,
                    count = v.Count()
                })
                .OrderByDescending(x => x.count)
                .ThenBy(x => x.year)
                .Select(x => x.count + " " + x.year);

            File.WriteAllLines(outFileName, result, Encoding.Default);
        }
    }
}
