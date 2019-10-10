using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public static class BinaryTrees_01_IsBalanced
    {
        public static bool IsBalanced(BinaryTreeNode<int> root)
        {
            var heightLeft = 0;
            if (root.Left != null)
            {
                heightLeft = 1 + GetHeight(root.Left);
            }
            var heightRight = 0;
            if (root.Right != null)
            {
                heightRight = 1 + GetHeight(root.Right);
            }
            Console.WriteLine($"left height = {heightLeft}  right height = {heightRight}");
            return Math.Abs(heightLeft - heightRight) <= 1;
        }
        public static int GetHeight(BinaryTreeNode<int> root)
        {
            // base case 
            if (root == null)
            {
                return 0;
            }
            if (root.Left == null && root.Right == null)
            {
                return 0;
            }
            var heightLeft = 0;
            if (root.Left != null)
            {
                heightLeft = 1 + GetHeight(root.Left);
            }
            var heightRight = 0;
            if (root.Right != null)
            {
                heightRight = 1 + GetHeight(root.Right);
            }
            return Math.Max(heightRight, heightLeft);
        }
        // book solution: 
        private class BalanceStatusWithHeight
        {
            public int Height { get; set; }
            public bool Balanced { get; set; }
            public BalanceStatusWithHeight(int height, bool balanced)
            {
                Height = height;
                Balanced = balanced;
            }
        }
        public static bool IsBalanced2(BinaryTreeNode<int> root)
        {
            var res = CheckBalanced(root);           
            return res.Balanced;
        }
        
        private static BalanceStatusWithHeight CheckBalanced(BinaryTreeNode<int> root)
        {
            // base 
            if (root == null)
            {
                return new BalanceStatusWithHeight(-1, true);
            }
          
            var leftResult = CheckBalanced(root.Left);
            var rightResult = CheckBalanced(root.Right);
            
            if (!leftResult.Balanced)
            {
                return leftResult;
            }
            if (!rightResult.Balanced)
            {
                return rightResult;
            }
            var isBalanced = Math.Abs(leftResult.Height - rightResult.Height) <= 1;
            var height = Math.Max(leftResult.Height, rightResult.Height) + 1;
            
            return new BalanceStatusWithHeight(height, isBalanced);
        }

        public static void Test()
        {
            var root = BinaryTrees_00_TreeTraversal.BuildExampleTree();           

            var root3 = BinaryTrees_00_TreeTraversal.BuildHeightBalancedExample();
            var res3 = CheckBalanced(root3);
        }
    }
}
