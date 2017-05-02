using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using PT4;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        // При решении задач группы LinqXml доступны следующие
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
            Task("LinqXml9");
            var inFileName = GetString();
            var outFileName = GetString();

            var file = File.ReadLines(inFileName, Encoding.Default);

            var xmlDoc = new XDocument(
                new XDeclaration("1.0", "windows-1251", null), new XElement("root",
                    file.Select(line => line.StartsWith("comment:") 
                        ? new XComment(line.Remove(0, 8))
                        : (XNode) new XElement("line", line))
                ));

            xmlDoc.Save(outFileName);
        }
    }
}
