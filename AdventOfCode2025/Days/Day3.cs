namespace AdventOfCode2025.Days;

public class Day3 : IDay
{
    // input = ["987654321111111", "811111111111119", ...]
    private static long Value(string bank, int position) => long.Parse(bank[position].ToString());

    public string Part1(string[] input)
    {
        var sum = 0L;

        foreach (var bank in input)
        {
            var (tensPos, digitPos) = (bank.Length - 2, bank.Length - 1);
            var (tens, digit) = (Value(bank, tensPos), Value(bank, digitPos));

            for (var t = tensPos; t >= 0; t--)
            {
                var tensValue = Value(bank, t);
                if (tensValue >= tens)
                {
                    tensPos = t;
                    tens = tensValue;
                }
            }
            for (var d = digitPos; d > tensPos; d--)
            {
                var divitValue = Value(bank, d);
                if (divitValue >= digit)
                {
                    digitPos = d;
                    digit = divitValue;
                }
            }

            sum += 10 * tens + digit;
        }

        return sum.ToString();
    }

    public string Part2(string[] input)
    {
        var sum = 0L;
        var numberOfBatteries = 12;

        foreach (var bank in input)
        {
            var positions = Enumerable
                .Range(bank.Length - numberOfBatteries, numberOfBatteries)
                .ToList();
            var values = positions.Select(x => Value(bank, x)).ToList();
            foreach (
                var (position, i) in positions.Select((value, index) => (value, index)).ToList()
            )
            {
                bool NextPositionConstralong(long p) => i == 0 ? p >= 0 : p > positions[i - 1];
                for (var p = position; NextPositionConstralong(p); p--)
                {
                    var checkedValue = Value(bank, p);
                    if (checkedValue >= values[i])
                    {
                        positions[i] = p;
                        values[i] = checkedValue;
                    }
                }
            }

            sum += values.Aggregate((x, y) => x * 10 + y);
        }

        return sum.ToString();
    }
}
