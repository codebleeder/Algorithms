using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public static class BinaryTrees_04_LCA
    {
        public static BinaryTreeNodeWithParent<int> LCA(BinaryTreeNodeWithParent<int> root,
            BinaryTreeNodeWithParent<int> node1, BinaryTreeNodeWithParent<int> node2)
        {
            // determine depth of node1 and node2 from root
            var depthNode1 = GetDepth(root, node1);
            var depthNode2 = GetDepth(root, node2);

            // set pointers and move them to same depth 
            var depthDiff = Math.Abs(depthNode1 - depthNode2);
            if (depthNode1 > depthNode2)
            {
                while (depthDiff > 0)
                {
                    node1 = node1.Parent;
                    depthDiff--;
                }
            }
            else
            {
                while (depthDiff > 0)
                {
                    node2 = node2.Parent;
                    depthDiff--;
                }
            }

            // move pointers towards root until they find common ancestor
            while (node1 != node2)
            {
                node1 = node1.Parent;
                node2 = node2.Parent;
            }
            
            return node1;
        }
        public static int GetDepth(BinaryTreeNodeWithParent<int> root,
            BinaryTreeNodeWithParent<int> node)
        {
            var distance = 0;           
            while (node != root)
            {
                node = node.Parent;
                distance += 1;
            }
            return distance;
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

            // test
            var tests = new List<Tuple<BinaryTreeNodeWithParent<int>, BinaryTreeNodeWithParent<int>, int>>
            {
                new Tuple<BinaryTreeNodeWithParent<int>, BinaryTreeNodeWithParent<int>, int> (f, j, 314),
                new Tuple<BinaryTreeNodeWithParent<int>, BinaryTreeNodeWithParent<int>, int> (j, o, 6),
                new Tuple<BinaryTreeNodeWithParent<int>, BinaryTreeNodeWithParent<int>, int> (d, g, 6),
            };
            var iCase = 1;
            foreach (var test in tests)
            {
                var result = LCA(a, test.Item1, test.Item2);
                Console.WriteLine($"{iCase} test result: {result.Data == test.Item3}");
                iCase++;
            }
            
        }
    }
    
}
