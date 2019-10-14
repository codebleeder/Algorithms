using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter10_Heaps
{
    // for 'where' keyword, see: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/where-generic-type-constraint
    public abstract class PriorityQueue<T> where T: IComparable<T>
    {
        protected List<T> Data;
        public int Count
        {
            get
            {
                return Data.Count >= 2 ? Data.Count - 1 : 0;
            }
        }
        public PriorityQueue()
        {
            Data = new List<T>();
        }
        public abstract void Enqueue(T item);
        public abstract T Dequeue();
        public abstract List<T> GetData();
    }
    
    public static class TestPriorityQueue
    {
        public static void Test()
        {
            var maxPQ = new MaxPriorityQueue<int>();
            maxPQ.Enqueue(1);
            maxPQ.Enqueue(5);
            maxPQ.Enqueue(3);
            maxPQ.Enqueue(89);
            maxPQ.Enqueue(56);
            for (var i = 0; i < 5; i++)
            {
                var x = maxPQ.Dequeue();
                Console.WriteLine($"dequeue: {x} count: {maxPQ.Count}");
            }

            Console.WriteLine("min priority queue");
            var minPQ = new MinPriorityQueue<int>();
            minPQ.Enqueue(5);
            minPQ.Enqueue(2);
            minPQ.Enqueue(7);
            minPQ.Enqueue(3);
            minPQ.Enqueue(6);
            for (var i = 0; i < 5; i++)
            {
                var x = minPQ.Dequeue();
                Console.WriteLine($"dequeue: {x} count: {minPQ.Count}");
            }

            Console.WriteLine("test3");
            var list3 = new List<int> { 4, 7, 13, 1, 10, 12, 3, 8 };
            var minPQ3 = new MinPriorityQueue<int>();
            for (var i = 0; i < list3.Count; i++)
            {
                minPQ3.Enqueue(list3[i]);
            }
            for (var i = 0; i < 4; i++ )
            {
                var dequeueVal = minPQ3.Dequeue();
                Console.WriteLine($"dequeue: {dequeueVal}");
            }
            Utilities.PrintList(minPQ3.GetData());
        }
    }
}
