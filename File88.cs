using System;
using PT4;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("File88");
            var inputFile = GetString();
            var outputFile = GetString();
            
            var mat = new List<double>();
            using (var binReader = new BinaryReader(
                File.Open(inputFile, FileMode.Open)))
                while (binReader.BaseStream.Position < binReader.BaseStream.Length)
                    mat.Add(binReader.ReadDouble());
            
            using (var binWriter = new BinaryWriter(
                File.Open(outputFile, FileMode.OpenOrCreate)))
            {
                var n = (mat.Count + 2) / 3;
                var ind = 0;
                for (var i = 0; i < n; ++i)
                    for (var j = 0; j < n; ++j)
                        binWriter.Write(Math.Abs(i - j) > 1 ? 0 : mat[ind++]);
            }
        }
    }
}
