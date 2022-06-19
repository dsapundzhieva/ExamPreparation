using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        Stack<int> taskStack = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
        Queue<int> threadsQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
        int valueToBeKilled = int.Parse(Console.ReadLine());

        while (true)
        {
            int currThread = threadsQueue.Peek();
            int currStack = taskStack.Peek();

            if (currThread >= currStack && currStack != valueToBeKilled)
            {
                threadsQueue.Dequeue();
                taskStack.Pop();
            }
            else if (currThread < currStack && currStack != valueToBeKilled)
            {
                threadsQueue.Dequeue();
            }
            else if (currStack == valueToBeKilled)
            {
                Console.WriteLine($"Thread with value {currThread} killed task {currStack}");
                break;
            }
        }
        Console.WriteLine(string.Join(" ", threadsQueue));


    }
}