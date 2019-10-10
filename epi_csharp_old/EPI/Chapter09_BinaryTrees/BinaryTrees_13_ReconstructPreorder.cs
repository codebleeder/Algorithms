using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public static class BinaryTrees_13_ReconstructPreorder
    {
        public static int SubtreeIndex { get; set; }
        public static BinaryTreeNode<int?> ReconstructPreorder(List<int?> preorder)
        {
            SubtreeIndex = 0;
            return ReconstructPreorderSubtree(preorder);
        }

        private static BinaryTreeNode<int?> ReconstructPreorderSubtree(List<int?> preorder)
        {
            var subtreeKey = preorder[SubtreeIndex];
            ++SubtreeIndex;
            if (subtreeKey == null)
            {
                return null;
            }
            var leftSubtree = ReconstructPreorderSubtree(preorder);
            var rightSubtree = ReconstructPreorderSubtree(preorder);
            return new BinaryTreeNode<int?>(subtreeKey, leftSubtree, rightSubtree);
        }

        public static void Test()
        {
            var tests = new List<List<int?>>
            {
                new List<int?> { 1, 2, 4, null, null, 5, null, null, 3, null, null },
                new List<int?> { 8, 2, 6, null, null, 5, 1, null, null, null, 3, null, 4, null, 7, 9, null, null, null }
            };
            for(var i=0; i < tests.Count; i++)
            {
                var res = ReconstructPreorder(tests[i]);
            }
        }
    }
}
