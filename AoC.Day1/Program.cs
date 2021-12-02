namespace AoC.Day1;

public class Program
{
    public static void Main(string[] args)
    {
        var nums = File.ReadAllLines("Day1.txt").Select(int.Parse).ToArray();

        var count = 0;

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] < nums[i])
            {
                count++;
            } 
        }
        Console.WriteLine(count);

        
        // Part 2
        
        count = 0;
        var prev = 1000;

        for (var i = 1; i < nums.Length-1; i++)
        {
            var sum = nums[(i - 1)..(i + 2)].Sum();
            if (sum > prev)
            {
                count++;
            }
            prev = sum;
        }
        Console.WriteLine(count);
        
        
    }
}