﻿
public class Program
{
    private static int[][] input;
    public static void Main()
    {
        
    }
        
    public static void Part1()
    {
        int[][] nums = File.ReadAllLines("Day3.txt")
            .Select(x => 
                x.Select(y => 
                        int.Parse(y.ToString()))
                    .ToArray())
            .ToArray();

        var gammaStr = "";
        for (var i = 0; i < input[0].Length; i++)
        {
            var count = input.Select(x => x[i]).Sum();
            gammaStr += count > input.Length - count ? "1" : "0";
        }

        var gamma = Convert.ToInt32(gammaStr, 2);
        
        var epsilonStr = "";
        for (var i = 0; i < input[0].Length; i++)
        {
            var count = input.Select(x => x[i]).Sum();
            epsilonStr += count < input.Length - count ? "1" : "0";
        }

        var epsilon = Convert.ToInt32(epsilonStr, 2);
        
        Console.WriteLine(gamma * epsilon);

    }

    public static void Part2()
    {
        int[][] nums = File.ReadAllLines("Day3.txt")
            .Select(x => 
                x.Select(y => 
                        int.Parse(y.ToString()))
                    .ToArray())
            .ToArray();

        for (var i = 0; i < input[0].Length; i++)
        {
            var count = nums.Select(x => x[i]).Sum();
            nums = nums
                .Where(x => x[i] == (count >= nums.Length - count ? 1 : 0))
                .ToArray();
        }

        var oxygen = Convert.ToInt32(string.Join("", nums[0]), 2);
        
        nums = input;
        for (var i = 0; i < input[0].Length; i++)
        {
            var count = nums.Select(x => x[i]).Sum();
            nums = nums
                .Where(x => x[i] == (count >= nums.Length - count ? 0 : 1))
                .ToArray();

            if (nums.Length == 1)
                break;
        }
        
        var carbon = Convert.ToInt32(string.Join("", nums[0]), 2);

        Console.WriteLine(oxygen*carbon);
    }
}

