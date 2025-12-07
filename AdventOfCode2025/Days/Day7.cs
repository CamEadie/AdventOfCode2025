namespace AdventOfCode2025.Days;

public class Day7 : IDay
{
    // input = [".......S.......", "...............", ...]

    public string Part1(string[] input)
    {
        var sum = 0;
        var rays = new HashSet<int> { input[0].IndexOf('S') };
        foreach (var line in input)
        {
            foreach (var ray in rays.ToArray())
            {
                if (line[ray] == '^')
                {
                    sum++;
                    rays.Remove(ray);
                    rays.Add(ray - 1);
                    rays.Add(ray + 1);
                }
            }
        }

        return sum.ToString();
    }

    public string Part2(string[] input)
    {
        var rays = new HashSet<int> { input[0].IndexOf('S') };
        var paths = input[0].Select(x => x == 'S' ? 1L : 0L).ToArray();
        foreach (var line in input)
        {
            var newPaths = paths.ToArray();
            foreach (var ray in rays.ToArray())
            {
                if (line[ray] == '^')
                {
                    rays.Remove(ray);
                    rays.Add(ray - 1);
                    rays.Add(ray + 1);

                    newPaths[ray] -= paths[ray];
                    newPaths[ray - 1] += paths[ray];
                    newPaths[ray + 1] += paths[ray];
                }
            }
            paths = [.. newPaths];
        }

        return paths.Sum().ToString();
    }
}
