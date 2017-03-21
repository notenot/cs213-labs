using System.IO;
using System.Text;
using PT4;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("Text39");
            var k = GetInt();
            var inputFile = GetString();
            var outputFile = GetString();
            const string paragraph = "     ";

            using (var streamReader = new StreamReader(
                File.Open(inputFile, FileMode.Open), Encoding.Default))
            using (var streamWriter = new StreamWriter(
                File.Open(outputFile, FileMode.OpenOrCreate), Encoding.Default))
            {
                var buf = "";
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine().TrimEnd();

                    if (line.StartsWith(paragraph))
                    {
                        if (buf.Length != 0)
                            streamWriter.WriteLine(buf);
                        buf = line;
                    }
                    else buf = (buf.Length == 0 ? "" : buf + ' ') + line;

                    while (buf.Length > k)
                    {
                        var spaceInd = buf.LastIndexOf(' ', k, k + 1);
                        var word = buf.Substring(0, spaceInd);
                        streamWriter.WriteLine(word);
                        
                        var newStart = spaceInd + 
                            (buf[spaceInd] == ' ' ? 1 : 0);
                        var newLength = buf.Length - word.Length -
                            (buf[spaceInd] == ' ' ? 1 : 0);
                        buf = buf.Substring(newStart, newLength);
                    }
                }
                
                if (buf.Length != 0)
                    streamWriter.WriteLine(buf);
            } 
        }
    }
}
