public class Day03
{
    public Day03()
    {
        string input = System.IO.File.ReadAllText(@"Day03.in");
        string[] rucksacks = input.Split(Environment.NewLine);
        Console.WriteLine($"Total duplicate priority: {Part01(rucksacks)}");
        Console.WriteLine($"Total badge priority: {Part02(rucksacks)}");
    }

    private int Part01(string[] rucksacks)
    {
        var prioritySum = 0;
        foreach (var rucksack in rucksacks)
        {
            var compartmentOne = rucksack.Take(rucksack.Length / 2);
            var compartmentTwo = rucksack.Skip(rucksack.Length / 2);
            var sameGift = compartmentOne.Intersect(compartmentTwo).FirstOrDefault();
            prioritySum += GetPriority(sameGift);
        }
        return prioritySum;
    }

    private int Part02(string[] rucksacks)
    {
        var badgeSum = 0;
        for (int i = 0; i < rucksacks.Length / 3; i++)
        {
            var group = rucksacks.Skip(i * 3).Take(3).Select(r => r.ToCharArray().ToList());
            var badge = IntersectAll<char>(group).FirstOrDefault();
            badgeSum += GetPriority(badge);
        }
        return badgeSum;
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