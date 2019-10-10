using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public static class BinaryTrees_05_SumRootToLeaf
    {
        public static int SumRootToLeaf(BinaryTreeNode<int> root)
        {
            var sum = 0;
            var values = new List<int>();
            SumRootToLeafHelper(root, 0, values);
            foreach(var v in values)
            {
                sum += v;
                Console.WriteLine(v);
            }
            return sum;
        }

        private static void SumRootToLeafHelper(BinaryTreeNode<int> root, int val, List<int> values)
        {
            // base 
            val = (val << 1) + root.Data;
            if (root.Left == null && root.Right == null)
            {
                values.Add(val);
            }
            
            if (root.Left != null)
            {
                SumRootToLeafHelper(root.Left, val, values);
            }
            if (root.Right != null)
            {
                SumRootToLeafHelper(root.Right, val, values);
            }
        }
        public static int SumRootToLeaf2(BinaryTreeNode<int> root)
        {
            return SumRootToLeafHelper2(root, 0);
        }

        private static int SumRootToLeafHelper2(BinaryTreeNode<int> root, int partialPathSum)
        {
           if (root == null)
            {
                return 0;
            }
            partialPathSum = (partialPathSum * 2) + root.Data;
            if (root.Left == null && root.Right == null)
            {
                return partialPathSum;
            }
            return SumRootToLeafHelper2(root.Left, partialPathSum) + SumRootToLeafHelper2(root.Right, partialPathSum);
        }

        public static void Test()
        {
            var h = new BinaryTreeNode<int>(0);
            var g = new BinaryTreeNode<int>(1);
            g.Left = h;
            var f = new BinaryTreeNode<int>(1);
            f.Right = g;
            
            var d = new BinaryTreeNode<int>(0);
            var e = new BinaryTreeNode<int>(1);
            var c = new BinaryTreeNode<int>(0, d, e);
            var b = new BinaryTreeNode<int>(0, c, f);
            var m = new BinaryTreeNode<int>(1);
            var l = new BinaryTreeNode<int>(1, null, m);
            var n = new BinaryTreeNode<int>(0);
            var k = new BinaryTreeNode<int>(0, l, n);
            var j = new BinaryTreeNode<int>(0, null, k);
            var p = new BinaryTreeNode<int>(0);
            var o = new BinaryTreeNode<int>(0, null, p);
            var i = new BinaryTreeNode<int>(1, j, o);
            var a = new BinaryTreeNode<int>(1, b, i);

            var res = SumRootToLeaf(a);
        }
    }
}
