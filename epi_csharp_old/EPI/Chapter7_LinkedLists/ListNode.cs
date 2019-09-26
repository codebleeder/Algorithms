using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter7_LinkedLists
{
    public class ListNode<T>
    {
        public T Data { get; set; }
        public ListNode<T> Next;       
        public ListNode(T value)
        {
            Data = value;
        }
        public ListNode(T v, ListNode<T> n)
        {
            this.Data = v;
            Next = n;
        }

        public static ListNode<int> Search(ListNode<int> l, int key)
        {
            while (l != null && l.Data != key)
            {
                l = l.Next;
            }
            return l;
        }
        public static void InsertAfter(ListNode<int> node, ListNode<int> newNode)
        {
            newNode.Next = node.Next;
            node.Next = newNode;
        }
        public static void DeleteAfter(ListNode<int> node)
        {
            node.Next = node.Next.Next;
        }
        public static void Print(ListNode<T> l)
        {            
            var sb = new StringBuilder();
            while(l != null)
            {
                sb.Append($"{l.Data} -> ");
                l = l.Next;
            }
            Console.WriteLine(sb.ToString());
        }
        // builds a linked list and returns head of the list 
        public static ListNode<T> BuildLinkedList(T[] a)
        {
            var head = new ListNode<T>(a[0]);
            var current = head;
            for (var i = 1; i < a.Length; i++)
            {
                current.Next = new ListNode<T>(a[i]);
                current = current.Next;
            }
            return head;
        }
        public static int Length(ListNode<T> head)
        {
            var length = 0; 
            while (head != null)
            {
                head = head.Next;
                length++;
            }
            return length;
        }
        public static int Length(ListNode<T> head, ListNode<T> n)
        {
            var length = 0;
            var current = head; 
            while (current != n && current != null)
            {
                current = current.Next;
                length++;
            }
            if (current == null)
            {
                return -1;
            }
            return length; 
        }
        public static ListNode<int> MoveByK(ListNode<int> head, int k)
        {
            while (k-- > 0)
            {
                head = head.Next;
            }
            return head;
        }
    }
}
