namespace FindingPairsWithSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FindSumPairs s = new FindSumPairs(new int[] { 1, 1, 2, 2, 2, 3 } , new int[] { 1, 4, 5, 2, 5, 4 });
            Console.WriteLine(s.Count(7));
            s.Add(3,2);
            Console.WriteLine(s.Count(8));
            Console.WriteLine(s.Count(4));



        }
        public class FindSumPairs
        {
            private List<int> nums1;
            private List<int> nums2;
            Dictionary<int, int> dict;
            public FindSumPairs(int[] nums1, int[] nums2)
            {

                dict = new();
                this.nums1 = nums1.ToList();
                this.nums2 = nums2.ToList();

                foreach (int num in nums2)
                {
                    if (dict.ContainsKey(num))
                    {
                        dict[num]++;
                    }
                    else
                    {
                        dict[num] = 1;
                    }
                }

            }

            public void Add(int index, int val)
            {

                dict[nums2[index]]--;

                nums2[index] += val;

                dict[nums2[index]]++;

            }

            public int Count(int tot)
            {
                int count = 0;
                foreach (int num in nums1)
                {
                    int key = tot - num;
                    if (dict.ContainsKey(key))
                    {
                        count += dict[key];
                    }
                }
                return count;
            }
        }
        // 1 - 1
        // 4 - 3
        // 5 - 2
        // 2 - 0

        // 1,4,5,_4,5,4


        //  nums1 = [1,1,2,2,2,3] => List
        //  nums2 = [1,4,5,2,5,4] => Dictionary






    }
}
