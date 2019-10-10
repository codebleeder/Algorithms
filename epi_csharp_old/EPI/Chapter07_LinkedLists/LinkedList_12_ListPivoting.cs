using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter7_LinkedLists
{
    public static class LinkedList_12_ListPivoting
    {
        public static ListNode<int> ListPivoting(ListNode<int> head, int pivot)
        {
            var greaterHead = new ListNode<int>(-1);
            var equalHead = new ListNode<int>(-1);
            var lesserHead = new ListNode<int>(-1);
            var greaterTail = greaterHead;
            var equalTail = equalHead;
            var lesserTail = lesserHead;

            var iter = head;
            while (iter != null)
            {
                if (iter.Data > pivot)
                {
                    greaterTail.Next = iter;
                    greaterTail = greaterTail.Next;
                }
                else if (iter.Data < pivot)
                {
                    lesserTail.Next = iter;
                    lesserTail = lesserTail.Next;
                }
                else
                {
                    equalTail.Next = iter;
                    equalTail = equalTail.Next;
                }
                iter = iter.Next;
            }
            // arrange
            lesserTail.Next = equalHead.Next;
            equalTail.Next = greaterHead.Next;
            greaterTail.Next = null;
            return lesserHead.Next;
        }
        public static void Test()
        {
            var tests = new List<Tuple<int[], int>>
            {
                new Tuple<int[], int> (new int[] {3, 2, 2, 11, 7, 5, 11}, 7),
                new Tuple<int[], int> (new int[] {11, 7, 11 }, 7),
                new Tuple<int[], int> (new int[] {3, 2, 2, 7, 5 }, 7),
                new Tuple<int[], int> (new int[] {7, 7, 7 }, 7),
            };
            var i = 1;
            foreach (var test in tests)
            {
                Console.WriteLine($"test {i}; original");
                var l = ListNode<int>.BuildLinkedList(test.Item1);
                ListNode<int>.Print(l);
                var res = ListPivoting(l, test.Item2);
                Console.WriteLine("result: ");
                ListNode<int>.Print(res);
                i++;
            }
        }
    }
}
