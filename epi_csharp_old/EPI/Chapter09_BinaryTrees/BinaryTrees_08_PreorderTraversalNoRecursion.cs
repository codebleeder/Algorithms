using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public static class BinaryTrees_08_PreorderTraversalNoRecursion
    {
        public static List<int> PreorderTraversalNoRecursion(BinaryTreeNode<int> root)
        {
            var stack = new Stack<BinaryTreeNode<int>>();
            var res = new List<int>();
            if (root != null)
            {
                stack.Push(root);
            }
            while (stack.Count > 0)
            {
                var curr = stack.Pop();
                res.Add(curr.Data);
                if (curr.Right != null)
                {
                    stack.Push(curr.Right);
                }
                if (curr.Left != null)
                {
                    stack.Push(curr.Left);
                }
            }
            return res;
        }
        public static void Test()
        {
            var root = BinaryTrees_00_TreeTraversal.BuildExampleTree();
            var result = PreorderTraversalNoRecursion(root);
            Console.WriteLine("BST pre-order traversal");
            Utilities.PrintList(result);
        }
    }
}
