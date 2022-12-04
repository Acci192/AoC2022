namespace aoc2022.solutions;

public class Day4 : ASolution
{
    public Day4(bool testInput) : base(testInput) { }

    public override string A()
    {
        var pairs = GetPairs(Input);

        var sum = 0;
        foreach(var pair in pairs)
        {
            if(pair.first.Start <= pair.second.Start 
                && pair.first.End >= pair.second.End)
            {
                sum++;
            }
            else if(pair.second.Start <= pair.first.Start
                && pair.second.End >= pair.first.End)
            {
                sum++;
            }
        }

        return sum.ToString();
    }

    public override string B()
    {
        var pairs = GetPairs(Input);

        var sum = 0;
        foreach (var (first, second) in pairs)
        {
            var test = Enumerable.Range(first.Start, first.End - first.Start + 1).ToList();
            var test1 = Enumerable.Range(second.Start, second.End - second.Start + 1).ToList();

            if (test.Any(x => test1.Contains(x)))
                sum++;
        }

        return sum.ToString();
    }

    public IEnumerable<(Assignment first, Assignment second)> GetPairs(IEnumerable<string> input)
    {
        foreach(var row in input)
        {
            var split = row.Split(',');
            yield return (new Assignment(split[0]), new Assignment(split[1]));
        }
    }
}

public class Assignment
{
    public int Start { get; set; }
    public int End { get; set; }
    
    public Assignment(string input)
    {
        var split = input.Split('-');
        Start = int.Parse(split[0]);
        End = int.Parse(split[1]);
    }
}
