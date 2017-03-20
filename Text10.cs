using PT4;
using System.IO;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("Text10");
            var k = GetInt();
            var fileName = GetString();

            var tempFile = Path.GetTempFileName();

            using (var streamReader = new StreamReader(
                File.Open(fileName, FileMode.Open), Encoding.Default))
            using (var streamWriter = new StreamWriter(
                File.Open(tempFile, FileMode.Open), Encoding.Default))
            {
                var line = 0;
                while (line != k && !streamReader.EndOfStream)
                {
                    streamWriter.WriteLine(streamReader.ReadLine());
                    ++line;
                }

                if (!streamReader.EndOfStream)
                {
                    streamWriter.WriteLine();
                    streamWriter.Write(streamReader.ReadToEnd());
                }
            }

            File.Delete(fileName);
            File.Move(tempFile, fileName);
        }
    }
}
