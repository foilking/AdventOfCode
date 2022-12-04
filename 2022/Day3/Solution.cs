using AdventOfCodeBase;

namespace AdventOfCode2022.Day3;
public class Solution : AdventSolver
{    
    public Solution(bool useSample) : base (useSample, "2022", "3", "Day 3") {}

    public override void Part1()
    {
        string[] rucksacks = Input.Split(Environment.NewLine);
        var prioritySum = 0;
        foreach (var rucksack in rucksacks)
        {
            var compartmentOne = rucksack.Take(rucksack.Length / 2);
            var compartmentTwo = rucksack.Skip(rucksack.Length / 2);
            var sameGift = compartmentOne.Intersect(compartmentTwo).FirstOrDefault();
            prioritySum += GetPriority(sameGift);
        }
        Console.WriteLine($"{Name} Part 1: {prioritySum}");
    }

    public override void Part2()
    {
        string[] rucksacks = Input.Split(Environment.NewLine);
        var badgeSum = 0;
        for (int i = 0; i < rucksacks.Length / 3; i++)
        {
            var group = rucksacks.Skip(i * 3).Take(3).Select(r => r.ToCharArray().ToList());
            var badge = IntersectAll<char>(group).FirstOrDefault();
            badgeSum += GetPriority(badge);
        }
        Console.WriteLine($"{Name} Part 2: {badgeSum}");
    }

    private int GetPriority(char value)
    {
        return (value < 97 ? value - 38 : value - 96);
    }

    private List<T> IntersectAll<T>(IEnumerable<IEnumerable<T>> lists)
    {
        HashSet<T> hashSet = new HashSet<T>(lists.First());
        foreach (var list in lists.Skip(1))
        {
            hashSet.IntersectWith(list);
        }
        return hashSet.ToList();
    }
}