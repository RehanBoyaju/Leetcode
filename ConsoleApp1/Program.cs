Solution s = new Solution();
Console.WriteLine(s.CountSymmetricIntegers(1200, 1230)); // Output: 9
public class Solution
{
    public int CountSymmetricIntegers(int low, int high)
    {

        int count = 0;
        while (low <= high)
        {
            if (low < 10 || (low > 100 && low < 1000) || low > 10000)
            {
                low++;
                continue;
            }
            
            string str = low.ToString();
            int n = str.Length/2;
            int first = 0;
            int second = 0;
            for (int i = 0; i < n; i++)
            {
                first += str[i] - '0';
                second += str[n + i] - '0';
            }

            if (first == second)
            {
                count++;
            }
            low++;

        }
        return count;
    }
}