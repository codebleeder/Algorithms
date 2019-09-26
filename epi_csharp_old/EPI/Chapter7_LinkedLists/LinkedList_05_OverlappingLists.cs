using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter7_LinkedLists
{
    public static class LinkedList_05_OverlappingLists
    {
        public static ListNode<int> OverlappingLists(ListNode<int> n1, ListNode<int> n2)
        {
            // check if each linked list is cyclic 
            var root1 = LinkedList_03_HasCycle.HasCycle(n1);
            var root2 = LinkedList_03_HasCycle.HasCycle(n2);

            // if one of the roots is null then they are disjoint lists
            if ((root1 == null && root2 != null) ||
                (root1 != null && root2 == null))
            {
                return null;
            }

            // both lists have cycles
            var temp = root1;
            do
            {
                temp = temp.Next;
            }
            while (temp != root1 && temp != root2);
            if (temp != root2)
            {
                return null; // no common cycle, thus disjoint
            }

            // both have common cycle
            // compute stem lengths and check if they merge before cycle starts
            var stemLength1 = ListNode<int>.Length(n1, root1);
            var stemLength2 = ListNode<int>.Length(n2, root2);

            if (stemLength1 > stemLength2)
            {
                n1 = ListNode<int>.MoveByK(n1, stemLength1 - stemLength2);
            }
            else
            {
                n2 = ListNode<int>.MoveByK(n2, stemLength2 - stemLength1);
            }
            while (n1 != n2 && n1 != root1 && n2 != root2)
            {
                n1 = n1.Next;
                n2 = n2.Next;
            }
            return n1 == n2 ? n1 : root1;
        }
        public static void Test()
        {
            var n1 = ListNode<int>.BuildLinkedList(new int[] { 1, 2 });
            var n2 = ListNode<int>.BuildLinkedList(new int[] { 3, 4, 5, 6 });
            var results = new List<string>();
            // case 1: one is cyclic and other is not. Disjoint        
            var n2_6 = n2;
            n2_6 = ListNode<int>.MoveByK(n2_6, 3);
            n2_6.Next = n2;
            var resCase1 = OverlappingLists(n1, n2);
            var testRes1 = resCase1 == null ? "case 1 passed" : $"case 1 failed; they merge at {resCase1.Data}";
            results.Add(testRes1);

            // case 2: both are cyclic but disjoint
            n1.Next.Next = n1;
            var resCase2 = OverlappingLists(n1, n2);
            var testRes2 = resCase2 == null ? "case 2 passed" : $"case 2 failed; they merge at {resCase2.Data}";
            results.Add(testRes2);

            // case 3: have a common cycle; merge before cycle
            var n2_5 = n2.Next.Next;
            n2_6 = n2_5.Next;
            n2_6.Next = n2_5;
            n1.Next.Next = n2.Next;
            var resCase3 = OverlappingLists(n1, n2);
            results.Add(resCase3 != null ? $"case 3 passed; they merge at {resCase3.Data} expected to merge at: 4" : $"case 3 failed; returned null");

            // case 4: have a common cycle; merge at different nodes at the cycle
            var n2_4 = n2.Next;
            n2_6.Next = n2;
            var resCase4 = OverlappingLists(n1, n2);
            results.Add(resCase4 != null ? $"case 4 passed; they merge at {resCase4.Data} expected to merge at: 3 or 4" : $"case 4 failed; returned null");
            
            foreach(var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
