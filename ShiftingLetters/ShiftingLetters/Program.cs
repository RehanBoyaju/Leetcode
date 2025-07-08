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
            int[] suffixSum = new int[n];

            suffixSum[n - 1] = shifts[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                suffixSum[i] = (shifts[i]+ suffixSum[i + 1]) % 26;
            }
            StringBuilder sb = new StringBuilder(s);
            for (int i = 0; i < n; i++)
            {
                sb[i] = (char)('a' + (sb[i]-'a'+suffixSum[i]) %26);
            }

            return sb.ToString();



        }
    }
}
