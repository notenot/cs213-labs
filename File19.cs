using PT4;
using System.IO;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("File19"); 
            var inputFile = GetString();

            var localMax = double.MinValue;
            using (var binReader = new BinaryReader(
                File.Open(inputFile, FileMode.Open)))
            {
                var leftValue = localMax;
                var value = binReader.ReadDouble();

                while (binReader.BaseStream.Position < binReader.BaseStream.Length - 1)
                {
                    var rightValue = binReader.ReadDouble();

                    if (value > leftValue && value > rightValue)
                        localMax = value;

                    leftValue = value;
                    value = rightValue;
                }

                if (value > leftValue) // last value in file
                    localMax = value;
            }

            Put(localMax);
        }
    }
}
