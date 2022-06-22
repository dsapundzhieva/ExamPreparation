using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {

        Queue<string> mealQueue = new Queue<string>(Console.ReadLine().Split(" "));
        Stack<int> caloriesStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
        int eatenMeals = 0;
        Stack<int> leftMeals = new Stack<int>();

        while (mealQueue.Count > 0 && caloriesStack.Count > 0)
        {
            if (leftMeals.Count > 0)
            {
                int leftCalories = leftMeals.Peek();
                if (caloriesStack.Peek() >= leftCalories)
                {
                    int cal = caloriesStack.Pop();
                    caloriesStack.Push(cal - leftCalories);
                    leftMeals.Pop();
                    eatenMeals++;
                    mealQueue.Dequeue();
                }
                else
                {
                    leftMeals.Push(leftCalories - caloriesStack.Pop());
                }
                continue;
            }
            string meal = mealQueue.Peek();
            int calories = caloriesStack.Peek();

            if (meal == "salad")
            {
                if (calories - 350 > 0)
                {
                    caloriesStack.Pop();
                    caloriesStack.Push(calories - 350);
                    mealQueue.Dequeue();
                    eatenMeals++;
                }
                else if (calories - 350 == 0)
                {
                    caloriesStack.Pop();
                    mealQueue.Dequeue();
                    eatenMeals++;
                }
                else
                {
                    leftMeals.Push(350 - caloriesStack.Pop());
                }
            }
            else if (meal == "soup")
            {
                if (calories - 490 > 0)
                {
                    caloriesStack.Pop();
                    caloriesStack.Push(calories - 490);
                    mealQueue.Dequeue();
                    eatenMeals++;
                }
                else if (calories - 490 == 0)
                {
                    caloriesStack.Pop();
                    mealQueue.Dequeue();
                    eatenMeals++;
                }
                else
                {
                    leftMeals.Push(490 - caloriesStack.Pop());
                }
            }
            else if (meal == "pasta")
            {
                if (calories - 680 > 0)
                {
                    caloriesStack.Pop();
                    caloriesStack.Push(calories - 680);
                    mealQueue.Dequeue();
                    eatenMeals++;
                }
                else if (calories - 680 == 0)
                {
                    caloriesStack.Pop();
                    mealQueue.Dequeue();
                    eatenMeals++;
                }
                else
                {
                    leftMeals.Push(680 - caloriesStack.Pop());
                }
            }
            else if (meal == "steak")
            {
                if (calories - 790 > 0)
                {
                    caloriesStack.Pop();
                    caloriesStack.Push(calories - 790);
                    mealQueue.Dequeue();
                    eatenMeals++;
                }
                else if (calories - 790 == 0)
                {
                    caloriesStack.Pop();
                    mealQueue.Dequeue();
                    eatenMeals++;
                }
                else
                {
                    leftMeals.Push(790 - caloriesStack.Pop());
                }
            }
        }

        if (mealQueue.Count == 0)
        {
            Console.WriteLine($"John had {eatenMeals} meals.");
        }
        if (caloriesStack.Count > 0)
        {
            Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesStack)} calories.");
        }
        if (mealQueue.Count >0)
        {
            Console.WriteLine($"John ate enough, he had {eatenMeals} meals.");
            Console.WriteLine($"Meals left: {string.Join(", ", mealQueue)}.");
        }
        
    }
}
