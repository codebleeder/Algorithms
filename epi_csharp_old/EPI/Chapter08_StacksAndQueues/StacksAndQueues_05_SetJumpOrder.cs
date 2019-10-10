using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter8_StacksAndQueues
{
    public static class StacksAndQueues_05_SetJumpOrder
    {
        public static void SetJumpOrder(PostingListNode L)
        {
            SetJumpOrderHelper(L, 0);
        }

        private static int SetJumpOrderHelper(PostingListNode L, int order)
        {
            if (L != null && L.Order == -1)
            {
                L.Order = order++;
                order = SetJumpOrderHelper(L.Jump, order);
                order = SetJumpOrderHelper(L.Next, order);
            }
            return order;
        }
        public static void SetJumpOrder2(PostingListNode L)
        {
            var order = 0;
            var stack = new Stack<PostingListNode>();
            if (L != null)
            {
                stack.Push(L);
            }
            while (stack.Count > 0)
            {
                var curr = stack.Pop();
                if (curr.Order == -1)
                {
                    curr.Order = order++;
                    if (curr.Next != null)
                    {
                        stack.Push(curr.Next);
                    }
                    if (curr.Next != null)
                    {
                        stack.Push(curr.Jump);
                    }                    
                }
            }
        }
        public static void Test()
        {
            var a = new PostingListNode(0);
            var b = new PostingListNode(1);
            var c = new PostingListNode(2);
            var d = new PostingListNode(3);
            a.Jump = c;
            a.Next = b;

            b.Next = c;
            b.Jump = d;

            c.Next = d;
            c.Jump = b;

            d.Next = null;
            d.Jump = d;
           
            Console.WriteLine("printing the posting list before setting the jump order: ");
            PrintPostingList(a);
            SetJumpOrder2(a);
            Console.WriteLine($"after setting order: ");
            PrintPostingList(a);
        }
        private static void PrintPostingList(PostingListNode n)
        {
            var sb = new StringBuilder();
            while (n != null)
            {
                sb.Append($"[Data:{n.Data} Order:{n.Order}]->");
                n = n.Next;
            }
            Console.WriteLine(sb.ToString());
        }
    }
    public class PostingListNode
    {
        public int Data { get; set; }
        public PostingListNode Jump { get; set; }
        public PostingListNode Next { get; set; }
        public int Order { get; set; }
        public PostingListNode(int data)
        {
            Data = data;
            Order = -1;
        }
    }
}
