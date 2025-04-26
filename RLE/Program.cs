using System.Text;

Solution s = new Solution();
Console.WriteLine(s.CountAndSay(4)); // Output: "1211"
    public class Solution
    {
        public string CountAndSay(int n)
        {
            string res = "1";
            if (n == 1) return res;

            for (int i = 1; i < n; i++)
            {
                res = RLE(res);
            }
            return res;
        }
        private string RLE(string str)
        {
            StringBuilder res = new StringBuilder();

            int index = 1;
            char currentChar = str[0];
            int freq = 1;
            while (index < str.Length)
            {
                if (str[index] == currentChar)
                {
                    freq++;
                }
                else
                {
                    res.Append(freq.ToString() + currentChar);
                    currentChar = str[index];
                    freq = 1;
                }
                index++;
            }

            res.Append(freq.ToString() + currentChar);

            return res.ToString();

        }
}