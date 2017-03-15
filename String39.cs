using PT4;
using System.Text.RegularExpressions;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("String39");
            var str = GetString();

            var match = Regex.Match(str, @" (\w+) ");
            Put(match.Groups[1].ToString());
        }
    }
}
