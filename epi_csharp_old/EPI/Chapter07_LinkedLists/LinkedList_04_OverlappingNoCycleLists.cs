using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter7_LinkedLists
{
    public static class LinkedList_04_OverlappingNoCycleLists
    {
        public static ListNode<int> OverlappingNoCycleLists(ListNode<int> head1, ListNode<int> head2)
        {
            var length1 = ListNode<int>.Length(head1);
            var length2 = ListNode<int>.Length(head2);
            
            if (length1 > length2)
            {
                head1 = ListNode<int>.MoveByK(head1, length1 - length2);
            }
            else
            {
                head2 = ListNode<int>.MoveByK(head2, length2 - length1);
            }
            while (head1 != head2 && head1 != null && head2 != null)
            {
                head1 = head1.Next;
                head2 = head2.Next;
            }
            return head1;
        }
        
        public static void Test()
        {
            // non overlapping
            var a1 = ListNode<int>.BuildLinkedList(new int[] { 1, 2 });
            var a2 = ListNode<int>.BuildLinkedList(new int[] { 1, 2, 3, 4 });
            var res = OverlappingNoCycleLists(a1, a2);
            if (res == null)
            {
                Console.WriteLine("test 1 passed; no overlap");
            }
            else
            {
                Console.WriteLine($"test 1 failed; shows overlap in {res.Data}");
            }

            // overlapping
            var nodeToJoin = ListNode<int>.MoveByK(a1, 1);
            var commonNode = ListNode<int>.MoveByK(a2, 1);
            nodeToJoin.Next = commonNode;
            var res2 = OverlappingNoCycleLists(a1, a2);
            if (res2 != null)
            {
                Console.WriteLine($"test 2 passed; shows overlap in {res2.Data}");
            }
            else
            {
                Console.WriteLine("test 2 failed; returned null node");
            }
        }
    }
}
