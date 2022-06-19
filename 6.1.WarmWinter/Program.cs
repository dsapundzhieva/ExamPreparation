using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        Stack<int> hatsStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
        Queue<int> scarfsQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

        List<int> createdSets = new List<int>();

        while (hatsStack.Count != 0 && scarfsQueue.Count > 0)
        {
            int currHat = hatsStack.Peek();
            int currScarf = scarfsQueue.Peek();

            if (currHat > currScarf)
            {
                createdSets.Add(currHat + currScarf);
                hatsStack.Pop();
                scarfsQueue.Dequeue();
            }
            else if (currHat < currScarf)
            {
                hatsStack.Pop();
            }
            else if (currHat == currScarf)
            {
                scarfsQueue.Dequeue();
                hatsStack.Pop();
                hatsStack.Push(currHat + 1);
            }
        }

        int mostExpensive = createdSets.OrderByDescending(x => x).First();
        Console.WriteLine($"The most expensive set is: {mostExpensive}");
        Console.WriteLine(string.Join(" ", createdSets));

    }
}