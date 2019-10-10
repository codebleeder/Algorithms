using System;
using System.Collections.Generic;
using System.Text;
using EPI.Chapter09_BinaryTrees;

namespace EPI.Chapter8_StacksAndQueues
{
    public static class StacksAndQueues_07_BinaryTreeDepthOrder
    {
        public static List<List<int>> BinaryTreeDepthOrder(BinaryTreeNode<int> tree)
        {
            var q = new Queue<BinaryTreeNode<int>>();
            q.Enqueue(tree);
            var result = new List<List<int>>();
            while (q.Count > 0)
            {
                var sublist = new List<int>();
                var subQueue = new Queue<BinaryTreeNode<int>>();
                while (q.Count > 0)
                {
                    var n = q.Dequeue();
                    if (n != null)
                    {
                        sublist.Add(n.Data);
                        subQueue.Enqueue(n.Left);
                        subQueue.Enqueue(n.Right);
                    }
                    
                }
                if (sublist.Count > 0)
                {
                    result.Add(sublist);
                }                
                q = subQueue;
            }
            return result;
        }
        
        public static void Test()
        {                                                
            var expectedList = new List<List<int>>
            {
                new List<int> {314},
                new List<int> {6, 6},
                new List<int> {272, 461, 2, 271},
                new List<int> {28, 0, 3, 1, 28},
                new List<int> {17, 401, 257},
                new List<int> {641}
            };

            var a = BinaryTrees_00_TreeTraversal.BuildExampleTree();
            var res = BinaryTreeDepthOrder(a);
            Console.WriteLine("result: ");
            for (var index = 0; index < res.Count; index++)
            {
                Utilities.PrintList(res[index]);
            }
        }
    }
}
