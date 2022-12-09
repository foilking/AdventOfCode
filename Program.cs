using System.CommandLine;
using System.Linq;
using AdventOfCodeBase;
using AdventOfCode2022;

var yearOption = new Option<string>("--year", "Calendar Year");
var dayOption = new Option<string>("--day", "Day of Year");
var useSampleOption = new Option<bool>("--useSample", "Use the sample data");

var cmd = new RootCommand("Advent of Code");
cmd.AddOption(yearOption);
cmd.AddOption(dayOption);
cmd.AddOption(useSampleOption);

cmd.SetHandler((year, day, useSample) =>
{
    var solvers = new List<AdventSolver>();

    System.Reflection.Assembly ass = System.Reflection.Assembly.GetEntryAssembly() ?? throw new ArgumentException();
    
    foreach (System.Reflection.TypeInfo ti in ass!.DefinedTypes!)
    {
        if (ti.BaseType != null && ti.BaseType.Equals(typeof(AdventOfCodeBase.AdventSolver)))
        {
            solvers.Add((Activator.CreateInstance(ti.AsType(), args: useSample) as AdventSolver)!);
        }
    }

    Console.WriteLine($"Year: {year} Day: {day} {(useSample ? "Use Sample: true" : "")}");
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
}, yearOption, dayOption, useSampleOption);

await cmd.InvokeAsync(args);
