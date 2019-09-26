using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter7_LinkedLists
{
    public static class LinkedList_07_RemoveKthLast
    {
        public static void RemoveKthLast(ListNode<int> head, int k)
        {
            var dummyHead = new ListNode<int>(0);
            dummyHead.Next = head;
            var first = dummyHead.Next;
            while (k-- > 0)
            {
                first = first.Next;
            }
            var second = dummyHead;
            while (first != null)
            {
                first = first.Next;
                second = second.Next;
            }
            // second's successor will be deleted 
            second.Next = second.Next.Next;
        }
        public static void Test()
        {
            var head = ListNode<int>.BuildLinkedList(new int[] { 1, 2, 3, 4, 5, 6 });
            // delete node 6, k=1
            RemoveKthLast(head, 1);
            ListNode<int>.Print(head);
            // delete node 3, k=3
            RemoveKthLast(head, 3);
            ListNode<int>.Print(head);
        }
    }
}
