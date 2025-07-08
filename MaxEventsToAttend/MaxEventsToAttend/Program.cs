using System.ComponentModel.DataAnnotations;

Solution s = new Solution();


Console.WriteLine(s.MaxEvents([[1, 2], [2, 2], [3, 3], [3, 4], [3, 4]]));
public class Solution
{
    public int MaxEvents(int[][] events)
    {
        int n = events.Length;
        int maxDay = 0;

        foreach(var e in events)
        {
            maxDay = Math.Max(maxDay, e[1]);
        }

        Array.Sort(events, (a, b) => a[0].CompareTo(b[0]));

        PriorityQueue<int, int> pq = new();
        int count = 0;
        for(int i = 1, j = 0; i <= maxDay; i++)
        {
            //Add the events that are currently ongoing
            while(j<n && events[j][0] <= i)
            {
                pq.Enqueue(events[j][1], events[j][1]);
                j++;
            }

            //Remove the events that are already pass their dates

            while(pq.Count > 0 && pq.Peek() < i) 
            {
                
                  pq.Dequeue();
                
            }
            if(pq.Count > 0)
            {
                pq.Dequeue();
                count++;
            }
        }

        return count;
        


    }
}
//[[1,2],[1,2],[3,3],[1,5],[1,5]]


//   1,2   1,2  
//    1       2       3       4       5