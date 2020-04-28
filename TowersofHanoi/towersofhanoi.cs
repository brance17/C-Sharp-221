using System;
using System.Collections.Generic;

namespace TowersOfHanoi
{
    class Program
    {
        private static Dictionary<string, Stack<int>> board = new Dictionary<string, Stack<int>>();

        static void Main (string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(4);
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);

            board.Add("A", stack);
            board.Add("B", new Stack<int>());
            board.Add("C", new Stack<int>());


            do
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine("Which tower do you want to move from?");
                string from = Console.ReadLine().ToUpper();
                Console.WriteLine("Which tower are you moving to?");
                string to = Console.ReadLine().ToUpper();

                try
                {
                    if (LegalMove(from, to))
                    {
                        board[to].Push(board[from].Pop());
                    }
                    else
                    {
                        Console.WriteLine("Illegal Move");
                        Console.WriteLine("Press any key to enter another move.");
                        Console.ReadKey();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("This is an invalid move.");
                    Console.ReadKey();
                }

            }
            while (!Winner());


            Console.Clear();
            PrintBoard();
            Console.WriteLine("Winner!");
            Console.ReadKey();
        }


        private static bool Winner()
        {
            if (board["C"].Count == 4)
            {
                return true;
            }
            return false;
        }


        private static void PrintBoard()
        {
            foreach (var item in board)
            {
                Console.WriteLine($"\n{item.Key}:");
                var stacks = item.Value.ToArray();

                for (int i = stacks.Length; i > 0; i--)
                    {
                    Console.Write(stacks[i - 1] + " ");
                }
                Console.WriteLine();
            }


        }


        private static bool LegalMove(string from, string to)
        {
            if (board[from].Count == 0)
            {
                return false;
            }
            else if (board[to].Count !=0)
            {
                if (board[to].Peek() > board[from].Peek())
                {
                    return true;
                }
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
