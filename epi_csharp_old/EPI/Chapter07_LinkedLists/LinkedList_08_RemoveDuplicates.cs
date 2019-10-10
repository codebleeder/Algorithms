using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter7_LinkedLists
{
    public static class LinkedList_08_RemoveDuplicates
    {
        // remove duplicates from a sorted linked list 
        public static void RemoveDuplicates(ListNode<int> head)
        {
            var builder = head;
            var iterator = head;
            while (iterator != null)
            {
                if (builder.Data != iterator.Data)
                {
                    builder.Next = iterator;
                    builder = builder.Next;
                }
                iterator = iterator.Next;
            }
            builder.Next = null;
        }
        public static void Test()
        {
            var head = ListNode<int>.BuildLinkedList(new int[] { 1, 1, 1, 2, 2, 3, 4, 5, 5, 5, 6, 7, 7 });
            Console.WriteLine("before removal of duplicates");
            ListNode<int>.Print(head);
            Console.WriteLine("after removal of duplicates");
            RemoveDuplicates(head);
            ListNode<int>.Print(head);

            var head2 = ListNode<int>.BuildLinkedList(new int[] { 1, 1});
            Console.WriteLine("before removal of duplicates");
            ListNode<int>.Print(head2);
            Console.WriteLine("after removal of duplicates");
            RemoveDuplicates(head2);
            ListNode<int>.Print(head2);
        }
    }
}
