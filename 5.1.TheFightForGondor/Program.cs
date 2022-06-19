using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int wavesOfOrcs = int.Parse(Console.ReadLine());

        Queue<int> platesQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
        Stack<int> orcsStack = new Stack<int>();

        int countWaves = 1;

        for (int i = 1; i <= wavesOfOrcs; i++)
        {
            orcsStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            if (i % 3 == 0)
            {
                platesQueue.Enqueue(int.Parse(Console.ReadLine()));
            }

            while (platesQueue.Count > 0 && orcsStack.Count > 0)
            {
                if (orcsStack.Peek() > platesQueue.Peek())
                {
                    int valueOfPlate = platesQueue.Dequeue();
                    int orcsValue = orcsStack.Pop();
                    orcsStack.Push(orcsValue - valueOfPlate);
                }
                else if (orcsStack.Peek() < platesQueue.Peek())
                {
                    int orcsValue = orcsStack.Pop();
                    int valueOfPlate = platesQueue.Peek();
                    int[] arrayPlates = platesQueue.ToArray();
                    arrayPlates[0] = valueOfPlate - orcsValue;
                    platesQueue = new Queue<int>(arrayPlates);
                }
                else if (orcsStack.Peek() == platesQueue.Peek())
                {
                    platesQueue.Dequeue();
                    orcsStack.Pop();
                }
            }
            if (platesQueue.Count == 0)
            {
                break;
            }
        }

        if (platesQueue.Count > 0)
        {
            Console.WriteLine("The people successfully repulsed the orc's attack.");
            Console.Write("Plates left: ");
            Console.WriteLine(string.Join(", ", platesQueue));
        }
        else if (orcsStack.Count > 0)
        {
            Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
            Console.Write("Orcs left: ");
            Console.WriteLine(string.Join(", ", orcsStack));
        }
        
    }
}