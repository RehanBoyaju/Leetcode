Solution s = new Solution();
Console.WriteLine(s.MinSum(new int[] { 2, 0, 2, 0 }, new int[] { 1, 4 })); // Output: -1
public class Solution
{
    public long MinSum(int[] nums1, int[] nums2)
    {
        int sum1 = 0;
        int sum2 = 0;
        int zeroes1 = 0;
        int zeroes2 = 0;

        foreach (int num in nums1)
        {
            if (num == 0)
            {
                zeroes1++;
            }
            else
            {
                sum1 += num;
            }
        }
        foreach (int num in nums2)
        {
            if (num == 0)
            {
                zeroes2++;
            }
            else
            {
                sum2 += num;
            }
        }

        // sum1 = 6 (+ 6)
        // sum2 = 11 (+ 1);
        // zeroes1 = 2;
        // zeroes2 = 1;

        if (zeroes1 == 0)
        {
            if (sum1 < sum2)
            {
                return -1;
            }
            int diff = sum1-sum2;
            if (diff < zeroes2)
            {
                return -1;
            }
            return sum1;
        }
        if (zeroes2 == 0)
        {
            if (sum2 < sum1)
            {
                return -1;
            }
            int diff = sum2 - sum1;
            if (diff < zeroes1)
            {
                return -1;
            }
            return sum2;
        }

        if (sum1 < sum2)
        {
            return sum2 + zeroes2;
        }

        if (sum2 < sum1)
        {
            return sum1 + zeroes1;
        }

        return Math.Min((sum1 + zeroes1), (sum2 + zeroes2));





    }
}