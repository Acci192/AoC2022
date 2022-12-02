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
        return string.Empty;
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

    public IEnumerable<Round> GetRounds()
    {
        foreach(var row in Input)
        {
            var split = row.Split(' ');

            yield return new Round(GetShape(split[0]), GetShape(split[1]));
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
}

public record Round(Shape Opponent, Shape Self);

public enum Shape
{
    Unknown,
    Rock,
    Paper,
    Scissor
}
