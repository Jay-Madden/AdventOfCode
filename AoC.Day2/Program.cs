using System.Runtime.CompilerServices;

namespace AoC.Day2;

public static class Program
{
    public static void Main()
    {
        var input = File.ReadAllLines("Day2.txt")
        .Select(x => x.Split(" "))
        .Select(y => new {command=y[0],value=int.Parse(y[1])})
        .ToList();

        var depth = 0;
        var horizontal = 0;

        foreach (var com in input)
        {
            if (com.command == "forward")
            {
                horizontal += com.value;
            }
            if (com.command == "up")
            {
                depth -= com.value;
            }
            if (com.command == "down")
            {
                depth += com.value;
            }
        }
    
        Console.WriteLine($"Value: {depth * horizontal}");
        
        input = File.ReadAllLines("Day2.txt")
            .Select(x => x.Split(" "))
            .Select(y => new {command=y[0],value=int.Parse(y[1])})
            .ToList();

        depth = 0;
        horizontal = 0;
        var aim = 0;

        foreach (var com in input)
        {
            if (com.command == "forward")
            {
                horizontal += com.value;
                depth += aim * com.value;
            }
            if (com.command == "up")
            {
                aim -= com.value;
            }
            if (com.command == "down")
            {
                aim += com.value;
            }
        }
    
        Console.WriteLine($"Value: {depth * horizontal}");
    }
}