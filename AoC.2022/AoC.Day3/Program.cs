// See https://aka.ms/new-console-template for more information

var ans1 = File.ReadAllLines("input.txt")
    .Select(x => new List<string>
        {x[..(x.Length / 2)], x[(x.Length / 2)..]})
    .Select(y => y[0].Intersect(y[1]).First())
    .Select(z => z > 'Z' ? z - 'a' + 1 : z - '&')
    .Sum();

Console.WriteLine($"Part 1: {ans1}");

var ans2 = File.ReadAllLines("input.txt")
    .Chunk(3)
    .Select(y => y[0].Intersect(y[1]).Intersect(y[2]).First())
    .Select(z => z > 'Z' ? z - 'a' + 1 : z - '&')
    .Sum();

Console.WriteLine($"Part 2: {ans2}");