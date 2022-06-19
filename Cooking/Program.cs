using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        Queue<int> liquidQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
        Stack<int> ingredientsStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));



        Dictionary<string, int> foodDictionary = new Dictionary<string, int>()
        {
            { "Bread", 25 },
            { "Cake", 50 },
            { "Pastry", 75 },
            { "Fruit Pie", 100 },
        };

        Dictionary<string, int> resultDic = new Dictionary<string, int>()
        {
            { "Bread", 0 },
            { "Cake", 0 },
            { "Pastry", 0 },
            { "Fruit Pie", 0 },
        };

        while (liquidQueue.Count != 0 && ingredientsStack.Count != 0)
        {
            int sum = liquidQueue.Peek() + ingredientsStack.Peek();

            if (sum == foodDictionary["Bread"])
            {
                MixLiquidWithIngredients(liquidQueue, ingredientsStack, "Bread", sum, resultDic);
            }
            else if (sum == foodDictionary["Cake"])
            {
                MixLiquidWithIngredients(liquidQueue, ingredientsStack, "Cake", sum, resultDic);
            }
            else if (sum == foodDictionary["Pastry"])
            {
                MixLiquidWithIngredients(liquidQueue, ingredientsStack, "Pastry", sum, resultDic);
            }
            else if (sum == foodDictionary["Fruit Pie"])
            {
                MixLiquidWithIngredients(liquidQueue, ingredientsStack, "Fruit Pie", sum, resultDic);
            }
            else
            {
                liquidQueue.Dequeue();
                int value = ingredientsStack.Pop();
                ingredientsStack.Push(value + 3);
            }
        }

        int count = resultDic.Where(x => x.Value >= 1).Count();

        if (count >= 4)
        {
            Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
        }
        else
        {
            Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
        }

        if (liquidQueue.Count > 0)
        {
            Console.Write("Liquids left: ");
            Console.WriteLine(string.Join(", ", liquidQueue));
        }
        else
        {
            Console.WriteLine("Liquids left: none");
        }

        if (ingredientsStack.Count > 0)
        {
            Console.Write("Ingredients left: ");
            Console.WriteLine(string.Join(", ", ingredientsStack));
        }
        else
        {
            Console.WriteLine("Ingredients left: none");
        }

        foreach (var item in resultDic.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }

    private static void MixLiquidWithIngredients(Queue<int> liquidQueue, Stack<int> ingredientsStack, string foodName, int sum, Dictionary<string, int> resultDic)
    {
        resultDic[foodName]++;
        liquidQueue.Dequeue();
        ingredientsStack.Pop();

    }
}