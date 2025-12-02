namespace AdventOfCode2025.Days;

public class Day1 : IDay
{
    // input = ["L68", "L30", ...]

    const int Order = 100;
    const int Start = Order / 2;

    private static int LineToRotation(string line) =>
        int.Parse(line.Replace("R", string.Empty).Replace("L", "-"));

    private static (int, int) DivMod(int num, int denom) => (num / denom, num % denom);

    public string Part1(string[] input)
    {
        var dial = Start;
        var zeros = 0;

        foreach (var line in input)
        {
            var rotation = LineToRotation(line);
            (_, dial) = DivMod(dial + rotation, 100);
            if (dial == 0)
            {
                zeros++;
            }
        }

        return zeros.ToString(); // E: 3, A: 1081
    }

    public string Part2(string[] input)
    {
        var dial = Start;
        var zeros = 0;

        foreach (var line in input)
        {
            var rotation = LineToRotation(line);
            var (div, mod) = DivMod(dial + rotation, Order);

            var zeroPasses = Math.Abs(div);
            var hitZero = mod == 0 && div <= 0;
            var crossedBelowZero = mod < 0 && dial != 0;

            zeros += zeroPasses + (hitZero || crossedBelowZero ? 1 : 0);
            dial = (mod + Order) % Order;
        }

        return zeros.ToString(); // E: 6, A: 6689
    }
}
