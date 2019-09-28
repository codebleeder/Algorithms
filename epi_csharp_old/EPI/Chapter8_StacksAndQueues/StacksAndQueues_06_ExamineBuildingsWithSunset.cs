using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter8_StacksAndQueues
{
    public static class StacksAndQueues_06_ExamineBuildingsWithSunset
    {
        public static Stack<BuildingsWithHeight> ExamineBuildingsWithSunset(List<BuildingsWithHeight> sequence)
        {
            var result = new Stack<BuildingsWithHeight>();
            foreach(var building in sequence)
            {
                while (result.Count > 0 && result.Peek().Height <= building.Height)
                {
                    result.Pop();
                }
                result.Push(building);
            }
            return result;
        }
        public static void Test()
        {
            var tests = new List<Tuple<List<BuildingsWithHeight>, List<BuildingsWithHeight>>>
            {
                new Tuple<List<BuildingsWithHeight>, List<BuildingsWithHeight>>(
                        new List<BuildingsWithHeight>
                        {
                            new BuildingsWithHeight(1, 1),
                            new BuildingsWithHeight(2, 3),
                            new BuildingsWithHeight(3, 2),
                            new BuildingsWithHeight(4, 4),
                            new BuildingsWithHeight(5, 5),
                        },
                        new List<BuildingsWithHeight>
                        {                           
                            new BuildingsWithHeight(5, 5),
                        }
                    ),
                new Tuple<List<BuildingsWithHeight>, List<BuildingsWithHeight>>
                (
                    new List<BuildingsWithHeight>
                    {
                        new BuildingsWithHeight (1, 1),
                        new BuildingsWithHeight (2, 3),
                        new BuildingsWithHeight (3, 1),
                    },
                    new List<BuildingsWithHeight>
                    {
                        new BuildingsWithHeight (3, 1),
                        new BuildingsWithHeight (2, 3),
                    }
                ),
                new Tuple<List<BuildingsWithHeight>, List<BuildingsWithHeight>>(
                    new List<BuildingsWithHeight>
                    {
                        new BuildingsWithHeight(1, 6),
                        new BuildingsWithHeight(2, 5),
                        new BuildingsWithHeight(3, 4),
                        new BuildingsWithHeight(4, 3),
                        new BuildingsWithHeight(5, 5),
                    },
                    new List<BuildingsWithHeight>
                    {
                         new BuildingsWithHeight(5, 5),
                         new BuildingsWithHeight(1, 6),
                    }
                    )
            };
            var i = 1; 
            foreach (var test in tests)
            {
                Console.WriteLine($"case {i}");
                var res = ExamineBuildingsWithSunset(test.Item1);
                Console.WriteLine("expected: ");
                var sb = new StringBuilder();
                foreach (var b in test.Item2)
                {
                    sb.Append($"[id: {b.Id} height: {b.Height}], ");
                }
                Console.WriteLine(sb.ToString());
                Console.WriteLine("result: ");
                sb.Clear();
                while (res.Count > 0)
                {
                    var b = res.Pop();
                    sb.Append($"[id: {b.Id} height: {b.Height}], ");
                }
                Console.WriteLine(sb.ToString());
                i++;
                Console.WriteLine("");
            }
        }
    }
    public class BuildingsWithHeight
    {
        public int Id { get; set; }
        public int Height { get; set; }
        public BuildingsWithHeight(int id, int height)
        {
            Id = id;
            Height = height;
        }
    }
    
}
