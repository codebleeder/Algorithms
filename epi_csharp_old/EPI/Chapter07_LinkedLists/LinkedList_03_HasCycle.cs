using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter7_LinkedLists
{
    public static class LinkedList_03_HasCycle
    {
        public static ListNode<int> HasCycle(ListNode<int> headNode)
        {
            var iFast = headNode;
            var iSlow = headNode;
            while (iFast != null && iFast.Next != null)
            {
                iSlow = iSlow.Next;
                iFast = iFast.Next.Next;
                if (iSlow == iFast)
                {
                    // it is cyclic
                    // find length of cycle
                    var lengthOfCycle = 0;
                    do
                    {
                        iSlow = iSlow.Next;
                        lengthOfCycle++;
                    }
                    while (iSlow != iFast);

                    // move iSlow and iFast to head
                    iSlow = headNode;
                    iFast = headNode;

                    // move iFast lengthOfCycle ahead
                    while (lengthOfCycle > 0)
                    {
                        iFast = iFast.Next;
                        lengthOfCycle--;
                    }

                    // move iFast and iSlow until they meet 
                    while (iFast != iSlow)
                    {
                        iFast = iFast.Next;
                        iSlow = iSlow.Next;
                    }
                    return iFast; // or iSlow
                }
            }
            return null;
        }
        public static void Test()
        {
            var a1 = new int[] { 1, 2, 3, 4, 5, 6, 7 };            
            var head1 = ListNode<int>.BuildLinkedList(a1);
            var current = head1;
            var cycleStart = new ListNode<int>(0);
            while (current.Next != null)
            {
                current = current.Next;
                if (current.Data == 4)
                {
                    cycleStart = current;
                }
            }
            current.Next = cycleStart;

            var result = HasCycle(head1);
            if (result == null)
            {
                Console.WriteLine("test failed; result is null");
            }
            else
            {
                Console.WriteLine($"cycle found; it starts at {result.Data}");
            }
        }
    }
}
