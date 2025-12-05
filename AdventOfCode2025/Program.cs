using System.CommandLine;
using AdventOfCode2025.Days.Parsing;

var dayOption = new Option<int>("--day")
{
    Description = "The day of Advent of Code 2025 to run.",
    DefaultValueFactory = _ => 5,
};

var allOption = new Option<bool>("--all")
{
    Description = "Show all of the days.",
    DefaultValueFactory = _ => false,
};

var rootCommand = new RootCommand("Advent of Code 2025") { dayOption, allOption };

rootCommand.SetAction(parseResult =>
{
    DayParser.ParseDay(parseResult.GetValue(dayOption), parseResult.GetValue(allOption));
});

return rootCommand.Parse(args).Invoke();
