namespace AdventOfCode2025.Days.Parsing;

public static class DayParser
{
    private static readonly Dictionary<int, IDay> _days = new()
    {
        { 1, new Day1() },
        { 2, new Day2() },
        { 3, new Day3() },
        { 4, new Day4() },
        { 5, new Day5() },
        { 6, new Day6() },
        { 7, new Day7() },
        { 8, new Day8() },
        { 9, new Day9() },
        { 10, new Day10() },
        { 11, new Day11() },
        { 12, new Day12() },
    };

    public static void ParseDay(int dayNumber, bool showAll)
    {
        if (showAll)
        {
            foreach (var number in _days.Keys)
            {
                ParseDay(number);
            }
        }
        else
        {
            ParseDay(dayNumber);
        }
    }

    private static void ParseDay(int dayNumber)
    {
        Console.WriteLine($"\n--- Day {dayNumber} ---\n");
        if (!_days.TryGetValue(dayNumber, out var day))
        {
            Console.WriteLine($"Day {dayNumber} has not been implemented");
            return;
        }

        var part = string.Empty;
        try
        {
            var exampleInput = File.ReadAllLines($"./Inputs/day_{dayNumber}_example.txt");

            part = "Part 1 Example";
            Console.WriteLine($"{part}: {day.Part1(exampleInput)}");

            part = "Part 2 Example";
            Console.WriteLine($"{part}: {day.Part2(exampleInput)}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Example input is missing");
        }
        catch (Exception e)
        {
            Console.WriteLine($"{part}: Exception: {e.Message}");
        }

        try
        {
            var input = File.ReadAllLines($"./Inputs/day_{dayNumber}_input.txt");
            part = "Part 1";
            Console.WriteLine($"{part}: {day.Part1(input)}");
            part = "Part 2";
            Console.WriteLine($"{part}: {day.Part2(input)}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Actual input is missing");
        }
        catch (Exception e)
        {
            Console.WriteLine($"{part}: Exception: {e.Message}");
        }
    }
}
