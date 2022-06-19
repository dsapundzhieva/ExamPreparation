using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        Queue<int> ingredientsQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
        Stack<int> freshnessLevelStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

        Dictionary<string, int> dishesList = new Dictionary<string, int>()
        {
            {"Dipping sauce", 150 },
            {"Green salad", 250 },
            {"Chocolate cake", 300 },
            {"Lobster", 400 },
        };

        Dictionary<string, int> madeDishes = new Dictionary<string, int>()
        {
            {"Dipping sauce", 0 },
            {"Green salad", 0 },
            {"Chocolate cake", 0 },
            {"Lobster", 0 },
        };

        while (ingredientsQueue.Count > 0 && freshnessLevelStack.Count > 0)
        {
            int sum = ingredientsQueue.Peek() * freshnessLevelStack.Peek();

            if (ingredientsQueue.Peek() == 0)
            {
                ingredientsQueue.Dequeue();
                continue;
            }

            if (dishesList["Dipping sauce"] == sum)
            {
                CheckIngredientsAndFreshness(ingredientsQueue, freshnessLevelStack, madeDishes, "Dipping sauce");
            }
            else if (dishesList["Green salad"] == sum)
            {
                CheckIngredientsAndFreshness(ingredientsQueue, freshnessLevelStack, madeDishes, "Green salad");
            }
            else if (dishesList["Chocolate cake"] == sum)
            {
                CheckIngredientsAndFreshness(ingredientsQueue, freshnessLevelStack, madeDishes, "Chocolate cake");
            }
            else if (dishesList["Lobster"] == sum)
            {
                CheckIngredientsAndFreshness(ingredientsQueue, freshnessLevelStack, madeDishes, "Lobster");
            }
            else
            {
                freshnessLevelStack.Pop();
                int valueOfIngredient = ingredientsQueue.Dequeue();
                ingredientsQueue.Enqueue(valueOfIngredient + 5);
            }
        }

        int count = madeDishes.Count(x => x.Value >= 1);

        if (count >= 4 )
        {
            Console.WriteLine("Applause! The judges are fascinated by your dishes!");
        }
        else
        {
            Console.WriteLine("You were voted off. Better luck next year.");
        }

        if (ingredientsQueue.Count > 0)
        {
            Console.WriteLine($"Ingredients left: {ingredientsQueue.Sum()}");
        }

        foreach (var item in madeDishes.OrderBy(x => x.Key))
        {
            if (item.Value >= 1)
            {
                Console.WriteLine($" # {item.Key} --> {item.Value}");
            }
        }
    }

    private static void CheckIngredientsAndFreshness(Queue<int> ingredientsQueue, Stack<int> freshnessLevelStack, Dictionary<string, int> madeDishes, string meal)
    {
        madeDishes[meal]++;
        ingredientsQueue.Dequeue();
        freshnessLevelStack.Pop();
    }
}