using System;
using System.Collections.Generic;
using System.Text;
using EPI.Chapter09_BinaryTrees;

namespace EPI.Chapter12_HashTables
{
    public static class HashTables_04_LCA
    {
        public static BinaryTreeNodeWithParent<int> LCA(BinaryTreeNodeWithParent<int> node0, BinaryTreeNodeWithParent<int> node1)
        {
            var hash = new HashSet<BinaryTreeNodeWithParent<int>>();
            while (node0 != null && node1 != null)
            {
                if(node0.Parent != null)
                {
                    if(hash.Contains(node0.Parent))
                    {
                        return node0.Parent;
                    }
                    hash.Add(node0.Parent);
                    node0 = node0.Parent;
                }
                else
                {
                    return node0;
                }
                if (node1.Parent != null)
                {
                    if (hash.Contains(node1.Parent))
                    {
                        return node1.Parent;
                    }
                    hash.Add(node1.Parent);
                    node1 = node1.Parent;
                }
                else
                {
                    return node1;
                }
            }
            return node0.Parent == null ? node0 : node1; 
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

            var tests = new List<
                Tuple<
                BinaryTreeNodeWithParent<int>,
                BinaryTreeNodeWithParent<int>,
                BinaryTreeNodeWithParent<int>
                    >>
                    {
                new Tuple<BinaryTreeNodeWithParent<int>, BinaryTreeNodeWithParent<int>, BinaryTreeNodeWithParent<int>>(m, p, i),
                new Tuple<BinaryTreeNodeWithParent<int>, BinaryTreeNodeWithParent<int>, BinaryTreeNodeWithParent<int>>(m, h, a),
            };
                for (var iTest = 0; iTest < tests.Count; iTest++)
            {
                var res = LCA(tests[iTest].Item1, tests[iTest].Item2);
                var resTest = res == tests[iTest].Item3 ? "pass" : "fail";
                Console.WriteLine($"test {iTest + 1}  res: {resTest}");
            }
        }
    }
}
