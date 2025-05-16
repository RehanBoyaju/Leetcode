Solution s = new Solution();
var res = s.GetWordsInLongestSubsequence(new string[] { "ccd", "bb", "ccc" }, new int[] { 1, 1, 2 });
Console.WriteLine(string.Join(',', res));
public class Solution
{
    public IList<string> GetWordsInLongestSubsequence(string[] words, int[] groups)
    {
        IList<string> res = new();
        void Solve(int index, int prevIndex, IList<string> curr)
        {

            if (curr.Count > res.Count)
            {
                res = new List<string>(curr);
            }



            for (int i = index; i < words.Length; i++)
            {
                if (groups[prevIndex] != groups[i] && CheckHammingDistance(words[prevIndex], words[i]))
                {
                    curr.Add(words[i]);
                    Solve(i + 1, i, curr);
                    curr.RemoveAt(curr.Count - 1);
                }
            }



        }
        bool CheckHammingDistance(string word1, string word2)
        {
            if (word1.Length != word2.Length)
            {
                return false;
            }
            int count = 0;
            for (int i = 0; i < word1.Length; i++)
            {
                if (word1[i] != word2[i])
                {
                    if (count == 1)
                    {
                        return false;
                    }
                    count++;
                }

            }
            return true;
        }
        for (int i = 0; i < words.Length; i++)
        {
            Solve(i + 1, i, new List<string>() { words[i] });
        }

        return res;
    }
}