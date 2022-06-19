using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    public static char[,] matrix;
    public static bool isFinalReached = false;

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int countCommands = int.Parse(Console.ReadLine());

        char[,] matrix = new char[n, n];

        for (int row = 0; row < n; row++)
        {
            char[] colElements = Console.ReadLine().ToCharArray();

            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = colElements[col];
            }
        }

        int[] startPosition = FindStartPosition(matrix);
        int currRow = startPosition[0];
        int currCol = startPosition[1];

        for (int i = 0; i < countCommands; i++)
        {
            string command = Console.ReadLine();

            matrix[currRow, currCol] = '-';

            if (command == "up")
            {
                currRow = currRow - 1;
                if (IsValid(currRow, currCol, matrix))
                {
                    Move(ref currRow, ref currCol, "up", matrix);
                }
                else
                {
                    currRow = n - 1;
                    Move(ref currRow, ref currCol, "up", matrix);
                }
                matrix[currRow, currCol] = 'f';
            }
            else if (command == "down")
            {
                currRow = currRow + 1;
                if (IsValid(currRow, currCol, matrix))
                {
                    Move(ref currRow, ref currCol, "down", matrix);
                }
                else
                {
                    currRow = 0;
                    Move(ref currRow, ref currCol, "down", matrix);
                }
                matrix[currRow, currCol] = 'f';
            }
            else if (command == "left")
            {
                currCol = currCol - 1;
                if (IsValid(currRow, currCol, matrix))
                {
                    Move(ref currRow, ref currCol, "left", matrix);
                }
                else
                {
                    currCol = n - 1;
                    Move(ref currRow, ref currCol, "left", matrix);
                }
                matrix[currRow, currCol] = 'f';
            }
            else if (command == "right")
            {
                currCol = currCol + 1;
                if (IsValid(currRow, currCol, matrix))
                {
                    Move(ref currRow, ref currCol, "right", matrix);
                }
                else
                {
                    currCol = 0;
                    Move(ref currRow, ref currCol, "right", matrix);
                }
                matrix[currRow, currCol] = 'f';
            }

            if (isFinalReached)
            {
                break;
            }
        }

        if (isFinalReached)
        {
            Console.WriteLine("Player won!");
        }
        else
        {
            Console.WriteLine("Player lost!");
        }

        PrintMatrix(matrix);
    }

    private static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }

    private static void Move(ref int currRow, ref int currCol, string direction, char[,] matrix)
    {
        if (matrix[currRow, currCol] == 'B')
        {
            if (direction == "up")
            {
                currRow = currRow - 1;
                if (!IsValid(currRow, currCol, matrix))
                {
                    currRow = matrix.GetLength(0) - 1;
                    Move(ref currRow, ref currCol, "up", matrix);
                }
                matrix[currRow, currCol] = 'f';
                return;
            }
            if (direction == "down")
            {
                currRow = currRow + 1;
                if (!IsValid(currRow, currCol, matrix))
                {
                    currRow = 0;
                    Move(ref currRow, ref currCol, "down", matrix);
                }
                matrix[currRow, currCol] = 'f';
                return;
            }
            if (direction == "left")
            {
                currCol = currCol - 1;
                if (!IsValid(currRow, currCol, matrix))
                {
                    currCol = matrix.GetLength(1) - 1;
                    Move(ref currRow, ref currCol, "left", matrix);
                }
                matrix[currRow, currCol] = 'f';
                return;
            }
            if (direction == "right")
            {
                currCol = currCol + 1;
                if (!IsValid(currRow, currCol, matrix))
                {
                    currCol = 0;
                    Move(ref currRow, ref currCol, "right", matrix);
                }
                matrix[currRow, currCol] = 'f';
                return;
            }
        }
        else if (matrix[currRow, currCol] == 'T')
        {
            if (direction == "up")
            {
                currRow = currRow + 1;
                if (!IsValid(currRow, currCol, matrix))
                {
                    currRow = matrix.GetLength(0) - 1;
                }
                matrix[currRow, currCol] = 'f';
                return;
            }
            if (direction == "down")
            {
                currRow = currRow - 1;
                if (!IsValid(currRow, currCol, matrix))
                {
                    currRow = 0;
                }
                matrix[currRow, currCol] = 'f';
                return;
            }
            if (direction == "left")
            {
                currCol = currCol + 1;
                if (!IsValid(currRow, currCol, matrix))
                {
                    currCol = matrix.GetLength(1) - 1;
                }
                matrix[currRow, currCol] = 'f';
                return;
            }
            if (direction == "right")
            {
                currCol = currCol - 1;
                if (!IsValid(currRow, currCol, matrix))
                {
                    currCol = 0;
                }
                matrix[currRow, currCol] = 'f';
                return;
            }
        }
        else if (matrix[currRow, currCol] == 'F')
        {
            matrix[currRow, currCol] = 'f';
            isFinalReached = true;
            return;
        }
    }

    private static bool IsValid(int currRow, int currCol, char[,] matrix)
    {
        return currRow >= 0 && currRow < matrix.GetLength(0) && currCol >= 0 && currCol < matrix.GetLength(1);
    }

    private static int[] FindStartPosition(char[,] matrix)
    {
        int[] startPosition = new int[2];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 'f')
                {
                    startPosition[0] = row;
                    startPosition[1] = col;
                }
            }
        }
        return startPosition;
    }
}
