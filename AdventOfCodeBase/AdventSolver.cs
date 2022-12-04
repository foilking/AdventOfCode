namespace AdventOfCodeBase;

public abstract class AdventSolver
{
    public bool UseSample { get; private set; }
    public string Year { get; private set; }
    public string Day { get; private set; }
    public string Name { get; private set; }
    public string CurrentDirectory
    {
        get
        {
            return $"{Year}/Day{Day}";
        }
    }
    public string FileName
    {
        get
        {
            return UseSample ? "sample" : "input";
        }
    }

    public string Input 
    {
        get 
        {
            return System.IO.File.ReadAllText($"{CurrentDirectory}/{FileName}.in");
        }
    }

    public AdventSolver(bool useSample, string year, string day, string name)
    {
        UseSample = useSample;
        Year = year;
        Day = day;
        Name = name;
    }
    public abstract void Part1();
    public abstract void Part2();


}

