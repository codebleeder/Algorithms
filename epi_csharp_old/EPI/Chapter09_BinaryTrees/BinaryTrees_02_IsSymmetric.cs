using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public static class BinaryTrees_02_IsSymmetric
    {
        public static bool IsSymmetric(BinaryTreeNode<int> root)
        {
            // base
            if (root == null)
            {
                return true;
            }           
            if (root.Left == null && root.Right == null)
            {
                return true;
            }
            if (root.Left != null && root.Right == null)
            {
                return false;
            }
            if (root.Left == null && root.Right != null)
            {
                return false;
            }

            return IsSymmetric(root.Left) && IsSymmetric(root.Right) && (root.Left.Data == root.Right.Data);
        }
        public static bool IsSymmetric2(BinaryTreeNode<int> root)
        {
            return CheckSymmetry(root.Left, root.Right);
        }
        public static bool CheckSymmetry(BinaryTreeNode<int> a, BinaryTreeNode<int> b)
        {
            if (a == null && b == null)
            {
                return true;
            }
            if ((a == null && b != null) || (a != null && b == null))
            {
                return false;
            }
            if (a.Data != b.Data)
            {
                return false;
            }
            var check1 = CheckSymmetry(a.Left, b.Right);
            var check2 = CheckSymmetry(a.Right, b.Left);
            return check1 && check2;
        }
        public static void Test()
        {
            var tests = new List<Tuple<BinaryTreeNode<int>, bool>>
            {
                BuildTreeCase1(),
                BuildTreeCase2(),
                BuildTreeCase3(),
            };
            var i = 1;
            foreach(var test in tests)
            {
                var res = IsSymmetric2(test.Item1);
                Console.WriteLine($"case {i} expected: {test.Item2}  result: {res}");
                i++;
            }
        }
        public static Tuple<BinaryTreeNode<int>, bool> BuildTreeCase1()
        {
            var d = new BinaryTreeNode<int>(3);
            var g = new BinaryTreeNode<int>(3);
            var c = new BinaryTreeNode<int>(2, null, d);
            var f = new BinaryTreeNode<int>(2, g, null);
            var b = new BinaryTreeNode<int>(6, null, c);
            var e = new BinaryTreeNode<int>(6, f, null);
            var a = new BinaryTreeNode<int>(314, b, e);
            return new Tuple<BinaryTreeNode<int>, bool>(a, true);
        }
        public static Tuple<BinaryTreeNode<int>, bool> BuildTreeCase2()
        {
            var d = new BinaryTreeNode<int>(3);
            var g = new BinaryTreeNode<int>(1);
            var c = new BinaryTreeNode<int>(561, null, d);
            var f = new BinaryTreeNode<int>(2, g, null);
            var b = new BinaryTreeNode<int>(6, null, c);
            var e = new BinaryTreeNode<int>(6, f, null);
            var a = new BinaryTreeNode<int>(314, b, e);
            return new Tuple<BinaryTreeNode<int>, bool>(a, false);
        }
        public static Tuple<BinaryTreeNode<int>, bool> BuildTreeCase3()
        {
            var d = new BinaryTreeNode<int>(3);           
            var c = new BinaryTreeNode<int>(561, null, d);
            var f = new BinaryTreeNode<int>(2);
            var b = new BinaryTreeNode<int>(6, null, c);
            var e = new BinaryTreeNode<int>(6, f, null);
            var a = new BinaryTreeNode<int>(314, b, e);
            return new Tuple<BinaryTreeNode<int>, bool>(a, false);
        }
    }
}
