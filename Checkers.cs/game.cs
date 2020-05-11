using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    public class Game
    {
        private Board board;
        private Color playerColor = Color.Black;
        bool isPlaying = true;

        public Game()
        {
            this.board = new Board();
        }

        public void Start()
        {


            while (isPlaying)
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("Enter coordinates for the checker you wish to move EX: 1,1");
                string[] fromPosition = Console.ReadLine().ToString().Substring(0, 3).Split(',');
                var firstPosition = ProcessInput(fromPostition);
                Console.WriteLine("Enter coordinates for the destination you wish to move to EX: 0,0");
                string[] toPosition = Console.ReadLine().ToString().Substring(0, 3).Split(',');
                var secondPosition = ProcessInput(toPosition);


                Position src = fromPosition;
                Position dest = toPosition;
                Checker checker = board.GetChecker(src);

                
                if (IsLegalMove(checker.playerColor, src, dest))
                {
                    if (IsCapture(src, dest))
                    {
                        board.RemoveChecker(GetCaptureChecker(src, dest));
                        board.MoveChecker(checker, dest);
                    }
                    else
                    {
                        board.MoveChecker(checker, dest);
                    }

                }
                else
                {
                    Console.WriteLine("\nInvalid move.  Press any key to try again.");
                    Console.ReadKey();
                }

                if (CheckForWin())
                {
                    isPlaying = false;
                    Console.WriteLine($"Player {playerColor} wins!");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
            }

        }

        public bool IsLegalMove(Color player, Position source, Position destination)
        {
            if (source.Row < 0 || source.Row > 7 || source.Col < 0 || source.Col > 7
                || destination.Row < 0 || destination.Row > 7 || destination.Col < 0
                || destination.Col > 7) return false;

            
            int rowDistance = Math.Abs(destination.Row - source.Row);
            int colDistance = Math.Abs(destination.Col - source.Col);

           
            if (colDistance == 0 || rowDistance == 0) return false;

            if (rowDistance / colDistance != 1) return false;

            if (rowDistance > 2) return false;

            Checker c = board.GetChecker(source);

            if (c == null)
            {
                return false;
            }

            c = board.GetChecker(destination);
            
            if (c != null)
            {
                return false;
            }
        
            if (rowDistance == 2)
            {
                if (IsCapture(source, destination))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public bool IsCapture(Position source, Position destination)
        {

            int rowDistance = Math.Abs(destination.Row - source.Row);
            int colDistance = Math.Abs(destination.Col - source.Col);

            if (rowDistance == 2 && colDistance == 2)
            {
                int row_mid = (destination.Row + source.Row) / 2;
                int col_mid = (destination.Col + source.Col) / 2;

                Position p = new Position(row_mid, col_mid);

                Checker c = board.GetChecker(p);

                Checker player = board.GetChecker(source);

                if (c == null)
                {
                    return false;
                }
                else
                {
                    if (c.playerColor == player.playerColor)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public Checker GetCaptureChecker(Position source, Position destination)
        {
            if (IsCapture(source, destination))
            {
                int row_mid = (destination.Row + source.Row) / 2;
                int col_mid = (destination.Col + source.Col) / 2;
                Position p = new Position(row_mid, col_mid);
                Checker c = board.GetChecker(p);
                return c;
            }
            return null;

        }

        public Position ProcessInput(string[] userMove)
        {

            int row;
            int col;
            if (!int.TryParse(userMove[0], out row))
            {
                Console.WriteLine("illegal move");
                return new Position(0, 0);
            }
            if (!int.TryParse(userMove[1], out col))
            {
                Console.WriteLine("illegal move");
                return new Position(0, 0);
            }
            return new Position(row, col);

        }

        public void DrawBoard()
        {
            String[][] grid = new String[8][];
            for (int r = 0; r < 8; r++)
            {
                grid[r] = new String[8];
                for (int c = 0; c < 8; c++)
                {
                    grid[r][c] = " ";
                }
            }
            foreach (Checker c in board.checkers)
            {
                grid[c.Position.Row][c.Position.Col] = c.Symbol;
            }

            Console.WriteLine("  0 1 2 3 4 5 6 7");
            for (int r = 0; r < 8; r++)
            {
                Console.Write(r); 
                for (int c = 0; c < 8; c++)
                {
                    Console.Write(" {0}", grid[r][c]);
                }
                Console.WriteLine();
            }
        }

        private bool CheckForWin()
        {
            int white = board.CountCheckers(Color.White);
            if (white == 0)
            {
                playerColor = Color.Black;
                return true;
            }

            int black = board.CountCheckers(Color.Black);
            if (black == 0)
            {
                playerColor = Color.White;
                return true;
            }

            return false;
        }
    }
}