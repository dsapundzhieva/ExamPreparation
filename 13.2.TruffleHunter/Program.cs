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
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[] colEl = string.Join("", input).ToCharArray();

            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = colEl[col];
            }
        }

        string command;

        int whiteTruffels = 0;
        int summerTruffels = 0;
        int blackTruffels = 0;

        int eatenTruffels = 0;

        while ((command = Console.ReadLine()) != "Stop the hunt")
        {
            var cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string action = cmdArgs[0];
            int row = int.Parse(cmdArgs[1]);
            int col = int.Parse(cmdArgs[2]);

            if (action == "Collect")
            {
                if (matrix[row, col] == 'B')
                {
                    blackTruffels++;
                }
                else if (matrix[row, col] == 'S')
                {
                    summerTruffels++;
                }
                else if (matrix[row, col] == 'W')
                {
                    whiteTruffels++;
                }
                matrix[row, col] = '-';
            }
            if (action == "Wild_Boar")
            {
                string direction = cmdArgs[3];

                if (direction == "up")
                {
                    while (row >= 0)
                    {
                        if (matrix[row, col] == 'B' || matrix[row, col] == 'W' || matrix[row, col] == 'S')
                        {
                            eatenTruffels++;
                            matrix[row, col] = '-';
                        }
                        row -= 2;
                    }
                }
                else if (direction == "down")
                {
                    while (row < n)
                    {
                        if (matrix[row, col] == 'B' || matrix[row, col] == 'W' || matrix[row, col] == 'S')
                        {
                            eatenTruffels++;
                            matrix[row, col] = '-';
                        }
                        row += 2;
                    }
                }
                else if (direction == "left")
                {
                    while (col >= 0)
                    {
                        if (matrix[row, col] == 'B' || matrix[row, col] == 'W' || matrix[row, col] == 'S')
                        {
                            eatenTruffels++;
                            matrix[row, col] = '-';
                        }
                        col -= 2;
                    }
                }
                else if (direction == "right")
                {
                    while (col < n)
                    {
                        if (matrix[row, col] == 'B' || matrix[row, col] == 'W' || matrix[row, col] == 'S')
                        {
                            eatenTruffels++;
                            matrix[row, col] = '-';
                        }
                        col += 2;
                    }
                }
            }
        }

        Console.WriteLine($"Peter manages to harvest {blackTruffels} black, {summerTruffels} summer, and {whiteTruffels} white truffles.");
        Console.WriteLine($"The wild boar has eaten {eatenTruffels} truffles.");

        PrintMatrix(matrix);
    }

    private static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row,col] + " ");
            }
            Console.WriteLine();
        }
    }
}