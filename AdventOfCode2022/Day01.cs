public class Day01
{
    public Day01()
    {
        var input = System.IO.File.ReadAllText(@"Day01Input.in");

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
        var sortedElfList = elfList.OrderByDescending(e => e);
        Console.WriteLine($"Day 01 Part 1: {sortedElfList.First()}");
        Console.WriteLine($"Day 01 Part 2: {sortedElfList.Take(3).Sum()}");
    }
}