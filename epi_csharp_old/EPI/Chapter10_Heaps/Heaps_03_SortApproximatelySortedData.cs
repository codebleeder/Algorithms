using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter10_Heaps
{
    public static class Heaps_03_SortApproximatelySortedData
    {
        public static List<int> SortApproximatelySortedData(IEnumerator<int> sequence, int k)
        {
            var iWriter = sequence;
            var minPQ = new MinPriorityQueue<int>();
            var res = new List<int>();

            // add first k elements
            while (k > 0)
            {
                if(sequence.MoveNext())
                {
                    minPQ.Enqueue(sequence.Current);
                    k--;
                }                
            }

            // add rest of the elements and extract from minPQ
            while(sequence.MoveNext())
            {
                minPQ.Enqueue(sequence.Current);
                res.Add(minPQ.Dequeue());
                
            }

            // extract rest from minPQ
            while (minPQ.Count > 0)
            {
                res.Add(minPQ.Dequeue());
            }
            return res;
        }
        public static void Test()
        {
            var test = new List<int> { 3, -1, 2, 6, 4, 5, 8 };
            var iter = test.GetEnumerator();
            var res = SortApproximatelySortedData(iter, 2);
            Utilities.PrintList(res);
        }
    }
}
