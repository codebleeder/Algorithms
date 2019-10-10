using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public class BinaryTreeNodeWithNext<T>: BinaryTreeNode<T> 
    {
        public BinaryTreeNodeWithNext<T> Left { get; set; }
        public BinaryTreeNodeWithNext<T> Right { get; set; }
        public BinaryTreeNodeWithNext<T> Next { get; set; }
        public BinaryTreeNodeWithNext()
        {

        }
        public BinaryTreeNodeWithNext(T data)
        {
            Data = data;
        }
        public BinaryTreeNodeWithNext(T data, BinaryTreeNodeWithNext<T> left, BinaryTreeNodeWithNext<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }
        public BinaryTreeNodeWithNext(BinaryTreeNodeWithNext<T> left, BinaryTreeNodeWithNext<T> right, BinaryTreeNodeWithNext<T> next)
        {
            Left = left;
            Right = right;
            Next = next;
        }
    }
}
