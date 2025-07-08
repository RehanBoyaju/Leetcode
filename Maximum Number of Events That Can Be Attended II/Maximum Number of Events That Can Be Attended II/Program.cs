Solution s = new Solution();
    Console.WriteLine(s.MaxValue([[1, 1, 1], [2, 2, 2], [3, 3, 3], [4, 4, 4]], 3));
public class Solution
{
    public int MaxValue(int[][] events, int k)
    {
        Array.Sort(events, (a, b) => a[0] - b[0]);

        int n = events.Length;

        int Solve(int i, int count, int endDay)
        {
            if (i == n || count == k)
            {
                return 0;
            }

            int take = int.MinValue;
            if (events[i][0] > endDay)
            {
                take = events[i][2] + Solve(i + 1, count + 1, events[i ][1]);
            }

            int skip = Solve(i + 1, count, endDay);

            return Math.Max(take, skip);
        }

        return Solve(0, 0, 0);
    }
}