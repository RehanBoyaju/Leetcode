Solution s = new Solution();
var res = s.GetWordsInLongestSubsequence(new string[] { "a", "b", "c", "d" } , new int[] { 1, 2, 3,4 });
Console.WriteLine(string.Join(',',res));
public class Solution
{
    public IList<string> GetWordsInLongestSubsequence(string[] words, int[] groups)
    {
        IList<string> res = new List<string>();
        void Solve(int index, int prevGroup, string prevWord, IList<string> curr)
        {
            if (index == words.Length)
            {
                if (curr.Count > res.Count)
                {
                    res = new List<string>(curr);
                }
                return;
            }
            if (words[index].Length != prevWord.Length || groups[index] == prevGroup)
            {
                return;
            }

            for (int i = index ; i < words.Length; i++)
            {
                if (prevGroup != groups[i] && CheckHammingDistance(prevWord, words[index]))
                {
                    curr.Add(words[index]);
                    Solve(i + 1, groups[i], words[i], curr);
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
        Solve(1, groups[0], words[0], new List<string>() { words[0] });
        return res;
    }
}