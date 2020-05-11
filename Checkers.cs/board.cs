using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    public class Board
    {
        public List<Checker> checkers;
        public Board()
        {
            checkers = new List<Checker>();
            for (int r = 0; r < 3; r++)
            {
                for (int i = 0; i < 8; i += 2)
                {
                    Checker c = new Checker(Color.White, r, (r + 1) % 2 + i);
                    checkers.Add(c);
                }
                for (int i = 0; i < 8; i += 2)
                {
                    Checker c = new Checker(Color.Black, 5 + r, (r) % 2 + i);
                    checkers.Add(c);
                }
            }
        }

        public Checker GetChecker(Position pos)
        {
            Checker found = null;
            foreach (Checker checker in checkers)
            {
                if (pos.Equals(checker.Position))
                {
                    found = checker;
                    break;
                }
            }
            return found;
        }

        public void RemoveChecker(Checker checker)
        {
            foreach (Checker item in checkers)
            {
                if (item.Equals(checker))
                {
                    checkers.Remove(item);
                    break;
                }
            }
        }

        public void MoveChecker(Checker checker, Position dest)
        {
            checkers.Remove(checker);
            checker.Position = dest;
            checkers.Add(checker);
        }

        public int CountCheckers(Color color)
        {
            int count = 0;
            foreach (Checker checker in checkers)
            {
                if (checker.PlayerColor == color)
                {
                    count++;
                }
            }

            return count;
        }

    }
}