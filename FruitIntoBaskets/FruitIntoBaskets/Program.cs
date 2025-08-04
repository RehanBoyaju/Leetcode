Solution s = new Solution();
Console.WriteLine(s.TotalFruit([3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4]));

public class Solution
{
    public int TotalFruit(int[] fruits)
    {
        //longest continuos subarray that has 2 distinct elements

        int totalFruit = 0;
        int fruit = 0;

        int left = 0;
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int right = 0; right < fruits.Length; right++)
        {
            if (dict.ContainsKey(fruits[right]))
            {
                dict[fruits[right]]++;
            }
            else
            {
                dict[fruits[right]] = 1;
            }

            fruit++;


            while (dict.Count == 3)
            {

                dict[fruits[left]]--;
                if (dict[fruits[left]] == 0)
                {
                    dict.Remove(fruits[left]);
                }
                fruit--;
                left++;


            }
            totalFruit = Math.Max(totalFruit, fruit);


        }
        return totalFruit;
    }
}