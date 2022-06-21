using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        string[][] matrix = new string[n][];

        for (int row = 0; row < n; row++)
        {
            string[] colEl = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            matrix[row] = new string[colEl.Length];

            for (int col = 0; col < colEl.Length; col++)
            {
                matrix[row][col] = colEl[col];
            }
        }

        string command;
        int collectedTokens = 0;
        int opponentsTokens = 0;

        while ((command = Console.ReadLine()) != "Gong")
        {
            var cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (command.StartsWith("Find"))
            {
                int currRow = int.Parse(cmdArgs[1]);
                int currCol = int.Parse(cmdArgs[2]);

                if (!IsIdxsValid(currRow, currCol, matrix))
                {
                    continue;
                }

                collectedTokens = (FindTokens(matrix, currRow, currCol) == true) ? collectedTokens += 1 : collectedTokens;

            }
            else if (command.StartsWith("Opponent"))
            {
                int currRow = int.Parse(cmdArgs[1]);
                int currCol = int.Parse(cmdArgs[2]);
                string direction = cmdArgs[3];

                if (!IsIdxsValid(currRow, currCol, matrix))
                {
                    continue;
                }
                opponentsTokens = FindTokens(matrix, currRow, currCol) == true ? opponentsTokens += 1 : opponentsTokens;

                if (direction == "up")
                {
                    int firstStepRow = currRow - 1;
                    int secondStepRow = currRow - 2;
                    int thirdStepRow = currRow - 3;

                    if (!IsIdxsValid(firstStepRow, currCol, matrix))
                    {
                        continue;
                    }
                    opponentsTokens = FindTokens(matrix, firstStepRow, currCol) == true ? opponentsTokens += 1 : opponentsTokens;

                    if (!IsIdxsValid(secondStepRow, currCol, matrix))
                    {
                        continue;
                    }
                    opponentsTokens = FindTokens(matrix, secondStepRow, currCol) == true ? opponentsTokens += 1 : opponentsTokens;
                    if (!IsIdxsValid(thirdStepRow, currCol, matrix))
                    {
                        continue;
                    }
                    opponentsTokens = FindTokens(matrix, thirdStepRow, currCol) == true ? opponentsTokens += 1 : opponentsTokens;

                }
                else if (direction == "down")
                {
                    int firstStepRow = currRow + 1;
                    int secondStepRow = currRow + 2;
                    int thirdStepRow = currRow + 3;

                    if (!IsIdxsValid(firstStepRow, currCol, matrix))
                    {
                        continue;
                    }
                    opponentsTokens = FindTokens(matrix, firstStepRow, currCol) == true ? opponentsTokens += 1 : opponentsTokens;

                    if (!IsIdxsValid(secondStepRow, currCol, matrix))
                    {
                        continue;
                    }
                    opponentsTokens = FindTokens(matrix, secondStepRow, currCol) == true ? opponentsTokens += 1 : opponentsTokens;
                    if (!IsIdxsValid(thirdStepRow, currCol, matrix))
                    {
                        continue;
                    }
                    opponentsTokens = FindTokens(matrix, thirdStepRow, currCol) == true ? opponentsTokens += 1 : opponentsTokens;
                }
                else if (direction == "left")
                {
                    int firstStepCol = currCol - 1;
                    int secondStepCol = currCol - 2;
                    int thirdStepCol = currCol - 3;

                    if (!IsIdxsValid(currRow, firstStepCol, matrix))
                    {
                        continue;
                    }
                    opponentsTokens = FindTokens(matrix, currRow, firstStepCol) == true ? opponentsTokens += 1 : opponentsTokens;

                    if (!IsIdxsValid(currRow, secondStepCol, matrix))
                    {
                        continue;
                    }
                    opponentsTokens = FindTokens(matrix, currRow, secondStepCol) == true ? opponentsTokens += 1 : opponentsTokens;
                    if (!IsIdxsValid(currRow, thirdStepCol, matrix))
                    {
                        continue;
                    }
                    opponentsTokens = FindTokens(matrix, currRow, thirdStepCol) == true ? opponentsTokens += 1 : opponentsTokens;
                }
                else if (direction == "right")
                {
                    int firstStepCol = currCol + 1;
                    int secondStepCol = currCol + 2;
                    int thirdStepCol = currCol + 3;

                    if (!IsIdxsValid(currRow, firstStepCol, matrix))
                    {
                        continue;
                    }
                    opponentsTokens = FindTokens(matrix, currRow, firstStepCol) == true ? opponentsTokens += 1 : opponentsTokens;

                    if (!IsIdxsValid(currRow, secondStepCol, matrix))
                    {
                        continue;
                    }
                    opponentsTokens = FindTokens(matrix, currRow, secondStepCol) == true ? opponentsTokens += 1: opponentsTokens;
                    if (!IsIdxsValid(currRow, thirdStepCol, matrix))
                    {
                        continue;
                    }
                    opponentsTokens = FindTokens(matrix, currRow, thirdStepCol) == true ? opponentsTokens += 1 : opponentsTokens;
                }
            }
        }

        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }

        Console.WriteLine($"Collected tokens: {collectedTokens}");
        Console.WriteLine($"Opponent's tokens: {opponentsTokens}");
    }

    private static bool FindTokens(string[][] matrix, int currRow, int currCol)
    {
        if (matrix[currRow][currCol] == "T")
        {
            matrix[currRow][currCol] = "-";
            return true;
        }
        return false;
    }

    private static bool IsIdxsValid(int currRow, int currCol, string[][] matrix)
    {
        return currRow >= 0 && currRow < matrix.GetLength(0) && currCol >= 0 && currCol < matrix[currRow].Length;
    }
}