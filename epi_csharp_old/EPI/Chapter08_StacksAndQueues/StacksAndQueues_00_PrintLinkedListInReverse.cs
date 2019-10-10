using EPI.Chapter7_LinkedLists;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter8_StacksAndQueues
{
    public static class StacksAndQueues_00_PrintLinkedListInReverse
    {
        public static void PrintLinkedListInReverse(ListNode<int> head)
        {
            var stack = new Stack<int>();
            while (head != null)
            {
                stack.Push(head.Data);
                head = head.Next;
            }
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
        public static void Test()
        {
            var head = ListNode<int>.BuildLinkedList(new int[] { 1, 2, 3, 4, 5, 6 });
            PrintLinkedListInReverse(head);
        }
    }
}
