using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public static class BinaryTrees_03_LowestCommonAncestor
    {
        public class Status
        {
            public int NumTargetNodes { get; set; }
            public BinaryTreeNode<int> Ancestor { get; set; }
            public Status(int numTargetNode, BinaryTreeNode<int> ancestor)
            {
                NumTargetNodes = numTargetNode;
                Ancestor = ancestor;
            }
        }
        public static BinaryTreeNode<int> LCA(BinaryTreeNode<int> root, BinaryTreeNode<int> node0, BinaryTreeNode<int> node1)
        {
            return LCAHelper(root, node0, node1).Ancestor;
        }

        private static Status LCAHelper(BinaryTreeNode<int> root, BinaryTreeNode<int> node0, BinaryTreeNode<int> node1)
        {
            if (root == null)
            {
                return new Status(0, null);
            }
            var leftStatus = LCAHelper(root.Left, node0, node1);
            if (leftStatus.NumTargetNodes == 2)
            {
                return leftStatus;
            }
            var rightStatus = LCAHelper(root.Right, node0, node1);
            if (rightStatus.NumTargetNodes == 2)
            {
                return rightStatus;
            }
            var numTargetNodes = leftStatus.NumTargetNodes + rightStatus.NumTargetNodes + 
                (root == node0 ? 1 : 0) + (root == node1 ? 1 : 0);
            var result = new Status(numTargetNodes, numTargetNodes == 2 ? root : null);
            return result;
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

            var result = LCA(a, f, j);
            Console.WriteLine($"result: {result.Data}");
        }
    }
}
