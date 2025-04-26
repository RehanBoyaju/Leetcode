Solution s = new Solution();
Console.WriteLine(s.MinimumOperations(new int[] { 1, 2, 3, 4, 2, 3, 3, 5, 7 }));

public class Solution
{
    public int MinimumOperations(int[] nums)
    {
        Dictionary<int, int> dict = new();
        bool IsDistinct(int index, int count)
        {
            bool IsDistinct = true;
            for (int i = index; i < index + count; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                    IsDistinct = false;
                }
                else
                {
                    dict[nums[i]] = 1;
                }
            }
            return IsDistinct;

        }

        int n = nums.Length;
        if (n <= 3)
        {
            if (IsDistinct(0, n))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        int checkLastIndices = n % 3 == 0 ? 3 : n % 3;
        if (!IsDistinct(n - checkLastIndices, checkLastIndices))
        {
            return (int)Math.Ceiling(n / 3.0);
        }

        for (int i = n - checkLastIndices - 3; i >= 0; i = i - 3)
        {
            if (!IsDistinct(i, 3))
            {
                return (int)Math.Ceiling((i + 1) / 3.0);
            }
        }

        return 0;


    }
}