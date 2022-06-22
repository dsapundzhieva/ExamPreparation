using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        char[,] matrix = new char[n, n];

        int takenGold = 0;

        for (int row = 0; row < n; row++)
        {
            char[] colElements = Console.ReadLine().ToCharArray();

            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = colElements[col];
            }
        }

        bool isArmyOutsideOfTheMatrix = false;

        while (true)
        {
            if (takenGold >= 65)
            {
                break;
            }

            int[] idxs = FindArmyIndex(matrix);
            int row = idxs[0];
            int col = idxs[1];

            string direction = Console.ReadLine();

            matrix[row, col] = '-';

            if (direction == "up")
            {
                if (row - 1 < 0)
                {
                    isArmyOutsideOfTheMatrix = true;
                    break;
                }
                if (char.IsDigit(matrix[row - 1, col]))
                {
                    takenGold += int.Parse(matrix[row - 1, col].ToString());
                    matrix[row - 1, col] = 'A';
                }
                else if (matrix[row - 1, col] == 'M')
                {
                    matrix[row - 1, col] = '-';
                    int[] newIdxs = FindMirrorIndex(matrix);
                    matrix[newIdxs[0], newIdxs[1]] = 'A';
                }
                else if (matrix[row - 1, col] == '-')
                {
                    matrix[row - 1, col] = 'A';
                }
            }
            else if (direction == "down")
            {
                if (row + 1 > n - 1)
                {
                    isArmyOutsideOfTheMatrix = true;
                    break;
                }
                if (char.IsDigit(matrix[row + 1, col]))
                {
                    takenGold += int.Parse(matrix[row + 1, col].ToString());
                    matrix[row + 1, col] = 'A';
                }
                else if (matrix[row + 1, col] == 'M')
                {
                    matrix[row + 1, col] = '-';
                    int[] newIdxs = FindMirrorIndex(matrix);
                    matrix[newIdxs[0], newIdxs[1]] = 'A';
                }
                else if (matrix[row + 1, col] == '-')
                {
                    matrix[row + 1, col] = 'A';
                }
            }
            else if (direction == "left")
            {
                if (col - 1 < 0)
                {
                    isArmyOutsideOfTheMatrix = true;
                    break;
                }
                if (char.IsDigit(matrix[row, col - 1]))
                {
                    takenGold += int.Parse(matrix[row, col - 1].ToString());
                    matrix[row, col - 1] = 'A';
                }
                else if (matrix[row, col - 1] == 'M')
                {
                    matrix[row, col - 1] = '-';
                    int[] newIdxs = FindMirrorIndex(matrix);
                    matrix[newIdxs[0], newIdxs[1]] = 'A';
                }
                else if (matrix[row, col - 1] == '-')
                {
                    matrix[row, col - 1] = 'A';
                }
            }
            else if (direction == "right")
            {
                if (col + 1 > n - 1)
                {
                    isArmyOutsideOfTheMatrix = true;
                    break;
                }
                if (char.IsDigit(matrix[row, col + 1]))
                {
                    takenGold += int.Parse(matrix[row, col + 1].ToString());
                    matrix[row, col + 1] = 'A';
                }
                else if (matrix[row, col + 1] == 'M')
                {
                    matrix[row, col + 1] = '-';
                    int[] newIdxs = FindMirrorIndex(matrix);
                    matrix[newIdxs[0], newIdxs[1]] = 'A';
                }
                else if (matrix[row, col + 1] == '-')
                {
                    matrix[row, col + 1] = 'A';
                }
            }
        }

        if (isArmyOutsideOfTheMatrix)
        {
            Console.WriteLine("I do not need more swords!");
        }
        else if (takenGold >= 65)
        {
            Console.WriteLine("Very nice swords, I will come back for more!");
        }

        Console.WriteLine($"The king paid {takenGold} gold coins.");

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

    private static int[] FindMirrorIndex(char[,] matrix)
    {
        int[] idxs = new int[2];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 'M')
                {
                    idxs[0] = row;
                    idxs[1] = col;
                }
            }
        }
        return idxs;
    }

    private static int[] FindArmyIndex(char[,] matrix)
    {
        int[] idxs = new int[2];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 'A')
                {
                    idxs[0] = row;
                    idxs[1] = col;
                }
            }
        }
        return idxs;
    }
}