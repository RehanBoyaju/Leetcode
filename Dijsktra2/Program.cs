Solution s = new Solution();
Console.WriteLine(s.MinTimeToReach(new int[][] {new int[] {0,4} , new int[] {4,4} }));
public class Solution
{
    public const int INF = 0x3f3f3f3f;
    public class State : IComparable<State>
    {
        public int x;
        public int y;
        public int dis;

        public State(int x, int y, int dis)
        {
            this.x = x;
            this.y = y;
            this.dis = dis;
        }
        public int CompareTo(State other)
        {
            return this.dis.CompareTo(other.dis);
        }
    }
    public int MinTimeToReach(int[][] moveTime)
    {
        int n = moveTime.Length;
        int m = moveTime[0].Length;
        int[,] d = new int[n, m];
        bool[,] v = new bool[n, m];

        var pq = new PriorityQueue<State, int>();

        var dirs = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                d[i, j] = INF;
            }
        }
        pq.Enqueue(new State(0, 0, 0), 0);
        d[0, 0] = 0;
        while (pq.Count > 0)
        {
            var curr = pq.Dequeue();
            if (v[curr.x, curr.y])
            {
                continue;
            }
            if (curr.x == n - 1 && curr.y == m - 1)
            {
                break;
            }
            v[curr.x, curr.y] = true;
            foreach (var dir in dirs)
            {
                int nx = curr.x + dir[0];
                int ny = curr.y + dir[1];

                if (nx < 0 || ny < 0 || nx >= n || ny >= m)
                {
                    continue;
                }
                int dist = Math.Max(d[curr.x, curr.y], moveTime[nx][ny]) + (curr.x + curr.y) % 2 + 1;

                if (d[nx, ny] > dist)
                {
                    d[nx, ny] = dist;
                    pq.Enqueue(new State(nx, ny, dist), dist);
                }
            }
        }
        return d[n - 1, m - 1];
    }
}