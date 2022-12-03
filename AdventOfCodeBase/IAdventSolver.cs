namespace AdventOfCodeBase;

public interface IAdventSolver
{
    void Part01();
    void Part02();

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

