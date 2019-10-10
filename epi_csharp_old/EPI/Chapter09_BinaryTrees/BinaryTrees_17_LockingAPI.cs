using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public static class BinaryTrees_17_LockingAPI
    {
        public static void Test()
        {
            var h = new BinaryTreeNodeWithLock<int>(17);
            var m = new BinaryTreeNodeWithLock<int>(641);
            var n = new BinaryTreeNodeWithLock<int>(257);
            var l = new BinaryTreeNodeWithLock<int>(401, null, m);
            var k = new BinaryTreeNodeWithLock<int>(1, l, n);
            var g = new BinaryTreeNodeWithLock<int>(3, h, null);
            var p = new BinaryTreeNodeWithLock<int>(28);
            var d = new BinaryTreeNodeWithLock<int>(28);
            var e = new BinaryTreeNodeWithLock<int>(0);
            var o = new BinaryTreeNodeWithLock<int>(271, null, p);
            var j = new BinaryTreeNodeWithLock<int>(2, null, k);
            var f = new BinaryTreeNodeWithLock<int>(561, null, g);
            var c = new BinaryTreeNodeWithLock<int>(272, d, e);
            var b = new BinaryTreeNodeWithLock<int>(6, c, f);
            var i = new BinaryTreeNodeWithLock<int>(6, j, o);
            var a = new BinaryTreeNodeWithLock<int>(314, b, i);
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

            var results = new List<bool>();
            var expected = new List<bool> { true, false, true, false, false};
            results.Add(a.Lock()); // should return true
            results.Add(f.Lock()); // false
            a.Unlock(); //
            results.Add(f.Lock()); // true
            results.Add(h.Lock()); // false
            results.Add(b.Lock()); // false 
            for (var index = 0; index < results.Count; index++)
            {
                var res = results[index] == expected[index] ? $"case {index+1} pass" : $"case {index + 1} fail";
                Console.WriteLine(res);
            }
        }
    }
    public class BinaryTreeNodeWithLock<T>
    {
        public T Data { get; set; }
        public BinaryTreeNodeWithLock<T> Left { get; set; }
        public BinaryTreeNodeWithLock<T> Right { get; set; }
        public BinaryTreeNodeWithLock<T> Parent { get; set; }
        public int NoOfDecendantsLocked { get; set; }
        public bool IsLocked { get; set; }
        public BinaryTreeNodeWithLock()
        {
            IsLocked = false;
        }
        public BinaryTreeNodeWithLock(T data)
        {
            Data = data;
        }
        public BinaryTreeNodeWithLock(T data, BinaryTreeNodeWithLock<T> left, BinaryTreeNodeWithLock<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }
        public BinaryTreeNodeWithLock(T data, BinaryTreeNodeWithLock<T> left, 
            BinaryTreeNodeWithLock<T> right, BinaryTreeNodeWithLock<T> parent)
        {
            Data = data;
            Left = left;
            Right = right;
            Parent = parent;
        }
        public bool Lock()
        {
            if (NoOfDecendantsLocked > 0)
            {
                return false;
            }
            var iter = this;
            while (iter.Parent != null)
            {
                if (iter.Parent.IsLocked)
                {
                    return false;
                }
                iter = iter.Parent;
            }
            IsLocked = true;
            for (var i = this.Parent; i != null; i = i.Parent)
            {
                ++i.NoOfDecendantsLocked;
            }
            return true; 
        }
        public void Unlock()
        {
            IsLocked = false;
            for (var i = this.Parent; i != null; i = i.Parent)
            {
                --i.NoOfDecendantsLocked;
            }
        }
    }
}
