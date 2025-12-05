namespace AdventOfCode2025.Days;

public class Day5 : IDay
{
    // input = ["3-5", ..., "", "1", ...]

    public string Part1(string[] input)
    {
        var count = 0;
        var ranges = new List<(long start, long end)>();
        var inRanges = true;
        foreach (var (line, i) in input.Select((x, i) => (x, i)))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                inRanges = false;
                continue;
            }

            if (inRanges)
            {
                var parts = line.Split('-');
                var start = long.Parse(parts[0]);
                var end = long.Parse(parts[1]);
                ranges.Add((start, end));
            }
            else
            {
                var number = long.Parse(line);
                if (ranges.Any(r => number >= r.start && number <= r.end))
                {
                    count++;
                }
            }
        }

        return count.ToString();
    }

    public string Part2(string[] input)
    {
        var ranges = new List<(long start, long end)>();
        foreach (
            var (line, i) in input.TakeWhile(x => !string.IsNullOrEmpty(x)).Select((x, i) => (x, i))
        )
        {
            var parts = line.Split('-');
            var start = long.Parse(parts[0]);
            var end = long.Parse(parts[1]);
            var overlappingRanges = ranges.Where(r => !(end < r.start || start > r.end)).ToList();
            if (overlappingRanges.Count != 0)
            {
                ranges.RemoveAll(overlappingRanges.Contains);
                var newStart = Math.Min(start, overlappingRanges.Min(r => r.start));
                var newEnd = Math.Max(end, overlappingRanges.Max(r => r.end));
                ranges.Add((newStart, newEnd));
            }
            else
            {
                ranges.Add((start, end));
            }
        }

        return ranges.Sum(x => 1 + x.end - x.start).ToString();
    }
}
