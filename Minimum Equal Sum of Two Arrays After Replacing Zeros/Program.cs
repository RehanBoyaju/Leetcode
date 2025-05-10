
Solution s = new Solution();
Console.WriteLine(s.MinSum(new int[] { 20, 0, 18, 11, 0, 0, 0, 0, 0, 0, 17, 28, 0, 11, 10, 0, 0, 15, 29 }, new int[] { 16, 9, 25, 16, 1, 9, 20, 28, 8, 0, 1, 0, 1, 27 })); // Output: 169
public class Solution
{
    public long MinSum(int[] nums1, int[] nums2)
    {
        long sum1 = 0;
        long sum2 = 0;
        long zeroes1 = 0;
        long zeroes2 = 0;

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
        
       
        if(zeroes1 == 0 && zeroes2 == 0)
        {
            return sum1 == sum2 ? sum1 : -1;
        }
        else if (zeroes1 == 0)
        {
            if (sum1 < sum2 || (sum1-sum2)<zeroes2)
            {
                return -1;
            }
            
            return sum1;
        }
        else if (zeroes2 == 0)
        {
            if (sum2 < sum1 || (sum2-sum1) < zeroes1)
            {
                return -1;
            }
            
            return sum2;
        }
      

       return Math.Max(sum1 + zeroes1, sum2 + zeroes2);
               

    }
}