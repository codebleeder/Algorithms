using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter7_LinkedLists
{
    public static class LinkedList_06_DeletionFromList
    {
        
        public static void DeletionFromList(ListNode<int> nodeToDelete)
        {
            nodeToDelete.Data = nodeToDelete.Next.Data;
            nodeToDelete.Next = nodeToDelete.Next.Next;
        }
        public static void Test()
        {
            var head = ListNode<int>.BuildLinkedList(new int[] { 1, 2, 3, 4, 5, 6 });
            // delete 5
            var nodeToDelete = ListNode<int>.MoveByK(head, 4);
            DeletionFromList(nodeToDelete);
            ListNode<int>.Print(head);
        }
    }
}
