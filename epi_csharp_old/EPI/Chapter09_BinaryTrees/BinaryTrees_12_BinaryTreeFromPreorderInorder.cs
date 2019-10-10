using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public static class BinaryTrees_12_BinaryTreeFromPreorderInorder
    {
        public static BinaryTreeNode<int> BinaryTreeFromPreorderInorder(List<int> preorder, List<int> inorder)
        {
            var root = FindRoot(preorder, inorder);
            TreeBuilder(root, preorder, inorder);
            return root;
        }
        public static BinaryTreeNode<int> FindRoot(List<int> preorder, List<int> inorderSubList)
        {
            if (inorderSubList.Count == preorder.Count)
            {
                return new BinaryTreeNode<int>(preorder[0]);
            }
            var smallestIndex = int.MaxValue;
            for (var i = 0; i < inorderSubList.Count; i++)
            {
                var index = preorder.FindIndex(x => x == inorderSubList[i]);
                if (index < smallestIndex)
                {
                    smallestIndex = index;
                }
            }
            if (smallestIndex >= preorder.Count)
            {
                return null;
            }
            return new BinaryTreeNode<int>(preorder[smallestIndex]);
        }
        public static Tuple<List<int>, List<int>> Split(int root, List<int> inorderSublist)
        {
            var leftSublist = new List<int>();
            var rightSublist = new List<int>();
            var index = inorderSublist.FindIndex(x => x == root);
            leftSublist = inorderSublist.GetRange(0, index);
            rightSublist = inorderSublist.GetRange(index + 1, inorderSublist.Count - index - 1);
            return new Tuple<List<int>, List<int>>(leftSublist, rightSublist);
        }
        public static void TreeBuilder(BinaryTreeNode<int> root, List<int> preorder, List<int> inorderSublist)
        {
            if (inorderSublist.Count == 0)
            {
                return; 
            }
            if (inorderSublist.Count == 1 && root.Data == inorderSublist[0])
            {
                return;
            }
            var sublists = Split(root.Data, inorderSublist);
            root.Left = FindRoot(preorder, sublists.Item1);
            root.Right = FindRoot(preorder, sublists.Item2);
            TreeBuilder(root.Left, preorder, sublists.Item1);
            TreeBuilder(root.Right, preorder, sublists.Item2);
        }
        public static void Test()
        {
            var inorder = new List<int> { 4, 2, 5, 1, 3 };
            var preorder = new List<int> { 1, 2, 4, 5, 3 };
            var res = BinaryTreeFromPreorderInorder(preorder, inorder);

            inorder = new List<int> { 6, 2, 1, 5, 8, 3, 4, 9, 7 };
            preorder = new List<int> { 8, 2, 6, 5, 1, 3, 4, 7, 9 };
            res = BinaryTreeFromPreorderInorder(preorder, inorder);
        }
    }
}
