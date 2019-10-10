using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter7_LinkedLists
{
    public static class LinkedList_09_CyclicRightShift
    {
        public static ListNode<int> CyclicRightShift(ListNode<int> head, int k)
        {
            if (head == null)
            {
                return null;
            }
            // determine total length
            var iAdvanced = head;
            var length = 0;
            while (iAdvanced != null)
            {
                iAdvanced = iAdvanced.Next;
                length++;
            }
            k %= length;
            iAdvanced = head;
            while (k-- > 0)
            {
                iAdvanced = iAdvanced.Next;
            }
            var newHead = head;
            while (iAdvanced.Next != null)
            {
                iAdvanced = iAdvanced.Next;
                newHead = newHead.Next;
            }
            
            iAdvanced.Next = head;
            var result = newHead.Next;
            newHead.Next = null;
           
            return result;
        }
        public static void Test()
        {
            var head = ListNode<int>.BuildLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            // circular shift right by 3
            Console.WriteLine("original list: ");
            ListNode<int>.Print(head);
            Console.WriteLine("result: ");
            var result = CyclicRightShift(head, 8);
            ListNode<int>.Print(result);
        }
    }
}
