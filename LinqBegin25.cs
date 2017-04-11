using PT4;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        // ��� ������� ����� ������ LinqBegin �������� ���������
        // �������������� ������, ������������ � ���������:
        //
        //   GetEnumerableInt() - ���� �������� ������������������;
        //
        //   GetEnumerableString() - ���� ��������� ������������������;
        //
        //   Put() (����� ����������) - ����� ������������������;
        //
        //   Show() � Show(cmt) (������ ����������) - ���������� ������
        //     ������������������, cmt - ��������� �����������;
        //
        //   Show(e => r) � Show(cmt, e => r) (������ ����������) -
        //     ���������� ������ �������� r, ���������� �� ��������� e
        //     ������������������, cmt - ��������� �����������.

        public static void Solve()
        {
            Task("LinqBegin25");
            var k1 = GetInt();
            var k2 = GetInt();
            var a = GetEnumerableInt();

            var result = a.Skip(k1 - 1).Take(k2 - k1 + 1)
                .Where(x => x > 0).Sum();
            Put(result);
        }
    }
}
