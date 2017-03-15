using System.IO;
using PT4;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("File53");
            var outputFile = GetString();
            var n = GetInt();
            var archive = GetString();

            using (var binReader = new BinaryReader(
                File.Open(archive, FileMode.Open)))
            using (var binWriter = new BinaryWriter(
                File.Open(outputFile, FileMode.OpenOrCreate)))
            {
                var innerFiles = binReader.ReadInt32();

                if (innerFiles < n)
                    return;

                var skip = 0;                       // elements before nth file
                for (var i = 0; i < n - 1; ++i)
                    skip += binReader.ReadInt32();

                var length = binReader.ReadInt32(); // of nth file 

                skip += innerFiles - n;
                binReader.BaseStream.Seek(skip * sizeof(int), SeekOrigin.Current);

                for (var i = 0; i < length; ++i)
                    binWriter.Write(binReader.ReadInt32());
            }
        }
    }
}
