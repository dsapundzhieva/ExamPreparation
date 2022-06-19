using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        char[,] matrix = new char[n, n];

        for (int row = 0; row < n; row++)
        {
            char[] colElements = Console.ReadLine().ToCharArray();

            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = colElements[col];
            }
        }

        int foodEaten = 0;

        int[] startPositionRow = FindStartPosition(matrix, n);
        int currRow = startPositionRow[0];
        int currCol = startPositionRow[1];

        while (true)
        {
            string command = Console.ReadLine();

            matrix[currRow, currCol] = '.';

            if (command == "up")
            {
                if (currRow - 1 >= 0)
                {
                    currRow = currRow - 1;  
                    matrix = CrawlТheMatrix(n, matrix, ref foodEaten, ref currRow, ref currCol);
                }
                else
                {
                    PrintGameOver(foodEaten);
                    break;
                }
            }
            if (command == "down")
            {
                if (currRow + 1 < n)
                {
                    currRow = currRow + 1;
                    matrix = CrawlТheMatrix(n, matrix, ref foodEaten, ref currRow, ref currCol);
                }
                else
                {
                    PrintGameOver(foodEaten);
                    break;
                }
            }
            if (command == "left")
            {
                if (currCol - 1 >= 0)
                {
                    currCol = currCol - 1;
                    matrix = CrawlТheMatrix(n, matrix, ref foodEaten, ref currRow, ref currCol);
                }
                else
                {
                    PrintGameOver(foodEaten);
                    break;
                }
            }
            if (command == "right")
            {
                if (currCol + 1 < n)
                {
                    currCol = currCol + 1;
                    matrix = CrawlТheMatrix(n, matrix, ref foodEaten, ref currRow, ref currCol);
                }
                else
                {
                    PrintGameOver(foodEaten);
                    break;
                }
            }
            if (foodEaten >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
                Console.WriteLine($"Food eaten: {foodEaten}");
                break;
            }
        }
        PrintMatrix(matrix, n);
    }

    private static void PrintMatrix(char[,] matrix, int n)
    {
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }

    private static void PrintGameOver(int foodEaten)
    {
        Console.WriteLine("Game over!");
        Console.WriteLine($"Food eaten: {foodEaten}");
    }

    private static char[,] CrawlТheMatrix(int n, char[,] matrix, ref int foodEaten, ref int currRow, ref int currCol)
    {
        if (matrix[currRow, currCol] == '-')
        {
            matrix[currRow, currCol] = 'S';
        }
        else if (matrix[currRow, currCol] == 'B')
        {
            int[] burrowPosition = FindBurrowPosition(matrix, n, currRow, currCol);
            matrix[currRow, currCol] = '.';
            matrix[burrowPosition[0], burrowPosition[1]] = 'S';
            currRow = burrowPosition[0];
            currCol = burrowPosition[1];
        }
        else if (matrix[currRow, currCol] == '*')
        {
            matrix[currRow, currCol] = 'S';

            foodEaten++;
        }
        return matrix;
    }

    private static int[] FindBurrowPosition(char[,] matrix, int n, int currRow, int currCol)
    {
        int[] burrowPositon = new int[2];

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (matrix[row, col] == 'B')
                {
                    burrowPositon[0] = row;
                    burrowPositon[1] = col;
                }
            }
        }
        return burrowPositon;
    }
    private static int[] FindStartPosition(char[,] matrix, int n)
    {
        int[] startPositon = new int[2];

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (matrix[row, col] == 'S')
                {
                    startPositon[0] = row;
                    startPositon[1] = col;
                }
            }
        }
        return startPositon;
    }
}