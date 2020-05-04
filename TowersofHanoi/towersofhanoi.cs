using System;
using System.Collections.Generic;

namespace TowersOfHanoi
{
    class Program
    {
        private static Dictionary<string, Stack<int>> board = new Dictionary<string, Stack<int>>();

        static void Main (string[] args) //main method
        {
            Stack<int> stack = new Stack<int>(); //creation of empty stack
            stack.Push(4); //game pieces that will be pushed from stack to stack; dictionary values
            stack.Push(3); 
            stack.Push(2); 
            stack.Push(1); 

            board.Add("A", stack); //add stacks to board dictionary and create "A" stack
            board.Add("B", new Stack<int>()); //add empty "B" stack to board dictionary
            board.Add("C", new Stack<int>()); //add empty "C" stack to board dictionary


            do
            {
                Console.Clear(); //beginning of game; ask for user input and clear and reprint board with move, if move is legal
                PrintBoard();
                Console.WriteLine("Which tower do you want to move from?");
                string from = Console.ReadLine().ToUpper(); //convert user intro from lowercase to upper, preventing an invalid move
                Console.WriteLine("Which tower are you moving to?");
                string to = Console.ReadLine().ToUpper();

                try
                {
                    if (LegalMove(from, to)) //if move is valid returns try
                    {
                        board[to].Push(board[from].Pop()); //push move to board and pop piece to new stack
                    }
                    else
                    {
                        Console.WriteLine("Illegal Move"); //informs user move is illegal
                        Console.WriteLine("Press any key to enter another move."); //prompts user to try again
                        Console.ReadKey(); 
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("This is an invalid move."); //informs user that entry is invalid
                    Console.ReadKey();
                }

            }
            while (!Winner()); //while there is no winner, continue looping


            Console.Clear();
            PrintBoard();
            Console.WriteLine("Winner!");
            Console.ReadKey();
        }


        private static bool Winner() //bool to check if the user has won the game
        {
            if (board["C"].Count == 4) //if stack "C" has all 4 pieces, the player has won
            {
                return true;
            }
            return false; //if all 4 pieces are not on stack "C", there is no winner
        }


        private static void PrintBoard() //game board
        {
            foreach (var item in board)
            {
                Console.WriteLine($"\n-{item.Key}-:"); //displays pieces on game board
                var stacks = item.Value.ToArray(); //values in stack to array

                for (int i = stacks.Length; i > 0; i--) //reverse loop to print the values in descending order
                    {
                    Console.Write(stacks[i - 1] + " "); //index -1 will print piees in descending order
                }
                Console.WriteLine();
            }


        }


        private static bool LegalMove(string from, string to) //determines legality of user movement choices
        {
            if (board[from].Count == 0) //board from must have a value of 1 or greater to move
            {
                return false;
            }
            else if (board[to].Count !=0) //board must have a value 1 or greater
            {
                if (board[to].Peek() > board[from].Peek()) //determines if movement to is greater than movement from
                {
                    return true;
                }
                return false;
            }
            else
            {
                return true; //returns true if to stack has no value 
            }
        }
    }
}
