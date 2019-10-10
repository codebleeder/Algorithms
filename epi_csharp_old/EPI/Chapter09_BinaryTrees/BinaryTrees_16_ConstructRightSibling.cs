using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public static class BinaryTrees_16_ConstructRightSibling
    {
        public static void ConstructRightSibling(BinaryTreeNodeWithNext<int> root)
        {
            var iter = root;
            iter.Left.Next = iter.Right;
            iter = iter.Left;
            while (iter.Left != null)
            {
                var leftMost = iter;
                while (iter != null)
                {
                    iter.Left.Next = iter.Right;
                    if (iter.Next != null)
                    {
                        iter.Right.Next = iter.Next.Left;
                    }
                    else
                    {
                        break;
                    }
                    iter = iter.Next;
                }
                iter = leftMost.Left;
            }
        }
        
        public static void Test()
        {
            var d = new BinaryTreeNodeWithNext<int>(4);
            var e = new BinaryTreeNodeWithNext<int>(5);
            var g = new BinaryTreeNodeWithNext<int>(7);
            var h = new BinaryTreeNodeWithNext<int>(8);
            var k = new BinaryTreeNodeWithNext<int>(11);
            var l = new BinaryTreeNodeWithNext<int>(12);
            var n = new BinaryTreeNodeWithNext<int>(14);
            var o = new BinaryTreeNodeWithNext<int>(15);

            var c = new BinaryTreeNodeWithNext<int>(3, d, e);
            var f = new BinaryTreeNodeWithNext<int>(6, g, h);
            var j = new BinaryTreeNodeWithNext<int>(10, k, l);
            var m = new BinaryTreeNodeWithNext<int>(13, n, o);

            var b = new BinaryTreeNodeWithNext<int>(2, c, f);
            var i = new BinaryTreeNodeWithNext<int>(9, j, m);

            var a = new BinaryTreeNodeWithNext<int>(1, b, i);
            ConstructRightSibling(a);
        }
    }
}
