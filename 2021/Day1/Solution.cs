using AdventOfCodeBase;

namespace AdventOfCode2021.Day1;

public class Solution : AdventSolver
{
    public Solution(bool useSample) : base (useSample, "2021", "1", "Day 1") {}

    public override void Part1()
    {
        var depthMeasurements = Input.Split(Environment.NewLine).Select(int.Parse);   
        var increased = depthMeasurements.Zip(depthMeasurements.Skip(1)).Where(z => z.First < z.Second);
        Console.WriteLine($"{Year} {Name} Part 1: {increased.Count()}");
    }

    public override void Part2()
    {
        int[] depthMeasurements = Input.Split(Environment.NewLine).Select(int.Parse).ToArray();   
        var threeMeasurementTotals = depthMeasurements.Zip(depthMeasurements.Skip(1), depthMeasurements.Skip(2)).Select(z => z.First + z.Second + z.Third);
        var increased = threeMeasurementTotals.Zip(threeMeasurementTotals.Skip(1)).Where(z => z.First < z.Second);
        Console.WriteLine($"{Year} {Name} Part 2: {increased.Count()}");
    }
}