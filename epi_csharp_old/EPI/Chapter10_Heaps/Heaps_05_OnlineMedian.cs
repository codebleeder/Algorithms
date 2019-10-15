using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter10_Heaps
{
    public static class Heaps_05_OnlineMedian
    {
        public static void OnlineMedian(IEnumerator<int> iter)
        {
            var firstHalf = new MaxPriorityQueue<int>();
            var secondHalf = new MinPriorityQueue<int>();
            while(iter.MoveNext())
            {
                secondHalf.Enqueue(iter.Current);
                firstHalf.Enqueue(secondHalf.Dequeue());
                if (firstHalf.Count > secondHalf.Count)
                {
                    secondHalf.Enqueue(firstHalf.Dequeue());
                }
                var res = secondHalf.Count == firstHalf.Count ? Avg(secondHalf.Peek(), firstHalf.Peek()) : (double)secondHalf.Peek();
                Console.WriteLine($"median: {res}");
            }
        }
        public static double Avg(int x, int y)
        {
            return (double)(x + y) / 2.0;
        }
        public static void Test()
        {
            var testList = new List<int> { 1, 0, 3, 5, 2, 0, 1 };
            var expected = new List<double> { 1, 0.5, 1, 2, 2, 1.5, 1 };
            OnlineMedian(testList.GetEnumerator());
            Utilities.PrintCollection(expected.GetEnumerator());
        }
    }
}
