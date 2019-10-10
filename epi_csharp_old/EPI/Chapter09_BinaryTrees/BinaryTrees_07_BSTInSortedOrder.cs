using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public static class BinaryTrees_07_BSTInSortedOrder
    {
        // in-order tree traversal 
        public static List<int> BSTInSortedOrder(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                return null;
            }
            var stack = new Stack<BinaryTreeNode<int>>();
            var result = new List<int>();
            var node = root;
            // load the stack
            
            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop(); // go to parent
                    result.Add(node.Data);
                    // go right
                    node = node.Right;
                }
            }
            return result;
        }
        public static void Test()
        {
            var root = BinaryTrees_00_TreeTraversal.BuildExampleTree();
            var result = BSTInSortedOrder(root);
            Console.WriteLine("BST in-order traversal");
            Utilities.PrintList(result);
        }
    }
}
