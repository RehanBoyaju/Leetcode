Solution s = new Solution();
Console.WriteLine(s.MaxFreeTime(5, 1, [1,3], [2,5]));
public class Solution
{
    public int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime)
    {
        int n = startTime.Length;
        int[] freeTimes = new int[n + 1];
        freeTimes[0] = startTime[0] - 0;
        freeTimes[n] = eventTime - endTime[n - 1];
        for (int i = 1; i < n; i++)
        {
            freeTimes[i] = startTime[i] - endTime[i - 1];
        }

        int maxFreeTime = 0;
        int freeTime = 0;

        for (int i = 0; i <= k; i++)
        {
            freeTime += freeTimes[i];
        }

        maxFreeTime = freeTime;

        for (int i = k + 1; i < freeTimes.Length; i++)
        {

            freeTime -= freeTimes[i - k - 1];
            freeTime += freeTimes[i];

            maxFreeTime = Math.Max(freeTime, maxFreeTime);
        }
        return maxFreeTime;
    }
}