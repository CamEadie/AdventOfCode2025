namespace AdventOfCode2025.Days;

public class Day2 : IDay
{
    // input = ["11-22,95-115,998-1012,..."]

    public string Part1(string[] input)
    {
        var sum = 0L;
        var ranges = input[0].Split(",").Select(x => x.Split("-"));
        foreach (var range in ranges)
        {
            for (var value = long.Parse(range[0]); value <= long.Parse(range[1]); value++)
            {
                var stringValue = value.ToString();
                var halfLength = stringValue.Length / 2;
                if (
                    stringValue.Length % 2 == 0
                    && stringValue[..halfLength] == stringValue[halfLength..]
                )
                {
                    sum += value;
                }
            }
        }

        return sum.ToString();
    }

    public string Part2(string[] input)
    {
        var sum = 0L;
        var ranges = input[0].Split(",").Select(x => x.Split("-")).ToList();
        foreach (var range in ranges)
        {
            for (var value = long.Parse(range[0]); value <= long.Parse(range[1]); value++)
            {
                var stringValue = value.ToString();
                for (var chunkSize = 1; chunkSize <= stringValue.Length / 2; chunkSize++)
                {
                    if (stringValue.Length % chunkSize != 0)
                    {
                        continue;
                    }

                    var chunks = stringValue.Chunk(chunkSize).Select(x => new string(x)).ToList();
                    if (chunks.Count > 1 && chunks.All(x => x == chunks[0]))
                    {
                        sum += value;
                        break;
                    }
                }
            }
        }

        return sum.ToString();
    }
}
