using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter10_Heaps
{
    public static class Heaps_06_KLargestInBinaryHeap
    {
        public static List<int> KLargestInBinaryHeap(List<int> heap, int k)
        {
            if (k <= 0)
            {
                return new List<int>();
            }
            var candidateHeapMax = new MaxPriorityQueue<HeapEntry>();
            var res = new List<int>();
            candidateHeapMax.Enqueue(new HeapEntry(0, heap[0]));
            for ( var i = 0; i < k; i++ )
            {
                var candidateIndex = candidateHeapMax.Peek().Index;
                res.Add(candidateHeapMax.Dequeue().Value);

                var leftChildIndex = candidateIndex * 2 + 1;
                if (leftChildIndex < heap.Count)
                {
                    candidateHeapMax.Enqueue(new HeapEntry(leftChildIndex, heap[leftChildIndex]));
                }
                var rightChildIndex = candidateIndex * 2 + 2;
                if (rightChildIndex < heap.Count)
                {
                    candidateHeapMax.Enqueue(new HeapEntry(rightChildIndex, heap[rightChildIndex]));
                }
            }
            return res;
        }
        class HeapEntry: IComparable<HeapEntry>
        {
            public int Index { get; set; }
            public int Value { get; set; }
            public HeapEntry(int index, int value)
            {
                Index = index;
                Value = value;
            }

            public int CompareTo(HeapEntry other)
            {
                return Value.CompareTo(other.Value);
            }
        }
        public static void Test()
        {
            var heap = new List<int> { 561, 314, 401, 28, 156, 359, 271, 11, 3 };
            var res = KLargestInBinaryHeap(heap, 4);
            Utilities.PrintCollection<int>(res.GetEnumerator());
        }
    }
}
