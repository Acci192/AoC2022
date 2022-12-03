namespace aoc2022.solutions;

public class Day3 : ASolution
{
    public Day3(bool testInput) : base(testInput) { }

    public override string A()
    {
        var items = new List<char>();
        foreach(var row in Input)
        {
            var comparment1 = row.Take(row.Length/2);
            var comparment2 = row.Skip(row.Length/2);

            var item = comparment1.Where(x => comparment2.Contains(x)).FirstOrDefault();

            items.Add(item);
        }

        var sum = 0;
        foreach(var item in items)
        {
            if (char.IsUpper(item))
            {
                sum += item - 'A' + 1 + 26;
            }
            else
            {
                sum += item - 'a' + 1;
            }
        }
        return sum.ToString();
    }

    public override string B()
    {
        var groups = GetGroups(Input);

        var keys = new List<char>();
        foreach(var group in groups)
        {
            keys.Add(group[0].Where(x => group[1].Contains(x) && group[2].Contains(x)).FirstOrDefault());
        }
        var sum = 0;
        foreach (var item in keys)
        {
            if (char.IsUpper(item))
            {
                sum += item - 'A' + 1 + 26;
            }
            else
            {
                sum += item - 'a' + 1;
            }
        }
        return sum.ToString();
    }

    private IEnumerable<List<string>> GetGroups(IEnumerable<string> input)
    {
        var group = new List<string>();

        var counter = 0;
        foreach(var row in input)
        {
            group.Add(row);
            counter++;

            if(counter % 3 == 0)
            {
                yield return group;
                group = new List<string>();
            }
        }

    }
}
