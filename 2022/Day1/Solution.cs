using AdventOfCodeBase;

namespace AdventOfCode2022.Day1;
public class Solution : IAdventSolver
{
    private string _day;
    private string _year;
    private string _name;
    private string Input {get; set;}
    public Solution()
    {
        _name = "Day 1";
        _year = "2022";
        _day = "1";
        var currentDirectory = $"{_year}/Day{_day.ToString()}";
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

    public void Part1()
    {
        Console.WriteLine($"{_name} Part 1: {Sort(Input).First()}");
    }
     
    public void Part2()
    {
        Console.WriteLine($"{_name} Part 2: {Sort(Input).Take(3).Sum()}");
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
