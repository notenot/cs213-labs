using System;
using PT4;
using System.Linq;
using System.IO;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
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
            Task("LinqObj46");
            var inFileName = GetString();
            var outFileName = GetString();
            
            var result = File.ReadLines(inFileName, Encoding.Default)
                .Select(x => new
                {
                    street = x.Split()[0],
                    gasoline = x.Split()[1],
                    company = x.Split()[3]
                })
                .GroupBy(x => x.company, (k, v) => new
                {
                    company = k,
                    stations = v.GroupBy(x => x.street, 
                        (k1, v1) => v1.Count()).Count(x => x == 3)
                })
                .OrderByDescending(x => x.stations)
                .ThenBy(x => x.company)
                .Select(x => x.stations + " " + x.company);

            File.WriteAllLines(outFileName, result, Encoding.Default);
        }
    }
}
