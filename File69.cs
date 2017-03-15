using PT4;
using System.IO;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("File69");
            var inputFile = GetString();
            var outputFile = GetString();

            using (var binReader = new BinaryReader(
                File.Open(inputFile, FileMode.Open)))
            using (var binWriter = new BinaryWriter(
                File.Open(outputFile, FileMode.OpenOrCreate)))
                while (binReader.BaseStream.Position < binReader.BaseStream.Length)
                {
                    var date = binReader.ReadString().TrimEnd();
                    if (date.Contains("/06/") ||
                        date.Contains("/07/") ||
                        date.Contains("/08/"))
                        binWriter.Write(date.PadRight(80));
                }
        }
    }
}
