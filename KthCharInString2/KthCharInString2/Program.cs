namespace KthCharInString2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.KthCharacter(4,new int[] {0,0,1}));
        }
        public class Solution
        {
            public char KthCharacter(long k, int[] operations)
            {
                
                
                int count = 0, t;
                while (k != 1)
                {
                    t = (int)Math.Log(k, 2);

                    if (k == (1 << t))
                    {
                        t--;
                    }
                    
                        k -= (1<<t);
                    
                    
                    count += operations[t];
                }
                return (char)('a' + count % 26);
            }
        }
    }
}
