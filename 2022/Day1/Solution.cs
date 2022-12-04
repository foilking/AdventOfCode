using AdventOfCodeBase;

namespace AdventOfCode2022.Day1;
public class Solution : AdventSolver
{
    public Solution(bool useSample) : base (useSample, "2022", "1", "Day 1") {}

    public override void Part1()
    {
        Console.WriteLine($"{Name} Part 1: {Sort(Input).First()}");
    }
     
    public override void Part2()
    {
        Console.WriteLine($"{Name} Part 2: {Sort(Input).Take(3).Sum()}");
    }

    private IEnumerable<int> Sort(string input)
    {
        var elfList = new List<int>();

        foreach (var elf in input.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
        {
            string[] calories = elf.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var totalCalories = 0;
            foreach (var calorie in calories)
            {
                if (Int32.TryParse(calorie, out var calorieInt))
                {
                    totalCalories += calorieInt;
                }
            }
            elfList.Add(totalCalories);
        }
        return elfList.OrderByDescending(e => e);
    }
}
