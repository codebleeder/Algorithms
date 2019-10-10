using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public static class BinaryTrees_15_ExteriorBinaryTree
    {
        public static List<BinaryTreeNode<int>> ExteriorBinaryTree(BinaryTreeNode<int> tree)
        {
            var res = new List<BinaryTreeNode<int>>();
            
            if (tree != null)
            {
                res.Add(tree);
                res.AddRange(LeftBoundaryAndLeaves(tree.Left, true));
                res.AddRange(RightBoundaryAndLeaves(tree.Right, true));
            }
            return res;
        }

        private static List<BinaryTreeNode<int>> RightBoundaryAndLeaves(BinaryTreeNode<int> subtreeRoot, bool isBoundary)
        {
            var res = new List<BinaryTreeNode<int>>();
            if (subtreeRoot != null)
            {
                if (isBoundary || IsLeaf(subtreeRoot))
                {
                    res.Add(subtreeRoot);
                }
                res.AddRange(RightBoundaryAndLeaves(subtreeRoot.Right, isBoundary));
                res.AddRange(RightBoundaryAndLeaves(subtreeRoot.Left, isBoundary && subtreeRoot.Right == null));
            }
            
            return res;
        }

        private static List<BinaryTreeNode<int>> LeftBoundaryAndLeaves(BinaryTreeNode<int> subtreeRoot, bool isBoundary)
        {
            var res = new List<BinaryTreeNode<int>>();
            if (subtreeRoot != null)
            {
                if (isBoundary || IsLeaf(subtreeRoot))
                {
                    res.Add(subtreeRoot);
                }
                res.AddRange(RightBoundaryAndLeaves(subtreeRoot.Left, isBoundary));
                res.AddRange(RightBoundaryAndLeaves(subtreeRoot.Right, isBoundary && subtreeRoot.Left == null));
            }            
            return res;
        }
        private static bool IsLeaf(BinaryTreeNode<int> root)
        {
            return root.Left == null && root.Right == null;
        }
        public static void Test()
        {
            var root = BinaryTrees_00_TreeTraversal.BuildExampleTree();
            var res = ExteriorBinaryTree(root);
        }
    }
}
