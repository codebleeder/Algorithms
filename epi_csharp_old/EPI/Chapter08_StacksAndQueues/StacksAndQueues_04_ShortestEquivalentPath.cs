using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter8_StacksAndQueues
{
    public static class StacksAndQueues_04_ShortestEquivalentPath
    {
        // Question not clear; Need more examples
        // Basic gist: store tokens in stack. If ".." appears, pop() if not root; error if root; ignore "."
        public static string ShortestEquivalentPath(string path)
        {
            var paths = path.Split('/');
            var pathStack = new Stack<string>();
            if (path.StartsWith("/"))
            {
                pathStack.Push("/");
            }
            foreach (var p in paths)
            {
                if (p != "." && p != "" && p != "..")
                {
                    pathStack.Push(p);
                }
                if (p == ".." && pathStack.Count > 0 && pathStack.Peek() != "/")
                {
                    pathStack.Pop();
                }
                else if (p == ".." && pathStack.Count > 0 && pathStack.Peek() == "/")
                {
                    throw new ArgumentException("invalid path; you cannot go up root");
                }
            }
            var sb = new StringBuilder();
            while (pathStack.Count > 0)
            {
                var token = pathStack.Pop();
                var forwardSlash = token == "/" ? "" : "/";
                sb.Append($"{forwardSlash}{token}");
            }
            if (sb.Length > 1 && sb[sb.Length - 1] == '/')
            {
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }
        public static string ShortestEquivalentPath2(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                throw new ArgumentException("empty string is not legal path");
            }
            var stack = new Stack<string>();
            if (path.StartsWith("/"))
            {
                stack.Push("/");
            }
            foreach(var p in path.Split('/'))
            {
                if (p == "..")
                {
                    if (stack.Count == 0 || stack.Peek() == "..")
                    {
                        stack.Push(p);
                    }
                    else
                    {
                        if (stack.Peek() == "/")
                        {
                            throw new ArgumentException("path error, trying to go up root " + path);
                        }
                        stack.Pop();
                    }
                }
                else if (p != "." && !String.IsNullOrEmpty(p))
                {
                    stack.Push(p);
                }
            }
            var sb = new StringBuilder();
            if (stack.Count > 0)
            {
                var prev = stack.Pop();
                sb.Append(prev);
                while (stack.Count > 0)
                {
                    if (prev != "/")
                    {
                        sb.Append("/");
                    }
                    prev = stack.Pop();
                    sb.Append(prev);
                }
            }
            return sb.ToString();
        }
        public static void Test()
        {
            var tests = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("/a/./b/../../c/", "/c/"),
                new Tuple<string, string>("a/b/..", "a/"),
                new Tuple<string, string>("a/..", "/"),
            };
            var i = 1;
            foreach (var test in tests)
            {
                var res = ShortestEquivalentPath(test.Item1);
                Console.WriteLine($"case {i} input: {test.Item1}  expected: {test.Item2}");
                Console.WriteLine($"result: {res}");
                i++;
            }
        }
    }
}
