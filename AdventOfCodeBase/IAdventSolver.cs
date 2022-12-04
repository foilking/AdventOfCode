namespace AdventOfCodeBase;

public interface IAdventSolver
{
    void Part1();
    void Part2();

    string Year{
        get;
    }
    string Day {
        get;
    }
    string Name {
        get;
    }
}

