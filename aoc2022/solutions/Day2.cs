using System.Text;

namespace aoc2022.solutions;

public class Day2 : ASolution
{
    public Day2(bool testInput) : base(testInput) { }

    public override string A()
    {
        var rounds = Input.Select(x => new Round(x, 'A'));
        return rounds.Aggregate(0, (sum, next) => sum + next.GetPoints(), sum => sum.ToString());
    }

    public override string B()
    {
        var rounds = Input.Select(x => new Round(x, 'B'));
        return rounds.Aggregate(0, (sum, next) => sum + next.GetPoints(), sum => sum.ToString());
    }
}

public record Round
{
    public Shape Opponent { get; init; }
    public Shape Self { get; init; }
    public Outcome RoundOutcome { get; init; }

    public Round(string input, char task)
    {
        var split = input.Split(' ');
        Opponent = ParseShape(split[0]);

        if (task == 'A')
        {
            Self = ParseShape(split[1]);
            RoundOutcome = GetOutcome(Opponent, Self);
        }
        else if (task == 'B')
        {
            RoundOutcome = ParseOutcome(split[1]);
            Self = GetShape(Opponent, RoundOutcome);
        }
    }

    public int GetPoints()
    {
        return (int)Self + (int)RoundOutcome;
    }

    private static Shape ParseShape(string value)
    {
        return value switch
        {
            "A" or "X" => Shape.Rock,
            "B" or "Y" => Shape.Paper,
            "C" or "Z" => Shape.Scissor,
            _ => Shape.Unknown,
        };
    }

    public static Outcome ParseOutcome(string value)
    {
        return value switch
        {
            "X" => Outcome.Loss,
            "Y" => Outcome.Draw,
            "Z" => Outcome.Win,
            _ => Outcome.Unknown,
        };
    }

    private static Outcome GetOutcome(Shape opponent, Shape self)
    {
        if (opponent == self)
            return Outcome.Draw;

        switch (opponent)
        {
            case Shape.Rock when self is Shape.Paper:
            case Shape.Paper when self is Shape.Scissor:
            case Shape.Scissor when self is Shape.Rock:
                return Outcome.Win;
        }

        return Outcome.Loss;
    }

    private static Shape GetShape(Shape opponent, Outcome outcome)
    {
        if (outcome == Outcome.Draw)
            return opponent;

        switch (outcome)
        {
            case Outcome.Loss when opponent is Shape.Rock:
            case Outcome.Win when opponent is Shape.Paper:
                return Shape.Scissor;
            case Outcome.Loss when opponent is Shape.Paper:
            case Outcome.Win when opponent is Shape.Scissor:
                return Shape.Rock;
            case Outcome.Loss when opponent is Shape.Scissor:
            case Outcome.Win when opponent is Shape.Rock:
                return Shape.Paper;
            default:
                return Shape.Unknown;
        }
    }
}

public enum Shape
{
    Unknown = int.MinValue,
    Rock = 1,
    Paper = 2,
    Scissor = 3
}

public enum Outcome
{
    Unknown = int.MinValue,
    Loss = 0,
    Draw = 3,
    Win = 6
}
