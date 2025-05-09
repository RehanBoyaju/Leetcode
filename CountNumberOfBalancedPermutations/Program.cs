Solution s = new Solution();
Console.WriteLine(s.CountBalancedPermutations("123")); // Output: 2
public class Solution
{
    public int CountBalancedPermutations(string num)
    {
        int n = num.Length;
        const long MOD = 1_000_000_007;

        int[] dict = new int[10];
        int sum = 0;
        foreach (char c in num)
        {
            int d = c - '0';
            dict[d]++;
            sum += d;
        }
        if (sum % 2 == 1)
        {
            return 0;
        }
        int target = sum / 2;
        int maxOdd = (n + 1) / 2;
        var comb = new long[maxOdd + 1, maxOdd + 1];
        for (int i = 0; i <= maxOdd; i++)
        {
            comb[i, i] = comb[i, 0] = 1;
            for (int j = 1; j < i; j++)
            {
                comb[i, j] = (comb[i - 1, j] + comb[i - 1, j - 1]) % MOD;
            }

        }
        var psum = new int[11];
        for (int i = 9; i >= 0; i--)
        {
            psum[i] = psum[i + 1] + dict[i];
        }
        var memo = new int[10, target + 1, maxOdd + 1];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j <= target; j++)
            {
                for (int k = 0; k <= maxOdd; k++)
                {
                    memo[i, j, k] = -1;
                }
            }
        }
        int Dfs(int pos, int evenSum, int oddCnt)
        {
            if (oddCnt < 0 || psum[pos] < oddCnt || evenSum > target)
            {
                return 0;
            }

            if (pos > 9)
            {
                return (evenSum == target && oddCnt == 0) ? 1 : 0;
            }
            if (memo[pos, evenSum, oddCnt] != -1)
            {
                return memo[pos, evenSum, oddCnt];
            }
            int evenCnt = psum[pos] - oddCnt;
            long res = 0;
            for (int i = Math.Max(0, dict[pos] - evenCnt); i <= Math.Min(dict[pos], oddCnt); i++)
            {
                long ways = comb[oddCnt, i] * comb[evenCnt, dict[pos] - i] % MOD;
                res = (res + ways * Dfs(pos + 1, evenSum + i * pos, oddCnt - i) % MOD) % MOD;

            }
            memo[pos, evenSum, oddCnt] = (int)res;
            return (int)res;
        }

        return (int)Dfs(0, 0, maxOdd);
    }
}