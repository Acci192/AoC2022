using aoc2022.solutions;
using FluentAssertions;

namespace SolutionTests;

public class Day2Tests
{
    public ASolution Solution { get; set; }
    public Day2Tests()
    {
        Solution = new Day0(true);
    }

    [Fact]
    public void A()
    {
        Solution.A().Should().Be("");
    }

    [Fact]
    public void B()
    {
        Solution.B().Should().Be("");
    }
}