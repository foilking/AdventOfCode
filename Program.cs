using System.CommandLine;
using System.Linq;
using AdventOfCodeBase;
using AdventOfCode2022;

var solvers = new List<IAdventSolver>();

System.Reflection.Assembly ass = System.Reflection.Assembly.GetEntryAssembly() ?? throw new ArgumentException();

foreach (System.Reflection.TypeInfo ti in ass!.DefinedTypes!)
{
    if (ti.ImplementedInterfaces.Contains(typeof(AdventOfCodeBase.IAdventSolver)))
    {
        solvers.Add((ass!.CreateInstance(ti.FullName) as IAdventSolver)!);
    }
}

var yearOption = new Option<string>("--year", "Calendar Year");
var dayOption = new Option<string>("--day", "Day of Year");

var cmd = new RootCommand("Advent of Code");
cmd.AddOption(yearOption);
cmd.AddOption(dayOption);

cmd.SetHandler((year, day) =>
{
    Console.WriteLine($"Year: {year} Day: {day}");
    var selectedSolvers = solvers
        .Where(s => (string.IsNullOrWhiteSpace(year) ? true : s.Year == year)
            && (string.IsNullOrWhiteSpace(day) ? true : s.Day == day))
        .OrderBy(s => s.Year).ThenBy(s => s.Day);

    if (selectedSolvers.Count() > 0)
    {
        foreach (var solver in selectedSolvers)
        {
            solver.Part1();
            solver.Part2();
        }
    }
    else
    {
        Console.WriteLine("Solver not found");
    }
}, yearOption, dayOption);

await cmd.InvokeAsync(args);
