using EPI.Chapter7_LinkedLists;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public static class BinaryTrees_14_CreateListOfLeaves
    {
        public static ListNode<int> DummyHead { get; set; }
        public static ListNode<int> Tail { get; set; }
        public static ListNode<int> CreateListOfLeaves(BinaryTreeNode<int> root)
        {
            DummyHead = new ListNode<int>(-1);
            Tail = DummyHead;
            CreateListOfLeavesHelper(root);
            return DummyHead.Next;
        }

        private static void CreateListOfLeavesHelper(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                return;
            }
            if (root.Left == null && root.Right == null)
            {
                Tail.Next = new ListNode<int>(root.Data);
                Tail = Tail.Next;
               // return;
            }
            if (root.Left != null)
            {
                CreateListOfLeavesHelper(root.Left);
            }
            if (root.Right != null)
            {
                CreateListOfLeavesHelper(root.Right);
            }
        }
        public static void Test()
        {
            var root = BinaryTrees_00_TreeTraversal.BuildExampleTree();
            var res = CreateListOfLeaves(root);
            ListNode<int>.Print(res);
        }
    }
}
