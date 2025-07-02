Solution s = new Solution();
Console.WriteLine(s.PossibleStringCount("aabbccdd", 8));
public class Solution
{
    public int PossibleStringCount(string word, int k)
    {
        int mod = 1_000_000_007;
        List<int> RunLengths = new List<int>();
        char prev = word[0];
        int count = 1;

        int totalPerms = 1;
        for (int i = 1; i < word.Length; i++)
        {
            if (prev == word[i])
            {
                count++;
            }
            else
            {
                prev = word[i];
                RunLengths.Add(count);
                totalPerms *= count;
                count = 1;
            }
        }
        RunLengths.Add(count);
        totalPerms *= count;

        int n = RunLengths.Count;

        int Solve(int i, int j)
        {
            if (i > n || j >= k)
            {
                return 0;
            }
            if (i == n)
            {
                if (j <= k - 1)
                {
                    return 1;
                }
            }

            int ans = 0;
            for (int k = 0; k < RunLengths[i]; k++)
            {
                ans += Solve(i + 1, j + k+1);
            }

            return ans%mod;


        }


        return totalPerms - Solve(0, 0);


    }
}