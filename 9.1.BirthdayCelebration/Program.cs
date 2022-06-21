using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        Queue<int> guestsQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

        Stack<int> platesStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

        int wastedFood = 0;

        while (guestsQueue.Count > 0 && platesStack.Count > 0)
        {
            if (guestsQueue.Peek() <= 0)
            {
                guestsQueue.Dequeue();
            }

            if (platesStack.Peek() >= guestsQueue.Peek())
            {
                wastedFood += platesStack.Pop() - guestsQueue.Dequeue();
            }
            else
            {
                int remainingGuestValue = guestsQueue.Peek() - platesStack.Peek();

                while (remainingGuestValue > 0)
                {
                    int[] queueArray = guestsQueue.ToArray();
                    queueArray[0] = remainingGuestValue;
                    guestsQueue = new Queue<int>(queueArray);
                    platesStack.Pop();
                    remainingGuestValue = guestsQueue.Peek() - platesStack.Peek();
                }
            }
        }
        if (platesStack.Count == 0)
        {
            Console.WriteLine($"Guests: {string.Join(" ", guestsQueue)}");
        }
        else
        {
            Console.WriteLine($"Plates: {string.Join(" ", platesStack)}");
        }
        Console.WriteLine($"Wasted grams of food: {wastedFood}");
    }
}