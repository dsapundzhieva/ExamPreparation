using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        const int NEEDED_FLOWERS = 15;
        const int NEEDED_WREATHS = 5;

        Stack<int> liliesStack = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
        Queue<int> rosesQueue = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));

        int wreath = 0;
        int storedFlowers = 0;

        while (liliesStack.Count != 0 && rosesQueue.Count != 0)
        {
            int sum = liliesStack.Peek() + rosesQueue.Peek();

            if (sum == NEEDED_FLOWERS)
            {
                wreath++;
                liliesStack.Pop();
                rosesQueue.Dequeue();
            }
            else if (sum > NEEDED_FLOWERS)
            {
                int currLiliesStackValue = liliesStack.Peek();
                liliesStack.Pop();
                liliesStack.Push(currLiliesStackValue - 2);
            }
            else if (sum < NEEDED_FLOWERS)
            {
                storedFlowers += liliesStack.Pop();
                storedFlowers += rosesQueue.Dequeue();
            }
        }

        var additionalWreaths = storedFlowers / NEEDED_FLOWERS;

        if (wreath + additionalWreaths >= NEEDED_WREATHS)
        {
            Console.WriteLine($"You made it, you are going to the competition with {wreath + additionalWreaths} wreaths!");
        }
        else
        {
            Console.WriteLine($"You didn't make it, you need {NEEDED_WREATHS - (wreath + additionalWreaths)} wreaths more!");
        }

    }
}