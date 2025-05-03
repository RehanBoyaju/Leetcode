Solution s = new Solution();
Console.WriteLine(s.MinDominoRotations(new int[] { 2, 1, 2, 4, 2, 2 }, new int[] { 5, 2, 6, 2, 3, 2 })); // Output: 1
public class Solution
{
    public int MinDominoRotations(int[] tops, int[] bottoms)
    {


        int n = tops.Length;

        int option1 = tops[0];
        int option2 = bottoms[0];

      

        int result = Check(tops, bottoms, n, option1);
        if(result != -1)
        {
            return result;
        }
        if(option1 != option2)
        {
            result = Check(tops, bottoms, n, option2);
        }

        return -1;
    }

    int Check(int[] tops, int[] bottoms, int n, int option)
    {
        int topCount = 0;
        int bottomCount = 0;
        for (int i = 0; i < n; i++)
        {
            if (tops[i] != option && bottoms[i]!=option)
            {
                return -1;
            }
            if (tops[i] != option)
            {
                topCount++;
            }
            if (bottoms[i] != option)
            {
                bottomCount++;
            }
        }
        return Math.Min(topCount,bottomCount);
    }
}