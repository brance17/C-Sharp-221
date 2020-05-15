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
                Console.WriteLine("Enter the position for the checker you wish to move. X then Y. Ex. 2,1");
                string[] fromPostition = Console.ReadLine().ToString().Substring(0, 3).Split(',');
                var resultPosition = ProcessInput(fromPostition);
                Console.WriteLine("Enter destination for your chosen checker. X and then Y.");
                string[] toPosition = Console.ReadLine().ToString().Substring(0, 3).Split(',');
                var result2Position = ProcessInput(toPosition);


                Position src = resultPosition;
                Position dest = result2Position;
                Checker checker = board.GetChecker(src);

                if (IsLegalMove(checker.PlayerColor, src, dest))
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
            //ensures desired checker destination is valid
            if (source.Row < 0 || source.Row > 7 || source.Col < 0 || source.Col > 7
                || destination.Row < 0 || destination.Row > 7 || destination.Col < 0
                || destination.Col > 7) return false;

            //row distance between the destination position and the source position must be larger than 0 AND less than or equal to 2
            int rowDistance = Math.Abs(destination.Row - source.Row);
            int colDistance = Math.Abs(destination.Col - source.Col);

            //prevents checker from moving in a straight line
            if (colDistance == 0 || rowDistance == 0) return false;

            //checks checker diagonal
            if (rowDistance / colDistance != 1) return false;

            //checks that destination is not longer than 2 rows
            if (rowDistance > 2) return false;

            //checks for checkers in both initial position and the destination
            Checker c = board.GetChecker(source);

            //checks checker occupation in source position
            if (c == null)
            {
                return false;
            }

            c = board.GetChecker(destination);
            //checks for checker occupation in destination position
            if (c != null)
            {
                return false;
            }
            // source position has a checker and the destination position is empty and destination.Row != source.Row and destination.Column != source.Destination
            //checks that a jump can occur
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
                //locates middle square
                int row_mid = (destination.Row + source.Row) / 2;
                int col_mid = (destination.Col + source.Col) / 2;

                //grabs onto spot
                Position p = new Position(row_mid, col_mid);

                //picks up checker
                Checker c = board.GetChecker(p);

                //gets  jumping checker
                Checker player = board.GetChecker(source);

                //no checker to jump
                if (c == null)
                {
                    return false;
                }
                else
                {
                    //make sure your not jumping your own checker
                    if (c.PlayerColor == player.PlayerColor)
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
                // there must be a piece in the middle of the source and the destination
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
                Console.Write(r); //prints the row number based on iteration of r so this prints 0-7 row markers.
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