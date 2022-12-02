public static class Program
{
    private static List<int> input;
    
    public static void Main()
    {
        input = File.ReadAllText("Day6.txt")
            .Split(",")
            .Select(int.Parse)
            .ToList();
        
        Part1();
        Part2();
    }

    public static void Part1()
    {
        var iterations = 256;

        var states = new List<int>(input);

        for (int i = 0; i < iterations; i++)
        {
            Console.WriteLine(i);
            
            for (int j = 0; j < states.Count; j++)
            {
                if (states[j] == 0)
                {
                    states[j] = 7;
                    states.Add(9);
                }
                
            }
            
            for (int j = 0; j < states.Count; j++)
            {
                states[j]--;
            }
        }

        //Console.WriteLine(string.Join(",", states));
        Console.WriteLine(states.Count);

    }

    public static void Part2()
    {
        var iterations = 256;

        var states = new List<int>(input);

        for (int i = 0; i < iterations; i++)
        {
            Console.WriteLine(i);
            
            for (int j = 0; j < states.Count; j++)
            {
                if (states[j] == 0)
                {
                    states[j] = 7;
                    states.Add(9);
                }
                
            }
            
            for (int j = 0; j < states.Count; j++)
            {
                states[j]--;
            }
        }

        //Console.WriteLine(string.Join(",", states));
        Console.WriteLine(states.Count);
        
    }
}
