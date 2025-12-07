namespace AdventOfCode2025.Days;

public class Day6 : IDay
{
    // input = ["123 328  51 64 ", ..., "*   +   *   +  "]

    private static long OperatorAggregate(string op, long x, long y) => op == "+" ? x + y : x * y;

    public string Part1(string[] input)
    {
        var operators = input[^1].Trim().Split(" ").Where(x => !string.IsNullOrEmpty(x));
        var numbers = input[..^1]
            .Select(x =>
                x.Trim()
                    .Split(" ")
                    .Where(y => !string.IsNullOrEmpty(y))
                    .Select(long.Parse)
                    .ToArray()
            );

        return operators
            .Select(
                (op, index) =>
                    numbers.Select(x => x[index]).Aggregate((x, y) => OperatorAggregate(op, x, y))
            )
            .Sum()
            .ToString();
    }

    private static string ColumnAggregate(string x, string y) =>
        x == " " ? y
        : y == " " ? x
        : (10 * long.Parse(x) + long.Parse(y)).ToString();

    public string Part2(string[] input)
    {
        // I refused to pivot the data... the challenge of doing it all with LINQ selectors was more fun
        var operators = input[^1].Trim().Split(" ").Where(x => !string.IsNullOrEmpty(x));
        var operatorLengths = $"{input[^1][1..]} "
            .Split(['+', '*'])
            .Select(x => x.Length)
            .ToArray();
        var numbers = input[..^1]
            .Select(x =>
                operatorLengths
                    .Select(
                        (length, index) =>
                            x.Substring(operatorLengths[..index].Sum() + index, length)
                    )
                    .ToArray()
            );

        return operators
            .Select(
                (op, index) =>
                    Enumerable
                        .Range(0, operatorLengths[index])
                        .Select(rowIndex =>
                            numbers
                                .Select(x => x[index][rowIndex].ToString())
                                .Aggregate(ColumnAggregate)
                        )
                        .Select(long.Parse)
                        .Aggregate((x, y) => OperatorAggregate(op, x, y))
            )
            .Sum()
            .ToString();
    }
}
