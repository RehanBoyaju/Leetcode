Solution s = new Solution();
    Console.WriteLine(s.MaxValue([[1, 1, 1], [2, 2, 2], [3, 3, 3], [4, 4, 4]], 3));
public class Solution
{
    public int MaxValue(int[][] events, int k)
    {
        Array.Sort(events, (a, b) => a[0] - b[0]);

        int n = events.Length;
        int[][] dp = new int[n + 1][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[k + 1];
            Array.Fill(dp[i], -1);
        }

        int Solve(int i, int count)
        {
            if (i == n || count == k)
            {
                return 0;
            }
            if (dp[i][count] != -1)
            {
                return dp[i][count];
            }

            int next = BinarySearch(i + 1, events[i][1]);

            int take = events[i][2] + Solve(next, count + 1);
            int skip = Solve(i + 1, count);
            int res = Math.Max(take, skip);

            dp[i][count] = res;
            return res;
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
        return Solve(0, 0);
    }
}