Solution s = new Solution();
var res = s.FindEvenNumbers(new int[] { 2, 1, 3, 0 });

Console.WriteLine(string.Join(", ", res));
public class Solution
{
    public int[] FindEvenNumbers(int[] digits)
    {
        int[] evens = new int[10];

        foreach (int digit in digits)
        {
            evens[digit]++;
        }


        List<int> res = new List<int>();
        for (int i = 100; i < 999; i = i + 2)
        {
            int num = i;

            int[] curr = new int[10];

            while (num > 0)
            {
                curr[num % 10]++;
                num = num / 10;
            }
            bool possible = true;
            for (int j = 0; j < 10; j++)
            {
                if (evens[j] < curr[j])
                {
                    possible = false;
                    break;
                }
            }
            if (possible)
            {
                res.Add(i);
            }

        }
        return res.ToArray();
    }
}