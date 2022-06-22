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
            
            string meal = mealQueue.Peek();
            int calories = caloriesStack.Peek();

            if (meal == "salad")
            {
                mealQueue.Dequeue();

                if (calories - 350 > 0)
                {
                    caloriesStack.Pop();
                    caloriesStack.Push(calories - 350);
                    eatenMeals++;
                }
                else if (calories - 350 == 0)
                {
                    caloriesStack.Pop();
                    eatenMeals++;
                }
                else
                {
                    leftMeals.Push(350 - caloriesStack.Pop());
                }
            }
            else if (meal == "soup")
            {
                mealQueue.Dequeue();
                if (calories - 490 > 0)
                {
                    caloriesStack.Pop();
                    caloriesStack.Push(calories - 490);
                    eatenMeals++;
                }
                else if (calories - 490 == 0)
                {
                    caloriesStack.Pop();
                    eatenMeals++;
                }
                else
                {
                    leftMeals.Push(490 - caloriesStack.Pop());
                }
            }
            else if (meal == "pasta")
            {
                mealQueue.Dequeue();
                if (calories - 680 > 0)
                {
                    caloriesStack.Pop();
                    caloriesStack.Push(calories - 680);
                    eatenMeals++;
                }
                else if (calories - 680 == 0)
                {
                    caloriesStack.Pop();
                    eatenMeals++;
                }
                else
                {
                    leftMeals.Push(680 - caloriesStack.Pop());
                }
            }
            else if (meal == "steak")
            {
                mealQueue.Dequeue();
                if (calories - 790 > 0)
                {
                    caloriesStack.Pop();
                    caloriesStack.Push(calories - 790);
                    eatenMeals++;
                }
                else if (calories - 790 == 0)
                {
                    caloriesStack.Pop();
                    eatenMeals++;
                }
                else
                {
                    leftMeals.Push(790 - caloriesStack.Pop());
                }
            }
            if (leftMeals.Count > 0)
            {
                int leftCalories = leftMeals.Peek();
                if (caloriesStack.Count == 0)
                {
                    eatenMeals++;
                    break;
                }
                if (caloriesStack.Peek() >= leftCalories)
                {
                    int cal = caloriesStack.Pop();
                    caloriesStack.Push(cal - leftCalories);
                    leftMeals.Pop();
                    eatenMeals++;
                }
                else
                {
                    leftMeals.Push(leftCalories - caloriesStack.Pop());
                }
                continue;
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
        if (mealQueue.Count > 0)
        {
            Console.WriteLine($"John ate enough, he had {eatenMeals} meals.");
            Console.WriteLine($"Meals left: {string.Join(", ", mealQueue)}.");
        }
    }
}