using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace AoC.Day4;

public static class Program
{
    public static void Main()
    {
        Part1();
        Part2();
    }

    public class Tile
    {
        public int value { get; init; }
        public bool marked { get; set; }
    }

    public class BoardWin
    {
        public List<List<Tile>> board { get; }
        public bool won { get; set; }

        public BoardWin(List<List<Tile>> board, bool won)
        {
            this.board = board;
            this.won = won;
        }
    }

    public static void Part1()
    {
        var input = File.ReadAllLines("Day4.txt");

        var chosen = input[0].Split(",").Select(int.Parse).ToArray();

        input = input[2..].Where(x => x != String.Empty).ToArray();

        var boards = input.Select((x, i) => new {Index = i, Value = x})
            .GroupBy(x => x.Index / 5)
            .Select(x =>
                x.Select(v =>
                        v.Value.Split(' ')
                            .Where(z => z != "")
                            .Select(y => new Tile {value = int.Parse(y.ToString()), marked = false})
                            .ToList())
                    .ToList())
            .Select(y => new BoardWin(y, false))
            .ToList();

        foreach (var num in chosen)
        {
            for (var index = 0; index < boards.Count; index++)
            {
                if (boards[index].won)
                {
                    continue;
                }

                for (var ii = 0; ii < boards[index].board.Count; ii++)
                {
                    for (var k = 0; k < boards[index].board[ii].Count; k++)
                    {
                        if (boards[index].board[ii][k].value == num)
                        {
                            boards[index].board[ii][k].marked = true;
                        }
                    }
                }

                var didWin = false;
                var set = boards[index].board.Select(x => x.Select(y => y.marked ? 1 : 0).ToList()).ToList();

                foreach (var s in set)
                {
                    if (s.Sum() == 5)
                    {
                        didWin = true;
                        break;
                    }
                }

                for (int j = 0; j < set.Count; j++)
                {
                    if (set.Select(x => x[j]).Sum() == 5)
                    {
                        didWin = true;
                        break;
                    }
                }

                if (boards.Count(x => x.won == false) == 1 && didWin)
                {
                    var sum = 0;
                    var finalBoard = boards.FirstOrDefault(x => x.won == false);
                    for (var ii = 0; ii < finalBoard.board.Count; ii++)
                    {
                        for (var k = 0; k < finalBoard.board[ii].Count; k++)
                        {
                            if (!finalBoard.board[ii][k].marked)
                            {
                                sum += finalBoard.board[ii][k].value;
                            }
                        }
                    }

                    Console.WriteLine(sum * num);
                    return;
                }

                if (didWin)
                {
                    boards[index].won = true;
                }
            }
        }
    }

    public static void Part2()
    {
    }
}