using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        string[] volews = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string volewsStr = string.Join("", volews);
        string[] consonant = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string consonantStr = string.Join("", consonant);


        Queue<char> vowelsQueue = new Queue<char>(volewsStr.ToCharArray());
        Stack<char> consonantsStack = new Stack<char>(consonantStr.ToCharArray());

        string pear = "pear";
        string flour = "flour";
        string pork = "pork";
        string olive = "olive";

        List<string> foundWords = new List<string>();

        while (consonantsStack.Count > 0)
        {
            char vowelLetter = vowelsQueue.Peek();
            char consonantLetter = consonantsStack.Peek();

            pear = ChechIfWordContainsVowels(pear, vowelLetter);
            pear = ChechIfWordContainsVowels(pear, consonantLetter);
                                                                   
            flour = ChechIfWordContainsVowels(flour, vowelLetter);
            flour = ChechIfWordContainsVowels(flour, consonantLetter);
                                                                   
            pork = ChechIfWordContainsVowels(pork, vowelLetter);
            pork = ChechIfWordContainsVowels(pork, consonantLetter);
                                                                
            olive = ChechIfWordContainsVowels(olive, vowelLetter);
            olive = ChechIfWordContainsVowels(olive, consonantLetter);

            vowelsQueue.Dequeue();
            vowelsQueue.Enqueue(vowelLetter);
            consonantsStack.Pop();
        }

        if (pear.Replace(" ", "") == "")
        {
            foundWords.Add("pear");
        }
        if (flour.Replace(" ", "") == "")
        {
            foundWords.Add("flour");
        }
        if (pork.Replace(" ", "") == "")
        {
            foundWords.Add("pork");
        }
        if (olive.Replace(" ", "") == "")
        {
            foundWords.Add("olive");
        }

        Console.WriteLine($"Words found: {foundWords.Count}");

        foreach (var item in foundWords)
        {
            Console.WriteLine(item);
        }


    }

    private static string ChechIfWordContainsVowels(string word, char letter)
    {
        if (word.Contains(letter))
        {
            word = word.Replace(letter, ' ');
        }
        return word;
    }
}