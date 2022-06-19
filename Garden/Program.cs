using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split();

        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[,] matrix = new int[n, m];

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                matrix[row, col] = 0;
            }
        }

        string command;

        while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
        {
            var cmdArgs = command.Split();

            int currRow = int.Parse(cmdArgs[0]);
            int currCol = int.Parse(cmdArgs[1]);

            if (!IsCoordinatesValid(currRow, currCol, matrix))
            {
                Console.WriteLine("Invalid coordinates.");
                continue;
            }
            else
            {
                matrix[currRow, currCol] = -1;
            }
        }

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                if (matrix[row, col] == -1)
                {
                    int currRow = row;
                    int currCol = col;

                    matrix[row, col] = 1;

                    while (row < n-1)
                    {
                        matrix[row + 1, col] += 1;
                        row++;                 
                    }
                    row = currRow;
                    while (row > 0)
                    {
                        matrix[row - 1, col] += 1;
                        row--;
                    }
                    row = currRow;
                    while (col < n-1)
                    {
                        matrix[row, col + 1] += 1;
                        col++;
                    }
                    col = currCol;
                    while (col > 0)
                    {
                        matrix[row, col - 1] += 1;
                        col--;
                    }
                    row = 0;
                    col = 0;
                    break;
                }   
            }
        }

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    private static bool IsCoordinatesValid(int currRow, int currCol, int[,] matrìx)
    {
        return currRow >= 0 && currRow < matrìx.GetLength(0) && currCol >= 0 && currCol < matrìx.GetLength(1);
    }
}