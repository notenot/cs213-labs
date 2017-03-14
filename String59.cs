using PT4;
using System.Text.RegularExpressions;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("String59");
            var str = GetString();

            var match = Regex.Match(str, @"^\w:(\\|\w|\.)*\.(\w+)$");
            Put(match.Groups[2].ToString());
        }
    }
}
