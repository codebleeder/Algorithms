using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter10_Heaps
{
    public static class Heaps_07_Stack
    {
        public static void Test()
        {
            var values = new List<int> { 23, 233, 12, 64, 74 };
            var stack = new Stack<int>();
            var stackUsingHeap = new StackUsingHeap<int>();
            foreach(var v in values)
            {
                stack.Push(v);
                stackUsingHeap.Push(v);
            }
            for(var i = 0; i < values.Count; i++)
            {
                var pop1 = stack.Pop();
                var pop2 = stackUsingHeap.Pop();
                var testRes = pop1 == pop2 ? "pass" : "fail";
                Console.WriteLine($"stack pop: {pop1}  using heap: {pop2}  result: {testRes}");
            }
        }
    }
    public class HeapEntryWithIndex<T>: IComparable<HeapEntryWithIndex<T>>
    {
        public int Index { get; set; }
        public T Value { get; set; }
        public HeapEntryWithIndex(T value, int index)
        {
            Value = value;
            Index = index;
        }

        public int CompareTo(HeapEntryWithIndex<T> other)
        {
            return Index.CompareTo(other.Index);
        }
    }
    public class StackUsingHeap<T>
    {
        public MaxPriorityQueue<HeapEntryWithIndex<T>> maxHeap { get; set; }
        public int Count { get { return maxHeap.Count; }  }
        public StackUsingHeap()
        {
            maxHeap = new MaxPriorityQueue<HeapEntryWithIndex<T>>();
        }
        public void Push(T data)
        {
            maxHeap.Enqueue(new HeapEntryWithIndex<T>(data, Count));
        }
        public T Pop()
        {
            return maxHeap.Dequeue().Value;
        }
        public T Peek()
        {
            return maxHeap.Peek().Value;
        }
    }
}
