using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        const int NEEDED_POLINATIONED_FLOWERS = 5;

        int matrixSize = int.Parse(Console.ReadLine());

        char[,] matrix  = new char[matrixSize, matrixSize];

        for (int row = 0; row < matrixSize; row++)
        {
            char[] colEllements = Console.ReadLine().ToCharArray();

            for (int col = 0; col < matrixSize; col++)
            {
                matrix[row,col] = colEllements[col];
            }
        }

        int[] startPosition = FindStartPosition(matrix, matrixSize);

        int currRow = startPosition[0];
        int currCol = startPosition[1];
        int polinationedFlowers = 0;

   
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "End")
            {
                break;
            }
            matrix[currRow, currCol] = '.';

            if (command == "up")
            {
                currRow = currRow - 1;
                if (currRow < 0)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                matrix = CrowlTheMatrix(matrixSize, matrix, ref currRow, ref currCol, ref polinationedFlowers, command);
            }
            if (command == "down")
            {
                currRow = currRow + 1;
                if (currRow >= matrixSize)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                matrix = CrowlTheMatrix(matrixSize, matrix, ref currRow, ref currCol, ref polinationedFlowers, command);
            }
            if (command == "left")
            {
                currCol = currCol - 1;
                if (currCol < 0)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                matrix = CrowlTheMatrix(matrixSize, matrix, ref currRow, ref currCol, ref polinationedFlowers, command);
            }
            if (command == "right")
            {
                currCol = currCol + 1;
                if (currCol >= matrixSize)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                matrix = CrowlTheMatrix(matrixSize, matrix, ref currRow, ref currCol, ref polinationedFlowers, command);
            }
        }

        if (polinationedFlowers >= NEEDED_POLINATIONED_FLOWERS)
        {
            Console.WriteLine($"Great job, the bee managed to pollinate {polinationedFlowers} flowers!");
        }
        else
        {
            Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {NEEDED_POLINATIONED_FLOWERS - polinationedFlowers} flowers more");
        }

        PrintTheMatrix(matrixSize, matrix);
    }

    public static void PrintTheMatrix(int matrixSize, char[,] matrix)
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
   
    private static char[,] CrowlTheMatrix(int matrixSize, char[,] matrix, ref int currRow, ref int currCol, ref int polinationedFlowers, string command)
    {
        if (matrix[currRow, currCol] == 'f')
        {
            polinationedFlowers ++;
            matrix[currRow, currCol] = 'B';
        }
        else if (matrix[currRow, currCol] == '.')
        {
            matrix[currRow, currCol] = 'B';
        }
        else if (matrix[currRow, currCol] == 'O')
        {
            matrix[currRow, currCol] = '.';
            if (command == "up")
            {
                currRow = currRow - 1;
                if (matrix[currRow, currCol] == 'f')
                {
                    polinationedFlowers++;
                }
                matrix[currRow, currCol] = 'B';
            }
            else if (command == "down")
            {
                currRow = currRow + 1;
                if (matrix[currRow, currCol] == 'f')
                {
                    polinationedFlowers++;
                }
                matrix[currRow, currCol] = 'B';
            }
            else if (command == "left")
            {
                currCol = currCol - 1;
                if (matrix[currRow, currCol] == 'f')
                {
                    polinationedFlowers++;
                }
                matrix[currRow, currCol] = 'B';
            }
            else if (command == "right")
            {
                currCol = currCol + 1;
                if (matrix[currRow, currCol] == 'f')
                {
                    polinationedFlowers++;
                }
                matrix[currRow, currCol] = 'B';
            }
        }
        return matrix;
    }

    private static int[] FindStartPosition(char[,] matrix, int matrixSize)
    {
        int[] startPosition = new int[2];

        for (int row = 0; row < matrixSize; row++)
        {
            for (int col = 0; col < matrixSize; col++)
            {
                if (matrix[row, col] == 'B')
                {
                    startPosition[0] = row;
                    startPosition[1] = col;
                }
            }
        }

        return startPosition;
    }
}