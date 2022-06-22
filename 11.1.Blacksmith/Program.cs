using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        Queue<int> steelQueue = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

        Stack<int> carbonStack = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));



        Dictionary<string, int> foundSwords = new Dictionary<string, int>()
        {
            { "Gladius", 0},
            { "Shamshir", 0},
            { "Katana", 0},
            { "Sabre", 0},
            { "Broadsword", 0}
        };

        while (steelQueue.Count != 0 && carbonStack.Count != 0)
        {
            int steelValue = steelQueue.Dequeue();
            int carbonValue = carbonStack.Pop();

            int sum = steelValue + carbonValue;

            if (sum == 70)
            {
                foundSwords["Gladius"]++;
            }
            else if (sum == 80)
            {
                foundSwords["Shamshir"]++;
            }
            else if (sum == 90)
            {
                foundSwords["Katana"]++;

            }
            else if (sum == 110)
            {
                foundSwords["Sabre"]++;

            }
            else if (sum == 150)
            {
                foundSwords["Broadsword"]++;
            }
            else
            {
                carbonStack.Push(carbonValue + 5);
            }
        }

        int count = foundSwords.Where(x => x.Value >= 1).Count();
        if (count > 0)
        {
            int sum = foundSwords.Values.Sum();
            Console.WriteLine($"You have forged {foundSwords.Values.Sum()} swords.");
        }
        else
        {
            Console.WriteLine("You did not have enough resources to forge a sword.");
        }

        if (steelQueue.Count > 0)
        {
            Console.WriteLine($"Steel left: {string.Join(", ", steelQueue)}");
        }
        else
        {
            Console.WriteLine("Steel left: none");
        }

        if (carbonStack.Count > 0)
        {
            Console.WriteLine($"Carbon left: {string.Join(", ", carbonStack)}");
        }
        else
        {
            Console.WriteLine("Carbon left: none");
        }

        foreach (var sword in foundSwords.OrderBy(x => x.Key))
        {
            if (sword.Value > 0)
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }
    }
}