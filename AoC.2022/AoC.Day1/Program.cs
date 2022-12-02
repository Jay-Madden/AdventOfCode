var ansPart1 = File.ReadAllText("input.txt")
    .Split($"{Environment.NewLine}{Environment.NewLine}")
    .Select(x => 
        x.Split(Environment.NewLine)
            .Select(int.Parse)
            .Sum())
    .Max();

Console.WriteLine($"Part 1: {ansPart1}");

var ansPart2 = File.ReadAllText("input.txt")
    .Split($"{Environment.NewLine}{Environment.NewLine}")
    .Select(x => 
        x.Split(Environment.NewLine)
            .Select(int.Parse)
            .Sum())
    .OrderDescending()
    .Take(3)
    .Sum();

Console.WriteLine($"Part 2: {ansPart2}");