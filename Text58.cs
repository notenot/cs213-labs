using System;
using PT4;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("Text58");
            var inputFile = GetString();
            var outputFile = GetString();

            var dictionary = new Dictionary<char, int>();

            using (var streamReader = new StreamReader(
                File.Open(inputFile, FileMode.Open), Encoding.Default))
                while (!streamReader.EndOfStream)
                {
                    var ch = Convert.ToChar(streamReader.Read());

                    if (!char.IsLower(ch))
                        continue;
                    
                    if (dictionary.ContainsKey(ch))
                        ++dictionary[ch];
                    else
                        dictionary.Add(ch, 1);
                }

            var comparer = new PairComparer();
            var sortedDictionary = dictionary.OrderBy(x => x, comparer);

            using (var binWriter = new BinaryWriter(
                File.Open(outputFile, FileMode.OpenOrCreate), Encoding.Default))
                foreach (var pair in sortedDictionary)
                    binWriter.Write($"{pair.Key}-{pair.Value}".PadRight(80));
        }
    }

    public class PairComparer : IComparer<KeyValuePair<char, int>>
    {
        public int Compare(KeyValuePair<char, int> fst, KeyValuePair<char, int> snd)
            => fst.Value == snd.Value 
                ? fst.Key.CompareTo(snd.Key) 
                : snd.Value.CompareTo(fst.Value);
    }
}
