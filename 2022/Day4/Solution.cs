using AdventOfCodeBase;

namespace AdventOfCode2022.Day4;

public class Solution : IAdventSolver
{
    private string _day;
    private string _year;
    private string _name;
    private string Input {get; set;}
    public Solution()
    {
        _name = "Day 4";
        _year = "2022";
        _day = "4";
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
        string[] assignmentPairs = Input.Split(Environment.NewLine);
        var fullOverLapCounter = 0;
        foreach(var assignmentPair in assignmentPairs)
        {
            var elfAssignments = assignmentPair.Split(',');
            var elfSections = new List<List<int>>();
            foreach (var elfAssignment in elfAssignments)
            {
                var sectionIds = elfAssignment.Split('-');
                var sectionStart = int.Parse(sectionIds[0]);
                var sectionEnd = int.Parse(sectionIds[1]);
                var sectionList = Enumerable.Range(sectionStart, sectionEnd - sectionStart + 1).ToList();
                elfSections.Add(sectionList);
            }
            var firstElf = elfSections.First();
            var secondElf = elfSections.Skip(1).First();
            var allOfList1IsInList2 = firstElf.Intersect(secondElf).Count() == firstElf.Count();
            var allOfList2IsInList1 = secondElf.Intersect(firstElf).Count() == secondElf.Count();
            
            if (allOfList1IsInList2 || allOfList2IsInList1)
            {
                fullOverLapCounter++;
            }
        }
        
        Console.WriteLine($"{_name} Part 1: {fullOverLapCounter}");
    }

    public void Part2()
    {
        string[] assignmentPairs = Input.Split(Environment.NewLine);
        var overLapCounter = 0;
        foreach(var assignmentPair in assignmentPairs)
        {
            var elfAssignments = assignmentPair.Split(',');
            var elfSections = new List<List<int>>();
            foreach (var elfAssignment in elfAssignments)
            {
                var sectionIds = elfAssignment.Split('-');
                var sectionStart = int.Parse(sectionIds[0]);
                var sectionEnd = int.Parse(sectionIds[1]);
                var sectionList = Enumerable.Range(sectionStart, sectionEnd - sectionStart + 1).ToList();
                elfSections.Add(sectionList);
            }
            var firstElf = elfSections.First();
            var secondElf = elfSections.Skip(1).First();
            var anyOfList1IsInList2 = firstElf.Intersect(secondElf).Any();
            var anyOfList2IsInList1 = secondElf.Intersect(firstElf).Any();
            
            if (anyOfList1IsInList2 || anyOfList2IsInList1)
            {
                overLapCounter++;
            }
        }
        
        Console.WriteLine($"{_name} Part 2: {overLapCounter}");

    }
}