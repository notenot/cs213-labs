using System;
using System.IO;
using System.Text;
using PT4;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("Text40");
            var firstFile = GetString();
            var secondFile = GetString();
            var outputFile = GetString();

            const int columnWidth = 30;
            var delim = char.ConvertFromUtf32(124);

            using (var fstBinReader = new BinaryReader(
                File.Open(firstFile, FileMode.Open)))
            using (var sndBinReader = new BinaryReader(
                File.Open(secondFile, FileMode.Open)))
            using (var streamWriter = new StreamWriter(
                File.Open(outputFile, FileMode.OpenOrCreate), Encoding.Default))
                while (fstBinReader.BaseStream.Position < fstBinReader.BaseStream.Length)
                {
                    var fst = fstBinReader.ReadInt32();
                    var snd = sndBinReader.ReadInt32();

                    streamWriter.WriteLine(
                        $"{delim}{fst,columnWidth}{snd,columnWidth}{delim}");
                }
        }
    }
}
