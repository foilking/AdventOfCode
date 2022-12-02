public class Day02
{
    public Day02()
    {
        string input = System.IO.File.ReadAllText(@"Day02.in");
        string[] rounds = input.Split(Environment.NewLine);
        Console.WriteLine($"Part 01 Score: {Part01(rounds)}");
        Console.WriteLine($"Part 02 Score: {Part02(rounds)}");
    }

    public int Part01(string[] rounds)
    {
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
        return totalScore;
    }

    public int Part02(string[] rounds)
    {
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
        return totalScore;
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
        (Result.Draw, _) => opponentThrow
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