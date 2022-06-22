using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        Queue<double> waterQueue = new Queue<double>(Console.ReadLine().Split().Select(double.Parse));
        Stack<double> flourStack = new Stack<double>(Console.ReadLine().Split().Select(double.Parse));

        Dictionary<string, int> madeMeals = new Dictionary<string, int>()
        {
            {"Croissant", 0 },
            {"Muffin", 0 },
            {"Baguette", 0 },
            {"Bagel", 0 },
        };

        while (waterQueue.Count > 0 && flourStack.Count > 0)
        {
            double water = waterQueue.Peek();
            double flour = flourStack.Peek();
            double sum = water + flour;

            double waterPercenatge = water * 100 / sum;
            double flourPercenatge = flour * 100 / sum;

            if (waterPercenatge == 50 && flourPercenatge == 50)
            {
                madeMeals["Croissant"]++;
                waterQueue.Dequeue();
                flourStack.Pop();
            }
            else if (waterPercenatge == 40 && flourPercenatge == 60)
            {
                madeMeals["Muffin"]++;
                waterQueue.Dequeue();
                flourStack.Pop();
            }
            else if (waterPercenatge == 30 && flourPercenatge == 70)
            {
                madeMeals["Baguette"]++;
                waterQueue.Dequeue();
                flourStack.Pop();
            }
            else if (waterPercenatge == 20 && flourPercenatge == 80)
            {
                madeMeals["Bagel"]++;
                waterQueue.Dequeue();
                flourStack.Pop();
            }
            else
            {
                if (flour - water >= 0)
                {
                    double remainingFlour = flourStack.Pop() - waterQueue.Dequeue();
                    flourStack.Push(remainingFlour);
                    madeMeals["Croissant"]++;
                }
            }
        }

        foreach (var item in madeMeals.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
        {
            if (item.Value > 0)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
        if (waterQueue.Count > 0)
        {
            Console.WriteLine($"Water left: {string.Join(", ", waterQueue)}");
        }
        else
        {
            Console.WriteLine("Water left: None");
        }

        if (flourStack.Count > 0)
        {
            Console.WriteLine($"Flour left: {string.Join(", ", flourStack)}");
        }
        else
        {
            Console.WriteLine("Flour left: None");
        }
    }
}