using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int matrixSize = int.Parse(Console.ReadLine());

        string[,] matrix = new string[matrixSize, matrixSize];
        var coordinates = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

        for (int row = 0; row < matrixSize; row++)
        {
            string[] colElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int col = 0; col < matrixSize; col++)
            {
                matrix[row, col] = colElements[col];
            }
        }

        int leftShipsPlayerOne = CheckLeftShips(matrix, matrixSize, "<");
        int leftShipsPlayerTwo = CheckLeftShips(matrix, matrixSize, ">");

        int sunkShips = 0;

        for (int i = 0; i < coordinates.Length; i++)
        {
            int[] currCoordinates = coordinates[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int currRow = currCoordinates[0];
            int currCol = currCoordinates[1];

            
            if (currRow < 0 || currRow > matrixSize || currCol < 0 || currCol > matrixSize)
            {
                continue;
            }

            
            if (matrix[currRow, currCol] == "#")
            {
                matrix[currRow, currCol] = "X";
                matrix = CrawlTheMine(matrixSize, matrix, ref currRow, ref currCol, ref sunkShips, ref leftShipsPlayerOne, ref leftShipsPlayerTwo);
            }
            else if (matrix[currRow, currCol] == "<")
            {
                matrix[currRow, currCol] = "X";
                leftShipsPlayerOne--;
                sunkShips++;
            }
            else if (matrix[currRow, currCol] == ">")
            {
                matrix[currRow, currCol] = "X";
                leftShipsPlayerTwo--;
                sunkShips++;
            }
            else if (matrix[currRow, currCol] == "*")
            {
                continue;
            }
            if (!IsPlayersShipAlive(matrix, matrixSize, ">"))
            {
                Console.WriteLine($"Player One has won the game! {sunkShips} ships have been sunk in the battle.");
                return;
            }
            if (!IsPlayersShipAlive(matrix, matrixSize, "<"))
            {
                Console.WriteLine($"Player Two has won the game! {sunkShips} ships have been sunk in the battle.");
                return;
            }
            
        }

        Console.WriteLine($"It's a draw! Player One has {leftShipsPlayerOne} ships left. Player Two has {leftShipsPlayerTwo} ships left.");
    }

    private static int CheckLeftShips(string[,] matrix, int matrixSize, string shipSign)
    {
        int shipsLeft = 0;

        for (int row = 0; row < matrixSize; row++)
        {
            for (int col = 0; col < matrixSize; col++)
            {
                if (matrix[row, col] == shipSign)
                {
                    shipsLeft++;
                }
            }
        }
        return shipsLeft;
    }

    private static string[,] CrawlTheMine(int matrixSize, string[,] matrix, ref int currRow, ref int currCol, ref int sunkShips, ref int leftShipsPlayerOne, ref int leftShipsPlayerTwo)
    {
        if (currRow - 1 >= 0)
        {
            sunkShips = IncreaseSunkShips(matrix, currRow - 1, currCol, ref sunkShips, ref leftShipsPlayerOne, ref leftShipsPlayerTwo);
            matrix[currRow - 1, currCol] = "X";
        }
        if (currRow + 1 < matrixSize)
        {
            sunkShips = IncreaseSunkShips(matrix, currRow + 1, currCol, ref sunkShips, ref leftShipsPlayerOne, ref leftShipsPlayerTwo);
            matrix[currRow + 1, currCol] = "X";
        }
        if (currRow - 1 >= 0 && currCol - 1 >= 0)
        {
            sunkShips = IncreaseSunkShips(matrix, currRow - 1, currCol - 1, ref sunkShips, ref leftShipsPlayerOne, ref leftShipsPlayerTwo);
            matrix[currRow - 1, currCol - 1] = "X";
        }
        if (currRow - 1 >= 0 && currCol + 1 < matrixSize)
        {
            sunkShips = IncreaseSunkShips(matrix, currRow - 1, currCol + 1, ref sunkShips, ref leftShipsPlayerOne, ref leftShipsPlayerTwo);
            matrix[currRow - 1, currCol + 1] = "X";
        }
        if (currRow + 1 < matrixSize && currCol - 1 >= 0)
        {
            sunkShips = IncreaseSunkShips(matrix, currRow + 1, currCol - 1, ref sunkShips, ref leftShipsPlayerOne, ref leftShipsPlayerTwo);
            matrix[currRow + 1, currCol - 1] = "X";
        }
        if (currRow + 1 < matrixSize && currCol + 1 < matrixSize)
        {
            sunkShips = IncreaseSunkShips(matrix, currRow + 1, currCol + 1, ref sunkShips, ref leftShipsPlayerOne, ref leftShipsPlayerTwo);
            matrix[currRow + 1, currCol + 1] = "X";
        }
        if (currCol - 1 >= 0)
        {
            sunkShips = IncreaseSunkShips(matrix, currRow, currCol - 1, ref sunkShips, ref leftShipsPlayerOne, ref leftShipsPlayerTwo);
            matrix[currRow, currCol - 1] = "X";
        }
        if (currCol + 1 < matrixSize)
        {
            sunkShips = IncreaseSunkShips(matrix, currRow, currCol + 1, ref sunkShips, ref leftShipsPlayerOne, ref leftShipsPlayerTwo);
            matrix[currRow, currCol + 1] = "X";
        }
        return matrix;
    }

    private static int IncreaseSunkShips(string[,] matrix, int currRow, int currCol, ref int sunkShips, ref int leftShipsPlayerOne, ref int leftShipsPlayerTwo)
    {
        if (matrix[currRow, currCol] == ">")
        {
            sunkShips++;
            leftShipsPlayerTwo--;
        }
        else if (matrix[currRow, currCol] == "<")
        {
            sunkShips++;
            leftShipsPlayerOne--;
        }
        return sunkShips;
    }

    private static bool IsPlayersShipAlive(string[,] matrix, int matrixSize, string shipSign)
    {
        for (int row = 0; row < matrixSize; row++)
        {
            for (int col = 0; col < matrixSize; col++)
            {
                if (matrix[row, col] == shipSign)
                {
                    return true;
                }
            }
        }
        return false;
    }
}