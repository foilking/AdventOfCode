
using System.Text.RegularExpressions;
using AdventOfCodeBase;

namespace AdventOfCode2022.Day5;

public class Solution : AdventSolver
{
    
    public Solution(bool useSample) : base (useSample, "2022", "5", "Day 5") {}

    public override void Part1()
    {
        // split input bases on empty line
        var inputLines = Input.Split(Environment.NewLine).ToList<string>();
        var splitIndex = inputLines.IndexOf("");
        
        // take first half, reverse it, and build out data struct
        var stackLines = inputLines.Take(splitIndex).Reverse().ToList();
        var stackCount = stackLines.First().Split(" ").Where(s => !string.IsNullOrEmpty(s)).Select(int.Parse).Last();
        var stacks = new Dictionary<int, List<string>>();
        var line = 1;
        foreach(var stackLine in stackLines.Skip(1)) 
        {
            for (int i = 0; i < stackCount; i++) {
                var crate = new string(stackLine.Skip(i * 4).Take(3).ToArray())
                    .Replace("[", "").Replace("]","");
                if (string.IsNullOrWhiteSpace(crate))
                {
                    continue;
                }
                if (!stacks.ContainsKey(i + 1)) {
                    stacks.Add(i+1, new List<string>{crate});
                } else {
                    var stack = stacks[i+1];
                    stack.Add(crate);
                    stacks[i+1] = stack;
                }
            }
            line++;
        }
        // use second half to move info in struct
        var instructions = inputLines.Skip(splitIndex + 1).ToList();
        foreach (var instruction in instructions) {
            var movements = new Regex(@"\d+").Matches(instruction)
                              .Cast<Match>()
                              .Select(m => Int32.Parse(m.Value)).ToList();
            var takeAmount = movements.First();
            var fromColumn = movements.Skip(1).First();
            var toColumn = movements.Skip(2).First();
            var toAdd = stacks[fromColumn].Skip(Math.Max(0, stacks[fromColumn].Count() - takeAmount)).Reverse().ToList();
            var newFrom = stacks[fromColumn].Take(Math.Max(0, stacks[fromColumn].Count() - takeAmount)).ToList();
            stacks[fromColumn] = newFrom;
            stacks[toColumn].AddRange(toAdd);
        }
        Console.WriteLine($"{Name} Part 1: {string.Join("", stacks.Select(s => s.Value.Last()).ToArray())}");
    }

    public override void Part2()
    {
        // split input bases on empty line
        var inputLines = Input.Split(Environment.NewLine).ToList<string>();
        var splitIndex = inputLines.IndexOf("");
        
        // take first half, reverse it, and build out data struct
        var stackLines = inputLines.Take(splitIndex).Reverse().ToList();
        var stackCount = stackLines.First().Split(" ").Where(s => !string.IsNullOrEmpty(s)).Select(int.Parse).Last();
        var stacks = new Dictionary<int, List<string>>();
        var line = 1;
        foreach(var stackLine in stackLines.Skip(1)) 
        {
            for (int i = 0; i < stackCount; i++) {
                var crate = new string(stackLine.Skip(i * 4).Take(3).ToArray())
                    .Replace("[", "").Replace("]","");
                if (string.IsNullOrWhiteSpace(crate))
                {
                    continue;
                }
                if (!stacks.ContainsKey(i + 1)) {
                    stacks.Add(i+1, new List<string>{crate});
                } else {
                    var stack = stacks[i+1];
                    stack.Add(crate);
                    stacks[i+1] = stack;
                }
            }
            line++;
        }
        // use second half to move info in struct
        var instructions = inputLines.Skip(splitIndex + 1).ToList();
        foreach (var instruction in instructions) {
            var movements = new Regex(@"\d+").Matches(instruction)
                              .Cast<Match>()
                              .Select(m => Int32.Parse(m.Value)).ToList();
            var takeAmount = movements.First();
            var fromColumn = movements.Skip(1).First();
            var toColumn = movements.Skip(2).First();
            var toAdd = stacks[fromColumn].Skip(Math.Max(0, stacks[fromColumn].Count() - takeAmount)).ToList();
            var newFrom = stacks[fromColumn].Take(Math.Max(0, stacks[fromColumn].Count() - takeAmount)).ToList();
            stacks[fromColumn] = newFrom;
            stacks[toColumn].AddRange(toAdd);
        }
        Console.WriteLine($"{Name} Part 2: {string.Join("", stacks.Select(s => s.Value.Last()).ToArray())}");
    }
}