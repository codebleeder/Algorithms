using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public class BinaryTreeNodeWithSize<T>: BinaryTreeNode<T>
    {
        public BinaryTreeNodeWithSize<T> Left { get; set; }
        public BinaryTreeNodeWithSize<T> Right { get; set; }
        public int Size { get; set; }
        public BinaryTreeNodeWithSize()
        {

        }
        public BinaryTreeNodeWithSize(T data)
        {
            Data = data;            
        }
        public BinaryTreeNodeWithSize(T data, int size)
        {
            Data = data;
            Size = size;
        }
        public BinaryTreeNodeWithSize(T data, BinaryTreeNodeWithSize<T> left, BinaryTreeNodeWithSize<T> right, int size)
        {
            Data = data;
            Left = left;
            Right = right;
            Size = size;
        }
    }
}
