using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter7_LinkedLists
{
    public static class LinkedList_01_MergeTwoSortedLists
    {
        public static LinkedList<int> MergeTwoSortedLists(LinkedListNode<int> n1, LinkedListNode<int> n2)
        {            
            var result = new LinkedList<int>();
            
            while (n1 != null && n2 != null)
            {
                if (n1.Value <= n2.Value)
                {
                    var newNode = new LinkedListNode<int>(n1.Value);
                    result.AddLast(newNode);
                    n1 = n1.Next;
                }
                else
                {
                    var newNode = new LinkedListNode<int>(n2.Value);
                    result.AddLast(newNode);
                    n2 = n2.Next;
                }
            }
            
            if (n1 != null)
            {
                var newNode = new LinkedListNode<int>(n1.Value);
                result.AddLast(newNode);
            }
            else
            {
                var newNode = new LinkedListNode<int>(n2.Value);
                result.AddLast(newNode);
            }
            return result;
        }
        public static ListNode<int> MergeTwoSortedLists(ListNode<int> n1, ListNode<int> n2)
        {
            var dummyHead = new ListNode<int>(-1);
            var current = dummyHead;
            while (n1 != null && n2 != null)
            {
                if (n1.Data <= n2.Data)
                {
                    current.Next = n1;
                    n1 = n1.Next;
                }
                else
                {
                    current.Next = n2;
                    n2 = n2.Next;
                }
                current = current.Next;
            }
            if (n1 == null)
            {
                current.Next = n2;
            }
            else
            {
                current.Next = n1;
            }
            return dummyHead.Next;
        }
        public static void Test()
        {
            var a1 = new int[] { 2, 5, 7 };
            var a2 = new int[] { 3, 11 };
            var l1 = new LinkedList<int>(a1);
            var l2 = new LinkedList<int>(a2);
            var res = MergeTwoSortedLists(l1.First, l2.First);
            Utilities.PrintLinkedList(res);

            Console.WriteLine("using ListNode: ");
            var n1 = ListNode<int>.BuildLinkedList(a1);
            var n2 = ListNode<int>.BuildLinkedList(a2);
            var res2 = MergeTwoSortedLists(n1, n2);
            ListNode<int>.Print(res2);
        }
    }
}
