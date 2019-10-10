using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter7_LinkedLists
{
    public static class LinkedList_02_ReverseSubList
    {
        // not using c# LinkedList as it is a doubly/bidirectional linked list 
        // assuming start and finish are 1 based indices
        public static ListNode<int> ReverseSublist(ListNode<int> n, int start, int finish)
        {
            var dummyHead = new ListNode<int>(0, n);
            var sublistHead = dummyHead;
            var i = 1;
            while (i++ < start)
            {
                sublistHead = sublistHead.Next;
            }
            var sublistIter = sublistHead.Next;
            while (start++ < finish)
            {
                ListNode<int> temp = sublistIter.Next;
                sublistIter.Next = temp.Next;
                temp.Next = sublistHead.Next;
                sublistHead.Next = temp;
            }
            return dummyHead.Next;
        }
        public static void Test()
        {
            var values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var head = new ListNode<int>(values[0]);
            var current = head;
            for (var i = 1; i < values.Length; i++)
            {
                current.Next = new ListNode<int>(values[i]);
                current = current.Next;
            }
            // reversing sublist from values 4 to 6
            var res = ReverseSublist(head, 4, 6);
            Console.WriteLine("sublist 4, 5, 6 should be reversed");
            ListNode<int>.Print(res);
        }
    }
}
