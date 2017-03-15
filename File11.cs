using PT4;
using System.IO;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("File11");
            var inputFile = GetString();
            var oddsFile = GetString();
            var evensFile = GetString();

            using (var binReader = new BinaryReader(
                File.Open(inputFile, FileMode.Open)))
            using (var oddsBinWriter = new BinaryWriter(
                File.Open(oddsFile, FileMode.OpenOrCreate)))
            using (var evenBinWriter = new BinaryWriter(
                File.Open(evensFile, FileMode.OpenOrCreate)))
            {
                var i = 1;

                while (binReader.BaseStream.Position < binReader.BaseStream.Length)
                {
                    var value = binReader.ReadDouble();
                    (i % 2 == 0 ? evenBinWriter : oddsBinWriter).Write(value);
                    ++i;
                }
            }
        }
    }
}
