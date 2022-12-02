public static class Program
{
    public static void Main()
    {
        Part1();
    }

    public static void Part1()
    {
        var lines = File.ReadAllLines("Day5.txt")
            .Select(x =>
                x.Split("->")
                    .Select(y =>
                        (x: int.Parse(y.Split(",")[0]),y: int.Parse(y.Split(",")[1])))
                    .ToArray())
            .ToArray();

        var size = 1000;
        var floor = new int[size, size];

        foreach (var line in lines)
        {
            // It is a vertical line
            if (line[0].x == line[1].x)
            {
                if (line[0].y < line[1].y)
                {
                    for (var i = line[0].y; i <= line[1].y; i++)
                    {
                        floor[line[0].x, i]++;
                    }
                }
                if (line[0].y > line[1].y)
                {
                    for (var i = line[1].y; i <= line[0].y; i++)
                    {
                        floor[line[1].x, i]++;
                    }
                }
            }
            // It is a horizontal line
            else if (line[0].y == line[1].y)
            {
                if (line[0].x < line[1].x)
                {
                    for (var i = line[0].x; i <= line[1].x; i++)
                    {
                        floor[i, line[0].y]++;
                    }
                }

                if (line[0].x > line[1].x)
                {
                    for (var i = line[1].x; i <= line[0].x; i++)
                    {
                        floor[i, line[0].y]++;
                    }
                }
            }
            // Diagonal line doign down and right
            else if (line[0].x < line[1].x && line[0].y < line[1].y)
            {
                var j = line[0].y;
                for (var i = line[0].x; i <= line[1].x; i++, j++)
                {
                    if (j > size) break;
                    floor[i, j]++;
                }
            }
            
            // Diagonal line going down and left 
            else if (line[0].x < line[1].x && line[0].y > line[1].y)
            {
                var j = line[0].y;
                for (var i = line[0].x; i <= line[1].x; i++, j--)
                {
                    if (j < 0) break;
                    floor[i, j]++;
                }
            }
            
            // Diagonal line going up and right
            else if (line[0].x > line[1].x && line[0].y < line[1].y)
            {
                var j = line[0].y;
                for (var i = line[0].x; i >= line[1].x; i--, j++)
                {
                    if (j > size) break;
                    floor[i, j]++;
                }
            }
            
            // Diagonal line going up and left 
            else if (line[0].x > line[1].x && line[0].y > line[1].y)
            {
                var j = line[0].y;
                for (var i = line[0].x; i >= line[1].x; i--, j--)
                {
                    if (j < 0) break;
                    floor[i, j]++;
                }
            }
        }
        
        floor.Print2DArray();
        
        var count = 0;
        for (var i = 0; i < floor.GetLength(0); i++)
        {
            for (var j = 0; j < floor.GetLength(1); j++)
            {
                if (floor[i, j] > 1)
                {
                    count++;
                }
            }
        }
        Console.WriteLine(count);
    }

    public static int GetDist((int, int) one, (int, int) two)
        => (int)Math.Sqrt(Math.Pow(two.Item1 - one.Item1, 2) + Math.Pow(two.Item2 - one.Item2, 2));
    
    public static void Print2DArray<T>(this T[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j] + " ");
            }
            Console.WriteLine();
        }
    }
}
