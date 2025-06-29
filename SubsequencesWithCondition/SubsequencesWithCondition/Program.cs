using System.Globalization;

Solution s = new Solution();
Console.WriteLine(s.NumSubseq(new int[] {3,3,6,8},10));
public class Solution
{
    public int NumSubseq(int[] nums, int target)
    {
        int mod = 1000_000_007;

        Array.Sort(nums);

        int n = nums.Length;
        int right = n - 1;
        int left = 0;

        int res = 0;



        int[] power = new int[n];
        power[0] = 1;
        for (int i = 1; i < n; i++)
        {
            power[i] = (power[i - 1] * 2) % mod;
        }

        while (left <= right)
        {
            if (nums[left] + nums[right] <= target)
            {
                res = (res + power[right - left]) % mod;
                left++;
            }

            else
            {
                right--;
            }


        }
        return res;
    }
}


// n=1, 1

// n=2, 2

// n=3, 4

// n=4, 8

// n=5, 16

// 1,2 => 1,(1,2)
// 1,2,3 => 1,(1,2),(1,3),(1,2,3)
// 1,2,3,4 => 1,(1,2),(1,3),(1,4),(1,2,3),(1,2,4),(1,3,4),(1,2,3,4)
// 1,2,3,4,5 => 1,(1,2),(1,3),(1,4),(1,5),(1,2,3),(1,2,4),(1,2,5),(1,3,4),(1,3,5),(1,4,5),(1,2,3,4),(1,2,3,5),(1,2,4,5),(1,3,4,5),(1,2,3,4,5)