using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public static class BinaryTrees_10_FindSuccessor
    {
        public static BinaryTreeNodeWithParent<int> FindSuccessor(BinaryTreeNodeWithParent<int> node)
        {
            if (node.Right != null)
            {
                return node.Right;
            }
            while(IsRightChild(node))
            {
                node = node.Parent;
            }
            return node.Parent;
        }
        public static bool IsRightChild(BinaryTreeNodeWithParent<int> node)
        {
            return node.Parent != null && node.Parent.Right == node;
        }
        public static void Test()
        {
            var h = new BinaryTreeNodeWithParent<int>(17);
            var m = new BinaryTreeNodeWithParent<int>(641);
            var n = new BinaryTreeNodeWithParent<int>(257);
            var l = new BinaryTreeNodeWithParent<int>(401, null, m);
            var k = new BinaryTreeNodeWithParent<int>(1, l, n);
            var g = new BinaryTreeNodeWithParent<int>(3, h, null);
            var p = new BinaryTreeNodeWithParent<int>(28);
            var d = new BinaryTreeNodeWithParent<int>(28);
            var e = new BinaryTreeNodeWithParent<int>(0);
            var o = new BinaryTreeNodeWithParent<int>(271, null, p);
            var j = new BinaryTreeNodeWithParent<int>(2, null, k);
            var f = new BinaryTreeNodeWithParent<int>(561, null, g);
            var c = new BinaryTreeNodeWithParent<int>(272, d, e);
            var b = new BinaryTreeNodeWithParent<int>(6, c, f);
            var i = new BinaryTreeNodeWithParent<int>(6, j, o);
            var a = new BinaryTreeNodeWithParent<int>(314, b, i);
            a.Parent = null;
            b.Parent = a;
            c.Parent = b;
            f.Parent = b;
            d.Parent = c;
            e.Parent = c;
            g.Parent = f;
            h.Parent = g;
            i.Parent = a;
            j.Parent = i;
            k.Parent = j;
            l.Parent = k;
            n.Parent = k;
            m.Parent = l;
            o.Parent = i;
            p.Parent = o;

            var res = FindSuccessor(p);
        }
    }
}
