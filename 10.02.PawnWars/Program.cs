using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main()
    {
        var cols = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h" };

        List<List<string>> board = new List<List<string>>();

        cols.ForEach((col) =>
        {
            var row = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();
            board.Add(row);
        });

        var isWhiteTurn = true;
        while (true)
        {

            if (isWhiteTurn)
            {
                var rowIndex = board.FindIndex(x => x.Contains("w"));
                if (rowIndex == 0)
                {
                    var index = board[rowIndex].FindIndex(x => x.ToLower() == "w");
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {cols[index]}8.");
                    return;
                }

                var colIndex = board[rowIndex].FindIndex(x => x.ToLower() == "w");
                if (colIndex - 1 >= 0 && board[rowIndex - 1][colIndex - 1] == "b")
                {
                    Console.WriteLine($"Game over! White capture on {cols[colIndex - 1]}{8 - (rowIndex - 1)}.");
                    return;
                }

                if (colIndex + 1 < 8 && board[rowIndex - 1][colIndex + 1] == "b")
                {
                    Console.WriteLine($"Game over! White capture on {cols[colIndex + 1]}{8 - (rowIndex - 1)}.");
                    return;
                }

                board[rowIndex - 1][colIndex] = "w";
                board[rowIndex][colIndex] = "-";
            }
            else
            {
                var rowIndex = board.FindIndex(x => x.Contains("b"));
                if (rowIndex == 7)
                {
                    var index = board[rowIndex].FindIndex(x => x.ToLower() == "b");
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {cols[index]}1.");
                    return;
                }

                var colIndex = board[rowIndex].FindIndex(x => x.ToLower() == "b");
                if (colIndex - 1 >= 0 && board[rowIndex + 1][colIndex - 1] == "w")
                {
                    Console.WriteLine($"Game over! Black capture on {cols[colIndex - 1]}{8 - (rowIndex + 1)}.");
                    return;
                }

                if (colIndex + 1 < 8 && board[rowIndex + 1][colIndex + 1] == "w")
                {
                    Console.WriteLine($"Game over! White capture on {cols[colIndex + 1]}{8 - (rowIndex + 1)}.");
                    return;
                }
                board[rowIndex + 1][colIndex] = "b";
                board[rowIndex][colIndex] = "-";
            }
            isWhiteTurn = !isWhiteTurn;
        }
    }
}