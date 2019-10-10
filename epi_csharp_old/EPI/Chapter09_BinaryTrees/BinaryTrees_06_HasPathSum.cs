using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public static class BinaryTrees_06_HasPathSum
    {
        public static BinaryTreeNode<int> HasPathSum(int sum, BinaryTreeNode<int> root)
        {
            return HasPathSumHelper(sum, root, 0);
        }

        private static BinaryTreeNode<int> HasPathSumHelper(int sum, BinaryTreeNode<int> root, int partialSum)
        {
            if (root == null)
            {
                return null;
            }
            partialSum += root.Data;
            if (partialSum == sum)
            {
                return root; 
            }
            if (partialSum > sum)
            {
                return null;
            }
            var leftRes = HasPathSumHelper(sum, root.Left, partialSum);
            var rightRes = HasPathSumHelper(sum, root.Right, partialSum);
            return leftRes == null ? rightRes : leftRes;
        }
        // book solution: 
        public static bool HasPathSum2(BinaryTreeNode<int> root, int remainingWeight)
        {
            if (root == null)
            {
                return false;
            }
            else if (root.Left == null && root.Right == null)
            {
                return remainingWeight == root.Data; // leaf
            }
            return HasPathSum2(root.Left, remainingWeight - root.Data) || 
                HasPathSum2(root.Right, remainingWeight - root.Data);
        }
        public static void Test()
        {
            var h = new BinaryTreeNode<int>(17);
            var m = new BinaryTreeNode<int>(641);
            var n = new BinaryTreeNode<int>(257);
            var l = new BinaryTreeNode<int>(401, null, m);
            var k = new BinaryTreeNode<int>(1, l, n);
            var g = new BinaryTreeNode<int>(3, h, null);
            var p = new BinaryTreeNode<int>(28);
            var d = new BinaryTreeNode<int>(28);
            var e = new BinaryTreeNode<int>(0);
            var o = new BinaryTreeNode<int>(271, null, p);
            var j = new BinaryTreeNode<int>(2, null, k);
            var f = new BinaryTreeNode<int>(561, null, g);
            var c = new BinaryTreeNode<int>(272, d, e);
            var b = new BinaryTreeNode<int>(6, c, f);
            var i = new BinaryTreeNode<int>(6, j, o);
            var a = new BinaryTreeNode<int>(314, b, i);

            var res = HasPathSum2(a, 1365);
        }
    }
}
