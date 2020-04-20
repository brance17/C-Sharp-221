using System;
using System.Collections.Generic;
namespace Mastermind
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] colors = new string[] { "red", "yellow", "blue" };
            List<string> computerColors = new List<string>();
            List<string> userColors = new List<string>();
            Random random = new Random();
            computerColors.Add(colors[random.Next(0, 2)]);
            computerColors.Add(colors[random.Next(0, 2)]);

            bool isPlaying = true;
            while (isPlaying)
            {
                Console.Clear();
                userColors.Clear();


                Console.WriteLine("Let's play Mastermind!");
                Console.WriteLine("Guess the two colors in the correct position to win.");
                Console.WriteLine("Your choices are red, blue, and yellow.");
                Console.WriteLine("Please enter your first color:");
                userColors.Add(Console.ReadLine().ToLower().Trim());

                Console.WriteLine("Enter your second color: ");
                userColors.Add(Console.ReadLine().ToLower().Trim());

                if (userColors.Contains("exit"))
                {
                    break;
                }


                if (userColors[0].Equals(computerColors[0]) && userColors[1].Equals(computerColors[1]))
                {
                    Console.WriteLine("You win!");
                    break;
                }

                else if (userColors[0].Equals(computerColors[0]) || userColors.Contains(computerColors[1]))
                {
                    if (userColors[0].Equals(computerColors[1]) && userColors[1].Equals(computerColors[0]))
                    {
                        Console.WriteLine("\n2-0. Both colors are correct but in the wrong place!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("\n1-0. One of your colors is correct but in the wrong position!");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("\n0-0. No matches!");
                }

                Console.WriteLine("\nWould you like to play again? Y/N");
                isPlaying = Console.ReadLine().ToUpper().Contains("Y") ? true : false;
            }

            Console.WriteLine("\nGoodbye!");
            Console.ReadKey();
        }
    }
}
