using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter7_LinkedLists
{
    public static class LinkedList_11_IsPalindrome
    {
        public static bool IsPalindrome(ListNode<int> head)
        {
            // basic corner cases
            if (head == null)
            {

                return false;
            }
            else if (head.Next == null)
            {
                return true;
            }
            else if (head.Next != null && head.Next.Next == null)
            {
                // there are only 2 nodes
                return head.Data == head.Next.Data;
            }
            var slow = head;
            var fast = head; 
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            
            // reverse list after slow 
            var iter = slow.Next;
            while (iter.Next != null)
            {
                var temp = iter.Next;
                iter.Next = temp.Next;
                temp.Next = slow.Next;
                slow.Next = temp;               
            }
            Console.WriteLine("half reversed: ");
            ListNode<int>.Print(head);
            // compare head and slow onwards
            slow = slow.Next;
            while (slow != null)
            {
                if (head.Data != slow.Data)
                {
                    return false;
                }
                head = head.Next;
                slow = slow.Next;
            }
            return true;
        }
        public static void Test()
        {
            var tests = new List<Tuple<int[], bool>>
            {
                new Tuple<int[], bool>(new int[] { 1,2,3,4,3,2,1 }, true),
                new Tuple<int[], bool>(new int[] { 1,2,3,3,2,1 }, true),
                new Tuple<int[], bool>(new int[] { 1, 1 }, true),
                new Tuple<int[], bool>(new int[] { 1,2,3,3,4,1 }, false)
            };
            var i = 1;
            foreach(var test in tests)
            {
                Console.WriteLine($"test {i} expected: {test.Item2}");
                Console.WriteLine($"result: {IsPalindrome(ListNode<int>.BuildLinkedList(test.Item1))}");
                i++;
            }
        }
    }
}
