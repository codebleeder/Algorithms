using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter10_Heaps
{
    public static class Heaps_04_FindClosestKStars
    {
        public static List<Star> FindClosestKStars(int k, IEnumerator<Star> iter)
        {
            var res = new List<Star>();
            var maxHeap = new MaxPriorityQueue<Star>();

            // add first k stars to max heap
            while(k > 0)
            {
                if (iter.MoveNext())
                {
                    maxHeap.Enqueue(iter.Current);
                    k--;
                }                
            }
            // add rest of sequence by comparing with furthest star in max heap
            while (iter.MoveNext())
            {
                var farthest = maxHeap.Peek();
                if (farthest.Distance() > iter.Current.Distance())
                {
                    maxHeap.Dequeue();
                    maxHeap.Enqueue(iter.Current);
                }
            }
            // dequeue and add to results
            while (maxHeap.Count > 0)
            {
                res.Add(maxHeap.Dequeue());
            }
            return res;
        }
        public static void Test()
        {
            var stars = new List<Star>
            {
                new Star(1, 0, 0),
                new Star(0, 2, 0),
                new Star(0, 0, 11),
                new Star(12, 0, 0),
                new Star(0, 0, 3),
                new Star(4, 0, 0),
                new Star(0, 0, 7),
                new Star(8, 0, 0),
                new Star(9, 0, 0),
                new Star(0, 10, 0),                
                new Star(5, 0, 0),
                new Star(0, 6, 0),                
            };
            var iter = stars.GetEnumerator();
            for(var i = 1; i < 13; i++)
            {
                var res = FindClosestKStars(i, iter);
            }
        }
    }
    public class Star:IComparable<Star>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public Star(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public double Distance()
        {
            return Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
        }
        public int CompareTo(Star other)
        {            
            return this.Distance().CompareTo(other.Distance());
        }
    }
}
