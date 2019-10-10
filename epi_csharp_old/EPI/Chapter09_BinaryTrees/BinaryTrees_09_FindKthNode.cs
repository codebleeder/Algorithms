using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public static class BinaryTrees_09_FindKthNode
    {
        // find k-th node by in-order traversal 
        public static BinaryTreeNodeWithSize<int> FindKthNode(BinaryTreeNodeWithSize<int> root, int k)
        {
            
            var curr = root;
            while (curr != null)
            {
                var sizeLeft = curr.Left != null ? curr.Left.Size : 0;
                if (sizeLeft + 1 < k)
                {
                    k -= (sizeLeft + 1);
                    curr = curr.Right;
                }
                else if (sizeLeft == k - 1)
                {
                    return curr;
                }
                else
                {
                    curr = curr.Left;
                }
            }
            return null;
        }
        public static void Test()
        {
            var root = BinaryTrees_00_TreeTraversal.BuildExampleTree();
            var rootWithSize = BuildExampleTreeWithSize();
            var sortedList = new List<BinaryTreeNode<int>>();
            BinaryTrees_00_TreeTraversal.TreeTraversalList(root, BinaryTrees_00_TreeTraversal.Order.IN_ORDER, sortedList);
            var tests = new int[] { 1, 17, 4, 10 };
            for (var i = 1; i <= tests.Length; i++)
            {
                var k = tests[i - 1];
                var res = FindKthNode(rootWithSize, k);
                var resDisplay = res == null ? "null" : res.Data.ToString();
                var expectedDisplay = k >= sortedList.Count ? "null" : sortedList[k-1].Data.ToString();
                Console.WriteLine($"test {i} k: {k} result: {resDisplay}  expected: {expectedDisplay}");
            }
        }
        public static BinaryTreeNodeWithSize<int> BuildExampleTreeWithSize()
        {
            var h = new BinaryTreeNodeWithSize<int>(17, 1);
            var m = new BinaryTreeNodeWithSize<int>(641, 1);
            var n = new BinaryTreeNodeWithSize<int>(257, 1);
            var l = new BinaryTreeNodeWithSize<int>(401, null, m, 2);
            var k = new BinaryTreeNodeWithSize<int>(1, l, n, 4);
            var g = new BinaryTreeNodeWithSize<int>(3, h, null, 2);
            var p = new BinaryTreeNodeWithSize<int>(28, 1);
            var d = new BinaryTreeNodeWithSize<int>(28, 1);
            var e = new BinaryTreeNodeWithSize<int>(0, 1);
            var o = new BinaryTreeNodeWithSize<int>(271, null, p, 2);
            var j = new BinaryTreeNodeWithSize<int>(2, null, k, 5);
            var f = new BinaryTreeNodeWithSize<int>(561, null, g, 3);
            var c = new BinaryTreeNodeWithSize<int>(272, d, e, 3);
            var b = new BinaryTreeNodeWithSize<int>(6, c, f, 7);
            var i = new BinaryTreeNodeWithSize<int>(6, j, o, 8);
            var a = new BinaryTreeNodeWithSize<int>(314, b, i, 16);
            return a;
        }
    }
}
