namespace AdventOfCode2025.Days;

public class Day4 : IDay
{
    // input = ["..@@.@@@@.", "@@@.@.@.@@", ...]
    private static List<(int x, int y)> Neighbours(int i, int j) =>
        [
            (i - 1, j - 1),
            (i, j - 1),
            (i + 1, j - 1),
            (i - 1, j),
            (i + 1, j),
            (i - 1, j + 1),
            (i, j + 1),
            (i + 1, j + 1),
        ];

    public string Part1(string[] input)
    {
        var sum = 0;
        var width = input[0].Length;
        var height = input.Length;

        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                if (
                    input[i][j] == '@'
                    && Neighbours(i, j)
                        .Sum(
                            (n) =>
                                n.x >= 0
                                && n.x < width
                                && n.y >= 0
                                && n.y < height
                                && input[n.x][n.y] == '@'
                                    ? 1
                                    : 0
                        ) < 4
                )
                {
                    sum++;
                }
            }
        }

        return sum.ToString();
    }

    public string Part2(string[] input)
    {
        var sum = 0;
        var removed = new List<(int x, int y)>();
        var inputChars = input.Select(x => x.ToArray()).ToList();
        var width = input[0].Length;
        var height = input.Length;

        do
        {
            removed.Clear();

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    if (
                        inputChars[i][j] == '@'
                        && Neighbours(i, j)
                            .Sum(
                                (n) =>
                                    n.x >= 0
                                    && n.x < width
                                    && n.y >= 0
                                    && n.y < height
                                    && inputChars[n.x][n.y] == '@'
                                        ? 1
                                        : 0
                            ) < 4
                    )
                    {
                        removed.Add((i, j));
                    }
                }
            }

            sum += removed.Count;
            removed.ForEach(r => inputChars[r.x][r.y] = 'x');
        } while (removed.Count > 0);

        return sum.ToString();
    }
}
