using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter7_LinkedLists
{
    public static class LinkedList_13_AddTwoNumbers
    {
        public static ListNode<int> AddTwoNumbers(ListNode<int> l1, ListNode<int> l2)
        {
            var dummyHead = new ListNode<int>(-1);
            var carry = 0;
            var iter = dummyHead;
            while (l1 != null || l2 != null)
            {
                var sum = (l1 == null ? 0 : l1.Data) + (l2 == null ? 0 : l2.Data) + carry;
                carry = sum >= 10 ? 1 : 0;
                sum = carry > 0 ? sum - 10 : sum;
                var newNode = new ListNode<int>(sum);
                iter.Next = newNode;
                iter = iter.Next;
                if (l1 != null)
                {
                    l1 = l1.Next;
                }
                if (l2 != null)
                {
                    l2 = l2.Next;
                }                
            }
            if (carry > 0)
            {
                iter.Next = new ListNode<int>(1);
                iter.Next.Next = null;
            }
            return dummyHead.Next;
        }
        public static void Test()
        {
            var tests = new List<Tuple<int[], int[], int>>
            {
                new Tuple<int[], int[], int>(new int[]{ 3, 1, 4 }, new int[]{ 7, 0, 9}, 1320),
                new Tuple<int[], int[], int>(new int[]{ 3, 1, 4, 9 }, new int[]{ 7, 0, 9}, 10320),
                new Tuple<int[], int[], int>(new int[]{ 3, 1, 4 }, new int[]{ 7, 0, 9, 8}, 9320),
            };
            var i = 1;
            foreach(var test in tests)
            {
                var l1 = ListNode<int>.BuildLinkedList(test.Item1);
                var l2 = ListNode<int>.BuildLinkedList(test.Item2);
                var resHead = AddTwoNumbers(l1, l2);
                var sb = new StringBuilder();
                var sum = 0;
                var res = resHead;
                while (res != null)
                {
                    sb.Insert(0, res.Data);
                    res = res.Next;
                }
                sum = int.Parse(sb.ToString());
                var testRes = sum == test.Item3 ? "pass" : "fail";
                Console.WriteLine($"case {i} result: {sum} expected: {test.Item3}  {testRes}");
                ListNode<int>.Print(resHead);
                i++;
            }
        }
    }
}
