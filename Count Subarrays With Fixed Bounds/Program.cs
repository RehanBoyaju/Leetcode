Solution s = new Solution();
Console.WriteLine(s.CountSubarrays(new int[] { 1, 3, 5, 2, 7, 5 }, 1, 5)); // Output: 2 
public class Solution
{
    public long CountSubarrays(int[] nums, int minK, int maxK)
    {
        int minIndex = -1;
        int maxIndex = -1;
        int count = 0;
        int start = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < minK || nums[i] > maxK)
            {
                start = i+1;
                minIndex = -1;
                maxIndex = -1;
                continue;
            }
            if (nums[i] == minK)
            {
                minIndex = i;
            }
            if (nums[i] == maxK)
            {
                maxIndex = i;
            }
            count += Math.Max(0, Math.Min(minIndex, maxIndex - start + 1));
        }
        return count;
    }
}