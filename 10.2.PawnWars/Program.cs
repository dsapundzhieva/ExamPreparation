using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        char[,] matrix = new char[8, 8];

        int whiteRow = 0;
        int whiteCol = 0;
        int blackRow = 0;
        int blackCol = 0;
        bool isWhitePromotedToQueen = false;
        bool doesWhiteCaptureBlack = false;

        bool isBlackPromotedToQueen = false;
        bool doesBlackCaptureWhite = false;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            char[] colEl = Console.ReadLine().ToCharArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = colEl[col];

                if (matrix[row, col] == 'w')
                {
                    whiteRow = row;
                    whiteCol = col;
                }
                if (matrix[row, col] == 'b')
                {
                    blackRow = row;
                    blackCol = col;
                    matrix[row, col] = '-';
                }
            }
        }

        matrix[blackRow, blackCol] = 'b';
        Dictionary<int, char> mapColsToLetters = new Dictionary<int, char>()
        {
            {0, 'a' },
            {1, 'b' },
            {2, 'c' },
            {3, 'd' },
            {4, 'e' },
            {5, 'f' },
            {6, 'g' },
            {7, 'h' },

        };

        while (true)
        {
            //white moves

            //check idx left diagonal

            if (IsIdxsValid(whiteRow - 1, whiteCol - 1, matrix))
            {
                if (matrix[whiteRow - 1, whiteCol - 1] == 'b')
                {
                    matrix[whiteRow, whiteCol] = '-';

                    doesWhiteCaptureBlack = true;
                    whiteRow = whiteRow - 1;
                    whiteCol = whiteCol - 1;
                    matrix[whiteRow, whiteCol] = 'w';
                    break;
                }
            }
            //check idx right diagonal
            if (IsIdxsValid(whiteRow - 1, whiteCol + 1, matrix))
            {
                if (matrix[whiteRow - 1, whiteCol + 1] == 'b')
                {
                    matrix[whiteRow, whiteCol] = '-';

                    doesWhiteCaptureBlack = true;
                    whiteRow = whiteRow - 1;
                    whiteCol = whiteCol + 1;
                    matrix[whiteRow, whiteCol] = 'w';
                    break;
                }
            }
            //check idx forward
            matrix[whiteRow, whiteCol] = '-';
            whiteRow = whiteRow - 1;

            if (whiteRow == 0)
            {
                isWhitePromotedToQueen = true;
                matrix[whiteRow, whiteCol] = 'w';
                break;
            }
            matrix[whiteRow, whiteCol] = 'w';

            //black moves

            //check idx left diagonal
            if (IsIdxsValid(blackRow + 1, blackCol - 1, matrix))
            {
                if (matrix[blackRow + 1, blackCol - 1] == 'w')
                {
                    matrix[blackRow, blackCol] = '-';

                    doesBlackCaptureWhite = true;
                    blackRow = blackRow + 1;
                    blackCol = blackCol - 1;
                    matrix[blackRow, blackCol] = 'b';
                    break;
                }
            }
            //check idx right diagonal
            if (IsIdxsValid(blackRow + 1, blackCol + 1, matrix))
            {
                if (matrix[blackRow + 1, blackCol + 1] == 'w')
                {
                    matrix[blackRow, blackCol] = '-';

                    doesBlackCaptureWhite = true;
                    blackRow = blackRow + 1;
                    blackCol = blackCol + 1;
                    matrix[blackRow, blackCol] = 'b';
                    break;
                }
            }
            //check idx forward
            matrix[blackRow, blackCol] = '-';
            blackRow = blackRow + 1;

            if (blackRow == 7)
            {
                isBlackPromotedToQueen = true;
                matrix[blackRow, blackCol] = 'b';
                break;
            }
            matrix[blackRow, blackCol] = 'b';
        }


        if (isWhitePromotedToQueen)
        {
            Console.WriteLine($"Game over! White pawn is promoted to a queen at {mapColsToLetters[whiteCol]}8.");
        }
        else if (doesWhiteCaptureBlack)
        {
            Console.WriteLine($"Game over! White capture on {mapColsToLetters[whiteCol]}{8 - whiteRow}.");
        }
        else if (isBlackPromotedToQueen)
        {
            Console.WriteLine($"Game over! Black pawn is promoted to a queen at {mapColsToLetters[blackCol]}1.");
        }
        else if (doesBlackCaptureWhite)
        {
            Console.WriteLine($"Game over! Black capture on {mapColsToLetters[blackCol]}{8 - blackRow}.");
        }
    }

    private static bool IsIdxsValid(int currRow, int currCol, char[,] matrix)
    {
        return currRow >= 0 && currRow < matrix.GetLength(0) && currCol >= 0 && currCol < matrix.GetLength(1);
    }

    private static Tuple<int, int> FindIndexes(char[,] matrix, char color)
    {

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            char[] colEl = Console.ReadLine().ToCharArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == color)
                {
                    return new Tuple<int, int>(row, col);
                }
            }
        }
    }
}