using System;
using System.Collections.Generic;

namespace PigLatin
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Enter your word");
            string answer = Console.ReadLine();

            char[] vowel = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            string ay = "ay";
            string yay = "yay";

            string[] split = answer.Split(' ');

            foreach (string word in split)
            {
                string first = word.Substring(0, 1);

                string last = word.Substring(answer.Length - 1);
            

            if (answer.IndexOfAny(vowel) == -1)
            {

                Console.Write($"{answer}{ay} ");

            }

            else if (first.IndexOfAny(vowel) == 0)
            {
                if (last.IndexOfAny(vowel) == 0)
                {
                    Console.Write($"{answer}{yay} ");
                }

                else
                {
                    Console.Write($"{answer}{ay} ");
                }
            }

            else
            {
                int findfirst = answer.IndexOfAny(vowel);

                string firstconsonant = answer.Substring(0, findfirst);

                string rest = word.Substring(findfirst);

                    Console.Write($"{rest}{firstconsonant}{ay} ");
            }
        }

    }

    }
}

 
