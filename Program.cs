using System.CommandLine;
using System.Linq;
using AdventOfCodeBase;
using AdventOfCode2022;

var yearOption = new Option<string>("--year", "Calendar Year");
var dayOption = new Option<string>("--day", "Day of Year");

var cmd = new RootCommand("Advent of Code");
cmd.AddOption(yearOption);
cmd.AddOption(dayOption);

cmd.SetHandler((year, day) => {
    Console.WriteLine($"Year: {year} Day: {day}");
    switch(year){
        case "2022":
            switch (day) {
                case "1":
                    new AdventOfCode2022.DayOne.Solution().Part01();
                    new AdventOfCode2022.DayOne.Solution().Part02();
                    break;
                case "2":
                    new AdventOfCode2022.DayTwo.Solution().Part01();
                    new AdventOfCode2022.DayTwo.Solution().Part02();
                    break;
                case "3":
                    new AdventOfCode2022.DayThree.Solution().Part01();
                    new AdventOfCode2022.DayThree.Solution().Part02();
                    break;
                default:
                    Console.WriteLine("Unknown Date");
                    break;
            }
            break;
        default:
            Console.WriteLine("Unknown Year");
        break;
    }
}, yearOption, dayOption);

await cmd.InvokeAsync(args);
