using PT4;
using System.Linq;
using System.Text.RegularExpressions;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("String56");
            var str = GetString();

            var matches = Regex.Split(str, @"\W").OrderBy(x => x.Length)
                .GroupBy(x => x.Length);
            Put(matches.ElementAt(1).Last());
        }
    }
}
