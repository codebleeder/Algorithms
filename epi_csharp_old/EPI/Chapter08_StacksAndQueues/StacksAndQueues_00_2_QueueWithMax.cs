using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter8_StacksAndQueues
{
    public static class StacksAndQueues_00_2_QueueWithMax
    {
        public class QueueWithMax: Queue<int>
        {
           

            public int Max()
            {
                var max = 0;
                var iter = this.GetEnumerator();
                while (iter.MoveNext())
                {
                    max = max < iter.Current ? iter.Current : max;
                }
                return max;
            }
        }
        public static void Test()
        {
            var q = new QueueWithMax();
            var arr = new int[] { 5, 3, 7, 8, 3 };
            foreach (var i in arr)
            {
                q.Enqueue(i);
            }
            Console.WriteLine($"max: {q.Max()}  expected: 8");
        }
    }
}
