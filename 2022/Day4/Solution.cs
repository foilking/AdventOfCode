using AdventOfCodeBase;

namespace AdventOfCode2022.Day4;

public class Solution : AdventSolver
{
    
    public Solution(bool useSample) : base (useSample, "2022", "4", "Day 4") {}

    public override void Part1()
    {
        var fullOverLapCounter = FindDuplicateCount(IsOverlap);
        Console.WriteLine($"{Name} Part 1: {fullOverLapCounter}");
    }

    public override void Part2()
    {
        var duplicateCounter = FindDuplicateCount(HasDuplicate);        
        Console.WriteLine($"{Name} Part 2: {duplicateCounter}");
    }

    private int FindDuplicateCount(Func<IEnumerable<int>, IEnumerable<int>, bool> checker)
    {
        string[] assignmentPairs = Input.Split(Environment.NewLine);
        var duplicateCount = 0;
        foreach(var assignmentPair in assignmentPairs)
        {
            var elfAssignments = assignmentPair.Split(',');
            var elfSections = new List<List<int>>();
            foreach (var elfAssignment in elfAssignments)
            {
                var sectionIds = elfAssignment.Split('-').Select(int.Parse);
                var sectionRange = new Range(sectionIds.First(), sectionIds.Last());
                var sectionList = Enumerable.Range(sectionRange.Start, sectionRange.End - sectionRange.Start + 1).ToList();
                elfSections.Add(sectionList);
            }
            var firstElf = elfSections.First();
            var secondElf = elfSections.Skip(1).First();
            
            if (checker(firstElf, secondElf))
            {
                duplicateCount++;
            }
        }
        return duplicateCount;
    }

    private bool IsOverlap(IEnumerable<int> list1, IEnumerable<int> list2) 
    {
        var allOfList1IsInList2 = list1.Intersect(list2).Count() == list1.Count();
        var allOfList2IsInList1 = list2.Intersect(list1).Count() == list2.Count();
        return allOfList1IsInList2 || allOfList2IsInList1;
    }
    
    private bool HasDuplicate(IEnumerable<int> list1, IEnumerable<int> list2) 
    {
        var anyOfList1IsInList2 = list1.Intersect(list2).Any();
        var anyOfList2IsInList1 = list2.Intersect(list1).Any();
        return anyOfList1IsInList2 || anyOfList2IsInList1;
    }
}

public record struct Range (int Start, int End);