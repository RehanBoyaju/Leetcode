Solution s = new Solution();
    Console.WriteLine(s.MaxValue([[1, 1, 1], [2, 2, 2], [3, 3, 3], [4, 4, 4]], 3));
public class Solution
{
    public int MaxValue(int[][] events, int k)
    {
        Array.Sort(events, (a, b) => a[0] - b[0]);

        int n = events.Length;
        int[][] dp = new int[n + 1][];

        for (int i = 0; i <= n; i++)
        {
            dp[i] = new int[k + 1];
        }

       
        for(int i = n-1; i >=0; i--)
        {
            int next = BinarySearch(i + 1, events[i][1]);

            for (int j = k-1; j >= 0; j--)
            {
                int take = events[i][2] + dp[next][ j + 1];
                int skip = dp[i + 1][j];
                dp[i][j] = Math.Max(take, skip);

            }
        }

        int BinarySearch(int left, int prevEnd)
        {
            int right = n;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (events[mid][0] > prevEnd)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }
        return dp[0][0];
    }
}