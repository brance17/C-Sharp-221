using System;

namespace RockPaperScissors2
{
    class MainClass
    {
        static void Main(string[] args)
        {
            string userHand, computerHand;
            int randomInt;

            bool playAgain = true;

            while (playAgain)
            {

                int playerScore = 0;
                int computerScore = 0;

                while (playerScore < 3 && computerScore < 3)
                {


                    Console.Write("Rock, Paper, Scissors?: ");
                    userHand = Console.ReadLine();
                    userHand = userHand.ToUpper();

                    Random rnd = new Random();

                    randomInt = rnd.Next(1, 4);

                    switch (randomInt)
                    {
                        case 1:
                            computerHand = "ROCK";
                            Console.WriteLine("Computer plays rock");
                            if (userHand == "ROCK")
                            {

                                Console.WriteLine("It's a tie!!\n\n");

                            }
                            else if (userHand == "PAPER")
                            {

                                Console.WriteLine("You win!\n\n");
                                playerScore++;

                            }
                            else if (userHand == "SCISSORS")
                            {

                                Console.WriteLine("You lose!\n\n");
                                computerScore++;

                            }
                            break;
                        case 2:
                            computerHand = "PAPER";
                            Console.WriteLine("Computer plays paper");
                            if (userHand == "PAPER")
                            {

                                Console.WriteLine("It's a tie!\n\n");

                            }
                            else if (userHand == "ROCK")
                            {

                                Console.WriteLine("You lose!\n\n");
                                computerScore++;

                            }
                            else if (userHand == "SCISSORS")
                            {

                                Console.WriteLine("You win!\n\n");
                                playerScore++;

                            }
                            break;
                        case 3:
                            computerHand = "SCISSORS";
                            Console.WriteLine("Computer plays scissors");
                            if (userHand == "SCISSORS")
                            {

                                Console.WriteLine("It's a tie!\n\n");

                            }
                            else if (userHand == "ROCK")
                            {

                                Console.WriteLine("You win!\n\n");
                                playerScore++;

                            }
                            else if (userHand == "PAPER")
                            {

                                Console.WriteLine("You lose!\n\n");
                                computerScore++;

                            }
                            break;
                        default:
                            Console.WriteLine("Please enter rock, paper, or scissors.");
                            break;
                    }

                    Console.WriteLine("\n\nSCORES:\tPLAYER:\t{0}\tCPU:\t{1}", playerScore, computerScore);

                }

                if (playerScore == 3)
                {

                    Console.WriteLine("You won!");

                }
                else if (computerScore == 3)
                {

                    Console.WriteLine("You lost!");

                }
                else
                {

                }

                Console.WriteLine("Do you want to play again?(y/n)");
                string loop = Console.ReadLine();
                if (loop == "y")
                {

                    playAgain = true;
                    Console.Clear();

                }
                else if (loop == "n")
                {

                    playAgain = false;

                }
                else
                {

                }

            }
        }
    }
}