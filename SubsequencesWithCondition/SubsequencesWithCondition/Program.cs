Solution s = new Solution();
Console.WriteLine(s.NumSubseq(new int[] {3,3,6,8},10));
public class Solution
{
    public int NumSubseq(int[] nums, int target)
    {
        int mod = 1000_000_007;
        int right = 0;
        int res = 0;
        for (int left = 0; left < nums.Length; left++)
        {
            if (nums[left] + nums[right] <= target)
            {
                while (right < nums.Length && nums[left] + nums[right] <= target)
                {
                    right++;
                }
                res += (right - left + 1) % mod;
            }

            right = left + 1;


        }
        return res;
    }
}