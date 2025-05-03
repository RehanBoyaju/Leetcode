Solution s = new Solution();
Console.WriteLine(s.MinDominoRotations(new int[] { 1, 2, 1, 1, 1, 2, 2, 2 }, new int[] { 2, 1, 2, 2, 2, 2, 2, 2 })); // Output: 1
public class Solution
{
    public int MinDominoRotations(int[] tops, int[] bottoms)
    {


        int n = tops.Length;

        int option1 = tops[0];
        int option2 = bottoms[0];

        int count1 = 0;
        int count2 = 0;
        for (int i = 1; i < n; i++)
        {
            if (tops[i] == option1)
            {
                continue;
            }
            if (bottoms[i] == option1)
            {
                count1++;
            }
            else
            {
                count1 = -1;
                break;
            }
        }
        for (int i = 1; i < n; i++)
        {
             if(bottoms[i] == option2){
                continue;
            }
            if (tops[i] == option2)
            {
                count2++;
            }
            else
            {
                count2 = -1;
                break;
            }
        }

        if (count1 == -1 && count2 == -1)
        {
            return -1;
        }
        if(count1 == -1)
        {
            return count2;
        }
        if(count2== -1)
        {
            return count1;
        }
        return Math.Min(count1, count2);
    }
}