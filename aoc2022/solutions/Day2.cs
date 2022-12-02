namespace aoc2022.solutions;

public class Day2 : ASolution
{
    public Day2(bool testInput) : base(testInput) { }

    public override string A()
    {
        var rounds = GetRounds();

        var sum = 0; ;
        foreach(var round in rounds)
        {
            sum += CalculateRound(round);
        }
        return sum.ToString();
    }

    public override string B()
    {
        var rounds = GetRounds_B();

        var sum = 0;
        foreach (var round in rounds)
        {
            sum += CalculateRoundB(round);
        }
        return sum.ToString();
    }

    public static int CalculateRound(Round round)
    {
        var sum = 0;
        switch (round.Self)
        {
            case Shape.Rock:
                sum += 1;
                break;
            case Shape.Paper:
                sum += 2;
                break;
            case Shape.Scissor:
                sum += 3;
                break;
            default:
                return int.MinValue;
        }

        switch (round.Opponent)
        {
            case Shape.Rock when round.Self is Shape.Paper:
            case Shape.Paper when round.Self is Shape.Scissor:
            case Shape.Scissor when round.Self is Shape.Rock:
                sum += 6;
                break;
            case Shape.Rock when round.Self is Shape.Rock:
            case Shape.Paper when round.Self is Shape.Paper:
            case Shape.Scissor when round.Self is Shape.Scissor:
                sum += 3;
                break;
            default:
                break;
        }

        return sum;
    }

    public static int CalculateRoundB(RoundB round)
    {
        var sum = 0;

        switch (round.Outcome)
        {
            case Outcome.Loss when round.Opponent is Shape.Rock:
                return 3;
            case Outcome.Loss when round.Opponent is Shape.Paper:
                return 1;
            case Outcome.Loss when round.Opponent is Shape.Scissor:
                return 2;
            case Outcome.Draw when round.Opponent is Shape.Rock:
                return 4;
            case Outcome.Draw when round.Opponent is Shape.Paper:
                return 5;
            case Outcome.Draw when round.Opponent is Shape.Scissor:
                return 6;
            case Outcome.Win when round.Opponent is Shape.Rock:
                return 8;
            case Outcome.Win when round.Opponent is Shape.Paper:
                return 9;
            case Outcome.Win when round.Opponent is Shape.Scissor:
                return 7;
            default:
                break;
        }

        return sum;
    }

    public IEnumerable<Round> GetRounds()
    {
        foreach(var row in Input)
        {
            var split = row.Split(' ');

            yield return new Round(GetShape(split[0]), GetShape(split[1]));
        }
    }

    public IEnumerable<RoundB> GetRounds_B()
    {
        foreach(var row in Input)
        {
            var split = row.Split(' ');

            yield return new RoundB(GetShape(split[0]), GetOutcome(split[1]));
        }
    }

    public static Shape GetShape(string input)
    {
        return input switch
        {
            "A" or "X" => Shape.Rock,
            "B" or "Y" => Shape.Paper,
            "C" or "Z" => Shape.Scissor,
            _ => Shape.Unknown,
        };
    }


    public static Outcome GetOutcome(string input)
    {
        return input switch
        {
            "X" => Outcome.Loss,
            "Y" => Outcome.Draw,
            "Z" => Outcome.Win,
            _ => Outcome.Unknown,
        };
    }
}

public record Round(Shape Opponent, Shape Self);
public record RoundB(Shape Opponent, Outcome Outcome);

public enum Shape
{
    Unknown,
    Rock,
    Paper,
    Scissor
}

public enum Outcome
{
    Unknown,
    Win,
    Draw,
    Loss
}
