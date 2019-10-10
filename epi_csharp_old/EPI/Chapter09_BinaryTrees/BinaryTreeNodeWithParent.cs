using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter09_BinaryTrees
{
    public class BinaryTreeNodeWithParent<T>
    {
        public T Data { get; set; }
        public BinaryTreeNodeWithParent<T> Left { get; set; }
        public BinaryTreeNodeWithParent<T> Right { get; set; }
        public BinaryTreeNodeWithParent<T> Parent { get; set; }
        public BinaryTreeNodeWithParent()
        {

        }
        public BinaryTreeNodeWithParent(T data)
        {
            Data = data;
        }
        public BinaryTreeNodeWithParent(T data, BinaryTreeNodeWithParent<T> left,
            BinaryTreeNodeWithParent<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }
        public BinaryTreeNodeWithParent(T data, BinaryTreeNodeWithParent<T> left,
            BinaryTreeNodeWithParent<T> right, BinaryTreeNodeWithParent<T> parent)
        {
            Data = data;
            Left = left;
            Right = right;
            Parent = parent;
        }
    }
}
