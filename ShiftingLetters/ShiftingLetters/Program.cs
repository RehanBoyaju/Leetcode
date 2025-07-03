using System.Text;

namespace ShiftingLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ShiftingLetters("abc",new int[] {3,5,9}));
        }


        static string ShiftingLetters(string s, int[] shifts)
        {
            int n = shifts.Length;
            int[] sum = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    sum[j] = (sum[j] + shifts[i]) % 26;
                }

            }
            StringBuilder sb = new StringBuilder(s);
            for (int i = 0; i < s.Length; i++)
            {
                sb[i] = (char)((((sb[i] - 'a') + sum[i]) % 26) + 'a');
            }

            return sb.ToString();



        }
    }
}
