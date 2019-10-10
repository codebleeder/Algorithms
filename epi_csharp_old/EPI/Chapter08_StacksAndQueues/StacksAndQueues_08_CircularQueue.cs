using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter8_StacksAndQueues
{
    public static class StacksAndQueues_08_CircularQueue
    {
        public static void Test()
        {
            var q = new CircularQueue(5);
            for (var i = 1; i < 7; i++)
            {
                Console.WriteLine($"enqueue {i*10}");
                q.Enqueue(i*10);
            }
            for (var i = 0; i < 4; i++)
            {
                Console.WriteLine($"dequeue: count: {q.Count} value: {q.Dequeue()} ");
            }
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine($"enqueue {i * 20}");
                q.Enqueue(i * 20);
            }
            Console.WriteLine("entries: ");
            Utilities.PrintArray(q.Entries);
            Console.WriteLine($"head: {q.Head} tail: {q.Tail}");
        }
    }
    public class CircularQueue
    {
        public int[] Entries { get; set; }
        public int Head { get; private set; }
        public int Tail { get; private set; }
        public int Count { get; private set; }
        public int Capacity { get; private set; }
        private const int SCALE_FACTOR = 2;
        public CircularQueue(int capacity)
        {
            Entries = new int[capacity];
            Head = -1;
            Tail = -1;
            Count = 0;
            Capacity = capacity;
        }
        public void Enqueue(int entry)
        {
            if (Head > 0 && Tail == Capacity - 1)
            {
                // rotate 
                ResetHeadAndTail();
            }
            if (Count == Capacity)
            {
                // create a new array to accomodate new entry
                var temp = Entries;
                Array.Resize(ref temp, Count * SCALE_FACTOR);
                Entries = temp;
                Capacity = Count * SCALE_FACTOR;
            }
            Tail = (Tail + 1) % Entries.Length;
            Entries[Tail] = entry;
            Count++;
            if (Count == 1 && Tail == 0)
            {
                Head = 0;
            }
        }
        public int Dequeue()
        {
            var res = -1;
            if (Count != 0)
            {
                res = Entries[Head];
                Head = (Head + 1) % Entries.Length;
                Count--;
                return res;
            }
            throw new InvalidOperationException("Dequeue(): queue is empty");
        }
        private void ResetHeadAndTail()
        {
            var i = Head;
            for(var j = 0; j < Count; j++)
            {
                Entries[j] = Entries[i];
                i++;
            }
            Head = 0;
            Tail = Count-1;
        }
    }
}
