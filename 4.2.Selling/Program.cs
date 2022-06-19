using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int matrixSize = int.Parse(Console.ReadLine());

        char[,] matrix = new char[matrixSize, matrixSize];

        for (int row = 0; row < matrixSize; row++)
        {
            char[] colElements = Console.ReadLine().ToCharArray();

            for (int col = 0; col < matrixSize; col++)
            {
                matrix[row, col] = colElements[col];
            }
        }

        int[] startPosition = FindStartPosition(matrix, matrixSize);
        int currRow = startPosition[0];
        int currCol = startPosition[1];
        int collectedMoney = 0;
        bool isOutOfBakary = false;

        while (true)
        {
            if (collectedMoney >= 50)
            {
                break;
            }
            string command = Console.ReadLine();

            matrix[currRow, currCol] = '-';

            if (command == "up")
            {
                currRow = currRow - 1;

                if (!AreCoordinatesValid(currRow, currCol, matrixSize))
                {
                    isOutOfBakary = true;
                    break;
                }
                matrix = SellingTour(matrixSize, matrix, ref currRow, ref currCol, ref collectedMoney);
            }
            else if (command == "down")
            {
                currRow = currRow + 1;

                if (!AreCoordinatesValid(currRow, currCol, matrixSize))
                {
                    isOutOfBakary = true;
                    break;
                }
                matrix = SellingTour(matrixSize, matrix, ref currRow, ref currCol, ref collectedMoney);
            }
            else if (command == "left")
            {
                currCol = currCol - 1;

                if (!AreCoordinatesValid(currRow, currCol, matrixSize))
                {
                    isOutOfBakary = true;
                    break;
                }
                matrix = SellingTour(matrixSize, matrix, ref currRow, ref currCol, ref collectedMoney);
            }
            else if (command == "right")
            {
                currCol = currCol + 1;

                if (!AreCoordinatesValid(currRow, currCol, matrixSize))
                {
                    isOutOfBakary = true;
                    break;
                }
                matrix = SellingTour(matrixSize, matrix, ref currRow, ref currCol, ref collectedMoney);
            }
        }

        if (isOutOfBakary)
        {
            Console.WriteLine("Bad news, you are out of the bakery.");
        }
        else
        {
            Console.WriteLine("Good news! You succeeded in collecting enough money!");
        }
        Console.WriteLine($"Money: {collectedMoney}");

        PrintMatrix(matrix, matrixSize);
    }

    private static void PrintMatrix(char[,] matrix, int matrixSize)
    {
        for (int row = 0; row < matrixSize; row++)
        {
            for (int col = 0; col < matrixSize; col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }

    }

    private static char[,] SellingTour(int matrixSize, char[,] matrix, ref int currRow, ref int currCol, ref int collectedMoney)
    {
        if (char.IsDigit(matrix[currRow, currCol]))
        {
            string matrixValue = matrix[currRow, currCol].ToString();

            collectedMoney += int.Parse(matrixValue);
            matrix[currRow, currCol] = 'S';
        }
        else if (matrix[currRow, currCol] == 'O')
        {
            matrix[currRow, currCol] = '-';
            int[] coordinatesOfSecondPillar = FindSecondPillarPosition(matrix, matrixSize);
            currRow = coordinatesOfSecondPillar[0];
            currCol = coordinatesOfSecondPillar[1];
            matrix[currRow, currCol] = 'S';
        }
        else if (matrix[currRow, currCol] == '-')
        {
            matrix[currRow, currCol] = 'S';
        }

        return matrix;
    }

    private static int[] FindSecondPillarPosition(char[,] matrix, int matrixSize)
    {
        int[] pillarPosition = new int[2];

        for (int row = 0; row < matrixSize; row++)
        {
            for (int col = 0; col < matrixSize; col++)
            {
                if (matrix[row, col] == 'O')
                {
                    pillarPosition[0] = row;
                    pillarPosition[1] = col;
                    break;
                }
            }
        }
        return pillarPosition;
    }

    private static bool AreCoordinatesValid(int row, int col, int matrixSize)
    {
        return (row >= 0 && row < matrixSize && col >= 0 && col < matrixSize);
    }

    private static int[] FindStartPosition(char[,] matrix, int matrixSize)
    {
        int[] startPosition = new int[2];

        for (int row = 0; row < matrixSize; row++)
        {
            for (int col = 0; col < matrixSize; col++)
            {
                if (matrix[row, col] == 'S')
                {
                    startPosition[0] = row;
                    startPosition[1] = col;
                }
            }
        }
        return startPosition;
    }
}