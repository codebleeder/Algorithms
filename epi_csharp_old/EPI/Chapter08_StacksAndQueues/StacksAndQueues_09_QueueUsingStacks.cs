using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter8_StacksAndQueues
{
    public static class StacksAndQueues_09_QueueUsingStacks
    {
        public static void Test()
        {
            var q = new QueueUsingStacks();
            for (var i = 1; i < 7; i++)
            {
                Console.WriteLine($"enqueue {i * 10}");
                q.Enqueue(i * 10);
            }
            for (var i = 0; i < 4; i++)
            {
                Console.WriteLine($"dequeue:  value: {q.Dequeue()} ");
            }
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine($"enqueue {i * 20}");
                q.Enqueue(i * 20);
            }            
            for (var i = 0; i < 8; i++)
            {
                Console.WriteLine($"dequeue:  value: {q.Dequeue()} ");
            }
        }
    }
    public class QueueUsingStacks
    {
        public Stack<int> EnqueueStack { get; private set; }
        public Stack<int> DequeueStack { get; private set; }
        public QueueUsingStacks()
        {
            EnqueueStack = new Stack<int>();
            DequeueStack = new Stack<int>();
        }
        public void Enqueue(int entry)
        {
            EnqueueStack.Push(entry);
        }
        public int Dequeue()
        {            
            if (EnqueueStack.Count > 0 && DequeueStack.Count == 0)
            {
                while (EnqueueStack.Count > 0)
                {
                    DequeueStack.Push(EnqueueStack.Pop());
                }                
            }
            if (DequeueStack.Count > 0)
            {
                return DequeueStack.Pop();
            }
            throw new NullReferenceException($"Dequeue(): stack is empty; EnqueueStack: {EnqueueStack.Count}; Dequeue: {DequeueStack.Count}");
        }
    }
}
