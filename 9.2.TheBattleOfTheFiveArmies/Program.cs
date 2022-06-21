
using System;
internal class Program
{
    public static int currRow;
    public static int currCol;

    static void Main(string[] args)
    {
        int energy = int.Parse(Console.ReadLine());

        int numRows = int.Parse(Console.ReadLine());

        if (numRows == 0)
        {
            return;
        }

        char[][] matrix = new char[numRows][];

        for (int row = 0; row < numRows; row++)
        {
            char[] colEl = Console.ReadLine().ToCharArray();
            matrix[row] = colEl;

            for (int col = 0; col < colEl.Length; col++)
            {

                if (matrix[row][col] == 'A')
                {
                    currRow = row;
                    currCol = col;
                }
            }
        }

        bool isArmyDead = false;
        bool isReachTheThrone = false;
        matrix[currRow][currCol] = '-';

        if (energy <= 0)
        {
            matrix[currRow][currCol] = 'X';
            isArmyDead = true;
        }
        while (true)
        {
            if (isArmyDead)
            {
                break;
            }
            if (isReachTheThrone)
            {
                break;
            }
            var command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string direction = command[0].ToLower();
            int enemyRow = int.Parse(command[1]);
            int enemyCol = int.Parse(command[2]);

            matrix[enemyRow][enemyCol] = 'O';
            energy -= 1;

            if (direction == "up")
            {
                if (!IsIdxsValid(currRow - 1, currCol, matrix))
                {
                    Outside(matrix, currRow, currCol, ref isArmyDead, ref energy);
                    continue;
                }
                currRow -= 1;
                Fight(ref energy, matrix, currRow, currCol, ref isArmyDead, ref isReachTheThrone);

            }
            else if (direction == "down")
            {
                if (!IsIdxsValid(currRow + 1, currCol, matrix))
                {
                    Outside(matrix, currRow, currCol, ref isArmyDead, ref energy);
                    continue;
                }
                currRow += 1;
                Fight(ref energy, matrix, currRow, currCol, ref isArmyDead, ref isReachTheThrone);
            }
            else if (direction == "left")
            {
                if (!IsIdxsValid(currRow, currCol - 1, matrix))
                {
                    Outside(matrix, currRow, currCol, ref isArmyDead, ref energy);
                    continue;
                }
                currCol -= 1;
                Fight(ref energy, matrix, currRow, currCol, ref isArmyDead, ref isReachTheThrone);
            }
            else if (direction == "right")
            {
                if (!IsIdxsValid(currRow, currCol + 1, matrix))
                {
                    Outside(matrix, currRow, currCol, ref isArmyDead, ref energy);
                    continue;
                }
                currCol += 1;
                Fight(ref energy, matrix, currRow, currCol, ref isArmyDead, ref isReachTheThrone);
            }
        }
        if (isArmyDead)
        {
            Console.WriteLine($"The army was defeated at {currRow};{currCol}.");
        }

        if (isReachTheThrone)
        {
            Console.WriteLine($"The army managed to free the Middle World! Armor left: {energy}");
        }
       

        foreach (var row in matrix)
        {
            Console.WriteLine(row);
        }
    }

    private static void Outside(char[][] matrix, int currRow, int currCol, ref bool isArmyDead, ref int energy)
    {
        if (energy <= 0)
        {
            matrix[currRow][currCol] = 'X';
            isArmyDead = true;
            return;
        }
    }

    private static void Fight(ref int energy, char[][] matrix, int currRow, int currCol, ref bool isArmyDead, ref bool isReachTheThrone)
    {
        if (energy <= 0 && matrix[currRow][currCol] != 'M')
        {
            matrix[currRow][currCol] = 'X';
            isArmyDead = true;
            return;
        }
        if (matrix[currRow][currCol] == 'O')
        {
            energy -= 2;
            if (energy <= 0)
            {
                matrix[currRow][currCol] = 'X';
                isArmyDead = true;
                return;
            }
            else
            {
                matrix[currRow][currCol] = '-';
            }
        }
        else if (matrix[currRow][currCol] == 'M')
        {
            matrix[currRow][currCol] = '-';
            isReachTheThrone = true;
        }
    }

    private static bool IsIdxsValid(int currRow, int currCol, char[][] matrix)
    {
        return currRow >= 0 && currRow < matrix.GetLength(0) && currCol >= 0 && currCol < matrix[0].Length;
    }
}