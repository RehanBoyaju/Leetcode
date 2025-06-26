using System;

Solution s = new Solution();
Console.WriteLine(s.LongestSubsequence("1001010", 5));



public class Solution
{
    public int LongestSubsequence(string s, int k)
    {
        int n = s.Length;
        int bits = (int)(Math.Log(k, 2)) + 1;
        int count = 0;
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            char ch = s[n - i - 1];
            if (ch == '1')
            {
                if (i < bits && sum + (1 << i) <= k)
                {
                    sum += 1 << i;
                    count++;
                }
            }
            else
            {
                count++;
            }
        }

        return count;

    }
    //public int LongestSubsequence(string s, int k)
    //{
    //    int n = s.Length;
    //    int zeroes = 0;
    //    int ones = 0;
    //    foreach (char c in s)
    //    {
    //        if (c == '0')
    //        {
    //            zeroes++;
    //        }
    //        else
    //        {
    //            ones++;
    //        }
    //    }
    //    int num = 0;
    //    int count = 0;
    //    while (num <= k)
    //    {
    //        if (zeroes > 0)
    //        {
    //            zeroes--;
    //        }
    //        else
    //        {

    //            num = (num<<1) + 1;
    //            ones--;
    //        }
    //         count++;
    //    }

    //    return count-1; ;

    //}

}

    //public int LongestSubsequence(string s, int k)
    //{
    //    int n = s.Length;
    //    int[,] dp = new int[n + 1, k + 1];

    //    for (int i = n - 1; i >= 0; i--)
    //    {
    //        for (int j = k - 1; j >= 0; j--)
    //        {

    //            int newNum = (j << 1) + s[i] - '0';
    //            int include = 0;
    //            if (newNum <= k)
    //            {
    //                include = dp[i + 1, newNum] + 1;
    //            }

    //            int exclude = dp[i + 1, j];


    //            dp[i, j] = Math.Max(include, exclude);
    //        }
    //    }
    //    return dp[0, 0];

    //}
    //public int LongestSubsequence(string s, int k)
    //{
    //    int n = s.Length;
    //    Dictionary<(int, int), int> set = new Dictionary<(int, int), int>();
    //    int LBS(int index, int bitsUsed,int num)
    //    {
    //        if (set.ContainsKey((index, bitsUsed)))
    //        {
    //            return set[(index, bitsUsed)];
    //        }
    //        if (index == n || (1<<bitsUsed)>k)
    //        {
    //            return 0;
    //        }

    //        int newNum = (num << 1) + s[index] - '0';
    //        int include = 0;
    //        if (newNum <= k)
    //        {
    //            include = LBS(index + 1,bitsUsed+1, newNum) + 1;
    //        }

    //        int exclude = LBS(index + 1,bitsUsed, num);


    //        set[(index, bitsUsed)] = Math.Max(include, exclude);

    //        return set[(index, bitsUsed)];
    //    }


    //    return LBS(0,0,0);
    //}

    //public int LongestSubsequence(string s, int k)
    //{
    //    int n = s.Length;
    //    int LBS(int index, int num)
    //    {
    //        if (index == n || num > k)
    //        {
    //            return 0;
    //        }

    //        int newNum = (num << 1) + s[index] - '0';
    //        int include = 0;
    //        if (newNum <= k)
    //        {
    //            include = LBS(index + 1, newNum) + 1;
    //        }

    //        int exclude = LBS(index + 1, num);


    //        return Math.Max(include, exclude);
    //    }


    //    return LBS(0, 0);
    //}

//}

