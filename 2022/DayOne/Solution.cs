using AdventOfCodeBase;

namespace AdventOfCode2022.DayOne;
public class Solution : IAdventSolver
{
    private string _day;
    private string _year;
    private string _name;
    private string Input {get; set;}
    public Solution()
    {
        _name = "DayOne";
        _year = "2022";
        _day = "One";
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
        Console.WriteLine($"Day 01 Part 1: {Sort(Input).First()}");
    }
     
    public void Part02()
    {
        Console.WriteLine($"Day 01 Part 2: {Sort(Input).Take(3).Sum()}");
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
