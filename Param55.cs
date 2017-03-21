using System.IO;
using System.Text;
using PT4;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("Param55");
            var firstFile = GetString();
            StringFileToText(firstFile);

            var secondFile = GetString();
            StringFileToText(secondFile);
        }

        public static void StringFileToText(string fileName)
        {
            var tempFile = Path.GetTempFileName();

            using (var binReader = new BinaryReader(
                File.Open(fileName, FileMode.Open)))
            using (var streamWriter = new StreamWriter(
                File.Open(tempFile, FileMode.OpenOrCreate), Encoding.Default))
                while (binReader.BaseStream.Position < binReader.BaseStream.Length)
                {
                    var value = binReader.ReadString().TrimEnd();
                    streamWriter.WriteLine(value);
                }

            File.Delete(fileName);
            File.Move(tempFile, fileName);
        }
    }
}
