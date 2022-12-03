using AdventOfCodeBase;

namespace AdventOfCode2022.DayThree;
public class Solution : IAdventSolver
{
    private string _day;
    private string _year;
    private string _name;
    private string Input {get; set;}
    public Solution()
    {
        _name = "DayThree";
        _year = "2022";
        _day = "Three";
        var currentDirectory = $"{_year}/Day{_day}";
        var input = System.IO.File.ReadAllText($"{currentDirectory}/input.in");
        this.Input = input;
    }

    public string Day{
        get => _day;
    }
    public string Year {
        get => _year;
    }
    public string Name {
        get => _name;
    }

    public void Part01()
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
        Console.WriteLine($"Part 01 Total duplicate priority: {prioritySum}");
    }

    public void Part02()
    {
        string[] rucksacks = Input.Split(Environment.NewLine);
        var badgeSum = 0;
        for (int i = 0; i < rucksacks.Length / 3; i++)
        {
            var group = rucksacks.Skip(i * 3).Take(3).Select(r => r.ToCharArray().ToList());
            var badge = IntersectAll<char>(group).FirstOrDefault();
            badgeSum += GetPriority(badge);
        }
        Console.WriteLine($"Part 02 Total badge priority: {badgeSum}");
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