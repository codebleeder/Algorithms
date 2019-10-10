using System;
using System.Collections.Generic;
using System.Text;
using static EPI.Chapter8_StacksAndQueues.StacksAndQueues_01_StackWithMax;

namespace EPI.Chapter8_StacksAndQueues
{
    public static class StacksAndQueues_10_QueueWithMax
    {
        public static void Test()
        {
            var q = new QueueWithMax2();
            var entries = new int[] { 3, 1, 3, 2, 0, 1, 2, 4, 4 };
            for (var i = 0; i < 6; i++)
            {
                q.Enqueue(entries[i]);
                Console.WriteLine($"enqueue {entries[i]}  max: {q.Max()}");
            }
            for (var i = 0; i < 2; i++)
            {                
                Console.WriteLine($"dequeue {q.Dequeue()}  max: {q.Max()}");
            }
            
            q.Enqueue(2);
            Console.WriteLine($"enqueue 2  max: {q.Max()}");

            q.Enqueue(4);
            Console.WriteLine($"enqueue 4  max: {q.Max()}");

            Console.WriteLine($"dequeue {q.Dequeue()}  max: {q.Max()}");

            q.Enqueue(4);
            Console.WriteLine($"enqueue 4  max: {q.Max()}");
        }
    }
    public class QueueWithMax
    {
        public Queue<int> MainQueue { get; private set; }
        public Queue<int> MaxQueue { get; private set; }       
        public QueueWithMax()
        {
            MainQueue = new Queue<int>();
            MaxQueue = new Queue<int>();            
            
        }
        public void Enqueue(int entry)
        {
            var count = MaxQueue.Count;
            for (var i = 0; i < count; i++)
            {
                var head = MaxQueue.Dequeue();
                if (head >= entry)
                {
                    MaxQueue.Enqueue(head);
                }
            }            
            MaxQueue.Enqueue(entry);
            MainQueue.Enqueue(entry);
        }
        public int Dequeue()
        {
            var res = MainQueue.Dequeue();
            if (res == MaxQueue.Peek())
            {
                MaxQueue.Dequeue();
            }
            return res;
        }
        public int Max()
        {
            return MaxQueue.Peek();
        }
    }
    public class QueueWithMax2
    {
        public StackWithMax2 EnqueueStack { get; set; }
        public StackWithMax2 DequeueStack { get; set; }
        public QueueWithMax2()
        {
            EnqueueStack = new StackWithMax2();
            DequeueStack = new StackWithMax2();
        }
        public void Enqueue (int entry)
        {
            EnqueueStack.Push(entry);
        }
        public int Dequeue()
        {
            if (DequeueStack.Count == 0)
            {
                while (EnqueueStack.Count > 0)
                {
                    DequeueStack.Push(EnqueueStack.Pop());
                }
            }
            return DequeueStack.Pop();
        }
        public int Max()
        {
            var enqueueMax = int.MinValue;
            var dequeueMax = int.MinValue;
            if (EnqueueStack.Count > 0)
            {
                enqueueMax = EnqueueStack.Max();
            }
            if (DequeueStack.Count > 0)
            {
                dequeueMax = DequeueStack.Max();
            }
            return Math.Max(enqueueMax, dequeueMax);
        }
    }
}
