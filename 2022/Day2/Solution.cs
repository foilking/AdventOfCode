using AdventOfCodeBase;

namespace AdventOfCode2022.Day2;
public class Solution : IAdventSolver
{
    private string _day;
    private string _year;
    private string _name;
    private string Input {get; set;}
    public Solution()
    {
        _name = "Day 2";
        _year = "2022";
        _day = "2";
        var currentDirectory = $"{_year}/Day{_day}";
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
        string[] rounds = Input.Split(Environment.NewLine);
        var totalScore = 0;
        foreach (var round in rounds)
        {
            var throws = round.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var opponentThrow = ConvertThrowInput(throws[0]);
            var myThrow = ConvertThrowInput(throws[1]);
            var result = RockPaperScissors(myThrow, opponentThrow);
            var score = ScoreThrow(myThrow) + ScoreOutcome(result);
            totalScore += score;
        }
        Console.WriteLine($"{_name} Part 1: {totalScore}");

    }

    public void Part2()
    {
        string[] rounds = Input.Split(Environment.NewLine);
        var totalScore = 0;
        foreach (var round in rounds)
        {
            var inputs = round.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var opponentThrow = ConvertThrowInput(inputs[0]);
            var desiredResult = ConvertDesiredResult(inputs[1]);
            var myThrow = DesiredThrow(desiredResult, opponentThrow);
            var score = ScoreThrow(myThrow) + ScoreOutcome(desiredResult);
            totalScore += score;
        }
        Console.WriteLine($"{_name} Part 2: {totalScore}");
    }

    public string ConvertThrowInput(string input) => (input) switch
    {
        "A" => RPS.Rock,
        "B" => RPS.Paper,
        "C" => RPS.Scissors,
        "X" => RPS.Rock,
        "Y" => RPS.Paper,
        "Z" => RPS.Scissors,
        _ => ""
    };

    public string ConvertDesiredResult(string input) => (input) switch
    {
        "X" => Result.Lose,
        "Y" => Result.Draw,
        "Z" => Result.Win,
        _ => ""
    };

    public string RockPaperScissors(string first, string second) => (first, second) switch
    {
        (RPS.Rock, RPS.Scissors) => Result.Win,
        (RPS.Paper, RPS.Rock) => Result.Win,
        (RPS.Scissors, RPS.Paper) => Result.Win,
        (RPS.Rock, RPS.Paper) => Result.Lose,
        (RPS.Paper, RPS.Scissors) => Result.Lose,
        (RPS.Scissors, RPS.Rock) => Result.Lose,
        (_, _) => Result.Draw
    };

    public int ScoreThrow(string myThrow) => (myThrow) switch
    {
        RPS.Rock => 1,
        RPS.Paper => 2,
        RPS.Scissors => 3,
        _ => 0
    };

    public int ScoreOutcome(string outcome) => (outcome) switch
    {
        Result.Win => 6,
        Result.Draw => 3,
        Result.Lose => 0,
        _ => 0
    };

    public string DesiredThrow(string outcome, string opponentThrow) => (outcome, opponentThrow) switch
    {
        (Result.Win, RPS.Paper) => RPS.Scissors,
        (Result.Win, RPS.Rock) => RPS.Paper,
        (Result.Win, RPS.Scissors) => RPS.Rock,
        (Result.Lose, RPS.Paper) => RPS.Rock,
        (Result.Lose, RPS.Rock) => RPS.Scissors,
        (Result.Lose, RPS.Scissors) => RPS.Paper,
        (_, _) => opponentThrow
    };
}

public class RPS
{
    public const string Rock = "Rock";
    public const string Paper = "Paper";
    public const string Scissors = "Scissors";
}

public class Result
{
    public const string Lose = "Lose";
    public const string Draw = "Draw";
    public const string Win = "Win";
}