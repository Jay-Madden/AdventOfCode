// See https://aka.ms/new-console-template for more information

var ans1 = File.ReadAllLines("input.txt")
    .Select(x => x.Split(",").Select(
            y => new Range(y.Split("-").Select(int.Parse).ToList()[0], y.Split("-").Select(int.Parse).ToList()[1]))
        .OrderByDescending(a => a.GetOffsetAndLength(3999).Length))
    .Count(b => b.Skip(1).First().Start.Value >= b.First().Start.Value &&
                b.Skip(1).First().End.Value <= b.First().End.Value);

Console.WriteLine($"Part 1: {ans1}");

var ans2 = File.ReadAllLines("input.txt")
    .Select(x => x.Split(",").Select(
            y => new Range(y.Split("-").Select(int.Parse).ToList()[0], y.Split("-").Select(int.Parse).ToList()[1]))
        .OrderBy(a => a.GetOffsetAndLength(3999).Offset))
    .Where(b => b.Skip(1).First().Start.Value <= b.First().End.Value)
    .Count();


Console.WriteLine($"Part 2: {ans2}");