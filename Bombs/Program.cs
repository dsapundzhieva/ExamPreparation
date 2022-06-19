using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(",").Select(int.Parse));
        Stack<int> bombCasings = new Stack<int>(Console.ReadLine().Split(",").Select(int.Parse));

        Dictionary<string, int> materials = new Dictionary<string, int>()
        {
            {"Cherry Bombs", 60 },
            {"Datura Bombs", 40 },
            {"Smoke Decoy Bombs", 120 },
        };

        Dictionary<string, int> filledBombs = new Dictionary<string, int>()
        {
            {"Cherry Bombs", 0 },
            {"Datura Bombs", 0 },
            {"Smoke Decoy Bombs", 0 },
        };


        bool isTheBombPouchFull = false;

        while (bombEffects.Count != 0 && bombCasings.Count != 0 && (!isTheBombPouchFull))
        {
            isTheBombPouchFull = filledBombs["Cherry Bombs"] >= 3 && filledBombs["Datura Bombs"] >= 3 && filledBombs["Smoke Decoy Bombs"] >= 3 ? true : false;
            if (isTheBombPouchFull)
            {
                break;
            }

            var queue = bombEffects.Peek();
            var stack = bombCasings.Peek();
            int sum = queue + stack;

            if (sum == materials["Cherry Bombs"])
            {
                CheckForBombs(bombCasings, bombEffects, materials["Cherry Bombs"], filledBombs, "Cherry Bombs", sum);
            }
            else if (sum == materials["Datura Bombs"])
            {
                CheckForBombs(bombCasings, bombEffects, materials["Datura Bombs"], filledBombs, "Datura Bombs", sum);
            }
            else if (sum == materials["Smoke Decoy Bombs"])
            {
                CheckForBombs(bombCasings, bombEffects, materials["Smoke Decoy Bombs"], filledBombs, "Smoke Decoy Bombs", sum);
            }
            else
            {
                int value = bombCasings.Peek();
                bombCasings.Pop();
                bombCasings.Push(value - 5);

            }
        }

        if (isTheBombPouchFull)
        {
            Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
        }
        else
        {
            Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
        }

        bool isBombEffectsEmpty = bombEffects.Count == 0 ? true : false;
        bool isBombCasingsEmpty = bombCasings.Count == 0 ? true : false;

        if (isBombEffectsEmpty)
        {
            Console.WriteLine($"Bomb Effects: empty");
        }
        else
        {
            Console.Write($"Bomb Effects: ");
            Console.WriteLine(string.Join(", ", bombEffects));
        }

        if (isBombCasingsEmpty)
        {
            Console.WriteLine($"Bomb Casings: empty");
        }
        else
        {
            Console.Write($"Bomb Casings: ");
            Console.WriteLine(string.Join(", ", bombCasings));
        }


        foreach (var (bomb, quanity) in filledBombs.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{bomb}: {quanity}");
        }
    }

    private static void CheckForBombs(Stack<int> bombCasings, Queue<int> bombEffects, int material, Dictionary<string, int> filledBombs, string filledBombsName, int sum)
    {
        if (sum == material)
        {
            filledBombs[filledBombsName]++;
            bombCasings.Pop();
            bombEffects.Dequeue();
        }
    }
}