Solution s = new Solution();
Console.WriteLine(s.LongestSubsequenceRepeatedK("letsleetcode",2));

public class Solution
{
    public string LongestSubsequenceRepeatedK(string s, int k)
    {
        int n = s.Length;

        int[] freq = new int[26];

        foreach (char ch in s)
        {
            freq[ch - 'a']++;
        }

        List<char> candidate = new List<char>();
        Queue<string> q = new Queue<string>();

        for (int i = 25; i >= 0; i--)
        {
            if (freq[i] >= k)
            {
                char ch = (char)('a' + i);
                candidate.Add(ch);
                q.Enqueue(ch.ToString());
            }
        }

        string ans = "";

        while (q.Count > 0)
        {
            string curr = q.Dequeue();

            if (curr.Length > ans.Length)
            {
                ans = curr;
            }

            foreach (char ch in candidate)
            {
                string next = curr + ch;
                if (IsKRepeatedSubsequence(s, next, k))
                {
                    q.Enqueue(next);
                }
            }
        }

        return ans;




    }
    private bool IsKRepeatedSubsequence(string s, string t, int k)
    {

        int j = 0;
        int n = t.Length;
        int count = 0;
        foreach (char c in s)
        {
            if (c == t[j])
            {
                j++;

                if (j == n)
                {
                    j = 0;
                    count++;

                    if (count == k)
                    {
                        return true;
                    }
                }
            }


        }
        return false;
    }
    // t
    // l
    // e
    // {te,lt,le,et,ee}

    // curr = t
    // ans = t


    // next = t+t
    // next = t+e
    // next = t+l

    // curr = l
    // ans = t

    // next = l+t
    // next = l+l
    // next = l+e

    // curr = e
    // ans = t
    // next = e+t
    // next = e+l
    // next = e+e











}