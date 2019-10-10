using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter8_StacksAndQueues
{
    public static class StacksAndQueues_02_EvaluateRPN
    {
        public static int EvaluateRPN(string RPNExpression)
        {
            var elements = RPNExpression.Split(',');
            var stack = new Stack<int>();
            foreach(var e in elements)
            {
                if (int.TryParse(e, out int num))
                {
                    stack.Push(num);
                }
                else
                {
                    var b = stack.Pop();
                    var a = stack.Pop();
                    switch(e)
                    {
                        case "+":
                            stack.Push(a + b);
                            break;
                        case "-":
                            stack.Push(a - b);
                            break;
                        case "*":
                            stack.Push(a * b);
                            break;
                        case "/":
                            stack.Push(a / b);
                            break;
                    }
                }
            }
            return stack.Pop();
        }
        public static void Test()
        {
            var tests = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("3,4,+,2,*,1,+", 15),
                new Tuple<string, int>("1,1,+,-2,*", -4),
            };
            var i = 1;
            foreach (var test in tests)
            {
                var res = EvaluateRPN(test.Item1);
                Console.WriteLine($"case {i} string: {test.Item1}  expected: {test.Item2}  result: {res}  pass: {res == test.Item2}");
                i++;
            }
        }
    }
}
