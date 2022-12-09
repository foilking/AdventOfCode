using System.Text.RegularExpressions;
using AdventOfCodeBase;

namespace AdventOfCode2022.Day6;

public class Solution : AdventSolver
{
    
    public Solution(bool useSample) : base (useSample, "2022", "6", "Day 6") {}

    public override void Part1()
    {
        var position = 0;
        for(int i = 0; i < this.Input.Length - 4; i++)
        {
            var marker = this.Input.ToCharArray().Skip(i).Take(4);
            if (marker.Distinct().Count() == marker.Count())
            {  
                position = i + 4;
                break;
            }
        }
        Console.WriteLine($"{Name} Part 1: {position}");
    }

    public override void Part2()
    {
        var position = 0;
        for(int i = 0; i < this.Input.Length - 14; i++)
        {
            var marker = this.Input.ToCharArray().Skip(i).Take(14);
            if (marker.Distinct().Count() == marker.Count())
            {  
                position = i + 14;
                break;
            }
        }
        Console.WriteLine($"{Name} Part 2: {position}");
    }
}
