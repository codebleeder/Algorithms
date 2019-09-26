using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter7_LinkedLists
{
    public static class LinkedList_10_EvenOddMerge
    {
        public static void EvenOddMerge(ListNode<int> head)
        {
            if (head == null || head.Next == null)
            {
                return;
            }
            var evenTail = head;
            var oddTail = head.Next;
            var oddHead = head.Next;
            var i = 0;
            while (head != null)
            {
                if (i > 1 && i % 2 == 0)
                {
                    evenTail.Next = head;
                    evenTail = evenTail.Next;
                }
                else if (i > 1 && i % 2 != 0)
                {
                    oddTail.Next = head;
                    oddTail = oddTail.Next;
                }
                head = head.Next;
                i++;
            }
            evenTail.Next = oddHead;
            oddTail.Next = null;
        }
        public static void Test()
        {
            var head = ListNode<int>.BuildLinkedList(new int[] { 0, 1, 2, 3, 4, 5, 6 });
            Console.WriteLine("before merge: ");
            ListNode<int>.Print(head);
            Console.WriteLine("after merge: ");
            EvenOddMerge(head);
            ListNode<int>.Print(head);
        }
    }
}
