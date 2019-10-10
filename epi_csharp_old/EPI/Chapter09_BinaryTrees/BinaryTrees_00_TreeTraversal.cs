using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public static class BinaryTrees_00_TreeTraversal
    {
        public enum Order {PRE_ORDER, IN_ORDER, POST_ORDER};
        public static void TreeTraversal(BinaryTreeNode<int> root, Order order)
        {
            // preorder: 
            if (root != null)
            {
                if (order == Order.PRE_ORDER)
                {
                    Console.WriteLine($"pre-order: {root.Data}");
                }                
                TreeTraversal(root.Left, order);

                if (order == Order.IN_ORDER)
                {
                    Console.WriteLine($"in-order: {root.Data}");
                }
                TreeTraversal(root.Right, order);

                if (order == Order.POST_ORDER)
                {
                    Console.WriteLine($"post-order: {root.Data}");
                }
            }
            
        }
        public static void TreeTraversalList(BinaryTreeNode<int> root, Order order, List<BinaryTreeNode<int>> orderedList)
        {
            var res = new List<BinaryTreeNode<int>>();
            // preorder: 
            if (root != null)
            {
                if (order == Order.PRE_ORDER)
                {
                    orderedList.Add(root);
                }
                TreeTraversalList(root.Left, order, orderedList);

                if (order == Order.IN_ORDER)
                {
                    orderedList.Add(root);
                }
                TreeTraversalList(root.Right, order, orderedList);

                if (order == Order.POST_ORDER)
                {
                    orderedList.Add(root);
                }
            }         
        }
        public static BinaryTreeNode<int> BuildExampleTree()
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
            return a;
        }
        public static BinaryTreeNode<int> BuildHeightBalancedExample()
        {
            var e = new BinaryTreeNode<int>(1);
            var f = new BinaryTreeNode<int>(2);
            var d = new BinaryTreeNode<int>(3, e, f);

            var g = new BinaryTreeNode<int>(4);
            var c = new BinaryTreeNode<int>(5, d, g);

            var i = new BinaryTreeNode<int>(6);
            var j = new BinaryTreeNode<int>(7);
            var h = new BinaryTreeNode<int>(8, i, j);

            var b = new BinaryTreeNode<int>(9, c, h);

            var m = new BinaryTreeNode<int>(10);
            var n = new BinaryTreeNode<int>(11);
            var l = new BinaryTreeNode<int>(12, m, n);

            var o = new BinaryTreeNode<int>(13);
            var k = new BinaryTreeNode<int>(14, l, o);
            
            var a = new BinaryTreeNode<int>(15, b, k);
            return a;
        }
        public static void Test()
        {
            var root = BuildExampleTree();
            foreach (var order in (Order[])Enum.GetValues(typeof(Order)))
            {
                TreeTraversal(root, order);
                Console.WriteLine("");
            }
            
        }
        public static void TestTreeTraversalList()
        {
            var root = BuildExampleTree();
            var resList = new List<BinaryTreeNode<int>>();
            TreeTraversalList(root, Order.IN_ORDER, resList);
        }
    }
}
