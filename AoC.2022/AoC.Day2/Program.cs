var input = File.ReadAllLines("input.txt").Select(x => x.Split()).Select(y
        => (y[1].ToCharArray().First() - 87, y[0].ToCharArray().First() - 64 - (y[1].ToCharArray().First() - 87)))
    .Select(z => z.Item1 + new Dictionary<int, int>
    {
        {-2, 0},
        {-1, 6},
        {0, 3},
        {1, 0},
        {2, 6}
    }[z.Item2])
    .Sum();

Console.WriteLine($"Part 1: {input}");

var input2 = File.ReadAllLines("input.txt").Select(x => x.Split()).Select(y
        => (y[0].ToCharArray().First() - 64, y[1].ToCharArray().First() - 87))
    .Select(z => z.Item2 * 3 - 3 + ((z.Item2 - 2 + z.Item1 - 1) % 3 + 3) % 3 + 1)
    .Sum();
Console.WriteLine($"Part 2: {input2}");Console.WriteLine($"Part 2: {input2}");