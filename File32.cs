using PT4;
using System.IO;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("File32");
            var inputFile = GetString();

            var tempFile = Path.GetTempFileName();

            using (var binReader = new BinaryReader(
                File.Open(inputFile, FileMode.Open)))
            {
                var length = binReader.BaseStream.Length;
                binReader.BaseStream.Seek(length / 2, SeekOrigin.Begin);

                using (var tempBinWriter = new BinaryWriter(
                    File.Open(tempFile, FileMode.Open)))
                    while (binReader.BaseStream.Position < binReader.BaseStream.Length)
                        tempBinWriter.Write(binReader.ReadInt32());
            }
            
            File.Delete(inputFile);
            File.Move(tempFile, inputFile);
        }
    }
}
