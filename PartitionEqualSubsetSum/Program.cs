public class Solution
{
    public bool CanPartition(int[] nums)
    {
        int totalSum = nums.Sum();
        if (totalSum % 2 != 0) return false;

        int target = totalSum / 2;
        int n = nums.Length;

        bool[,] dp = new bool[n + 1, target + 1];

        // Base case: sum 0 is always achievable (by picking nothing)
        for (int i = 0; i <= n; i++)
            dp[i, 0] = true;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= target; j++)
            {
                if (j < nums[i - 1])
                {
                    dp[i, j] = dp[i - 1, j]; // can't include nums[i-1]
                }
                else
                {
                    dp[i, j] = dp[i - 1, j] || dp[i - 1, j - nums[i - 1]];
                }
            }
        }

        return dp[n, target];
    }
}
