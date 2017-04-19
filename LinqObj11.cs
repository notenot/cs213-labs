using System;
using System.IO;
using PT4;
using System.Linq;
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
            Task("LinqObj11");
            var inFileName = GetString();
            var outFileName = GetString();

            var result = File.ReadLines(inFileName, Encoding.Default)
                .Select(x => new
                {
                    data = x.Split()[1] + " " + x.Split()[2],
                    duration = Convert.ToInt32(x.Split()[3])
                })
                .GroupBy(x => x.data, (k, v) => new
                {
                    data = k,
                    sumDuration = v.Sum(x => x.duration)
                })
                .OrderBy(x => x.sumDuration)
                .ThenByDescending(x => Convert.ToInt32(x.data.Split(' ').First()))
                .ThenBy(x => Convert.ToInt32(x.data.Split(' ').Last()))
                .Select(x => x.sumDuration + " " + x.data);
            
            File.WriteAllLines(outFileName, result, Encoding.Default);
        }
    }
}
