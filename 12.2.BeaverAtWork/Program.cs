using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static int row;
    private static int col;
    private static char[,] matrix;
    private static Stack<char> takenBranches;
    private static int countofAllBramches;
    private static string lastDirection;
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        matrix = new char[n, n];

        for (int row = 0; row < n; row++)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[] colEl = string.Join("", input).ToCharArray();

            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = colEl[col];
            }
        }

        countofAllBramches = FindAllBranches(matrix);
        takenBranches = new Stack<char>();

        string direction;

        while ((direction = Console.ReadLine()) != "end")
        {
            int[] idxs = FindBeaverIdxs(matrix);
            row = idxs[0];
            col = idxs[1];

            if (countofAllBramches <= 0)
            {
                break;
            }
            lastDirection = direction;
            if (direction == "up")
            {
                Move(-1, 0);
            }
            else if (direction == "down")
            {
                Move(1, 0);
            }
            else if (direction == "left")
            {
                Move(0, -1);
            }
            else if (direction == "right")
            {
                Move(0, 1);
            }
        }
        if (countofAllBramches == 0)
        {
            Console.WriteLine($"The Beaver successfully collect {takenBranches.Count} wood branches: {string.Join(", ", takenBranches.Reverse())}.");
        }
        else
        {
            Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countofAllBramches} branches left.");
        }

        PrintMatrix(matrix);
    }

    private static void Move(int r, int c)
    {
        if (!IsInside(row + r, col + c))
        {
            if (takenBranches.Count > 0)
            {
                takenBranches.Pop();
            }
            return;
        }
        matrix[row, col] = '-';
        row += r;
        col += c;

        if (char.IsLower(matrix[row, col]))
        {
            takenBranches.Push(matrix[row, col]);
            countofAllBramches--;
            matrix[row, col] = 'B';
        }
        else if (matrix[row, col] == 'F')
        {
            matrix[row, col] = '-';
            if (lastDirection == "up")
            {
                if (row == 0)
                {
                    if (char.IsLower(matrix[matrix.GetLength(0) - 1, col]))
                    {
                        takenBranches.Push(matrix[matrix.GetLength(0) - 1, col]);
                        countofAllBramches--;
                    }
                    row = matrix.GetLength(0) - 1;
                    matrix[row, col] = 'B';
                }
                else
                {
                    if (char.IsLower(matrix[0, col]))
                    {
                        takenBranches.Push(matrix[0, col]);
                        countofAllBramches--;
                    }
                    row = 0;
                    matrix[row, col] = 'B';
                }
            }
            else if (lastDirection == "down")
            {
                if (row == matrix.GetLength(0) - 1)
                {
                    if (char.IsLower(matrix[0, col]))
                    {
                        takenBranches.Push(matrix[0, col]);
                        countofAllBramches--;
                    }
                    row = 0;
                    matrix[row, col] = 'B';
                }
                else
                {
                    if (char.IsLower(matrix[matrix.GetLength(0) - 1, col]))
                    {
                        takenBranches.Push(matrix[matrix.GetLength(0) - 1, col]);
                        countofAllBramches--;
                    }
                    row = matrix.GetLength(0) - 1;
                    matrix[row, col] = 'B';
                }
            }
            else if (lastDirection == "left")
            {
                if (col == 0)
                {
                    if (char.IsLower(matrix[row, matrix.GetLength(1) - 1]))
                    {
                        takenBranches.Push(matrix[row, matrix.GetLength(1) - 1]);
                        countofAllBramches--;
                    }
                    col = matrix.GetLength(1) - 1;
                    matrix[row, col] = 'B';
                }
                else
                {
                    if (char.IsLower(matrix[row, 0]))
                    {
                        takenBranches.Push(matrix[row, 0]);
                        countofAllBramches--;
                    }
                    col = 0;
                    matrix[row, col] = 'B';
                }
            }
            else if (lastDirection == "right")
            {
                if (col == matrix.GetLength(1) - 1)
                {
                    if (char.IsLower(matrix[row, 0]))
                    {
                        takenBranches.Push(matrix[row, 0]);
                        countofAllBramches--;
                    }
                    col = 0;
                    matrix[row, col] = 'B';
                }
                else
                {
                    if (char.IsLower(matrix[row, matrix.GetLength(1) - 1]))
                    {
                        takenBranches.Push(matrix[row, matrix.GetLength(1) - 1]);
                        countofAllBramches--;
                    }
                    col = matrix.GetLength(1) - 1;
                    matrix[row, col] = 'B';
                }
            }
        }
        else
        {
            matrix[row, col] = 'B';
        }
    }

    private static bool IsInside(int row, int col)
    {
        return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
    }

    private static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    private static int FindAllBranches(char[,] matrix)
    {
        int count = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (char.IsLower(matrix[row, col]))
                {
                    count++;
                }
            }
        }
        return count;
    }

    private static int[] FindBeaverIdxs(char[,] matrix)
    {
        int[] idxs = new int[2];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 'B')
                {
                    idxs[0] = row;
                    idxs[1] = col;
                }
            }
        }
        return idxs;
    }
}
