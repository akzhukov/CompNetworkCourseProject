using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_Maze
{
    public class Agent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int PrevX { get; set; }
        public int PrevY { get; set; }
        public int Radius { get; set; }
        public Maze Maze { get; set; }
        public List<Point> VisitedPoints { get; set; } = new();

        public Stack<Point> CurrentPath { get; set; } = new();

        public Stack<Point> NextPoints { get; set; } = new();

        public HashSet<Point> DeadEnds { get; set; } = new();

        public Agent(int x, int y, int radius, Maze maze)
        {
            PrevX = x;
            PrevY = y;
            X = x;
            Y = y;
            Radius = radius;
            Maze = maze;
        }

        public bool MakeStep()
        {
            var moves = GetPossibleMoves();
            if (!moves.Any())
            {
                while (CurrentPath.Any())
                {
                    var backPoint = CurrentPath.Pop();
                    Maze.SetPoint(backPoint, 'x');
                    DeadEnds.Add(backPoint);
                }
            }

            moves.ForEach(move => NextPoints.Push(move));
            if (!NextPoints.Any())
                return false;
            var nextPoint = NextPoints.Pop();
            if (Maze.IsFinish(nextPoint))
            {
                Console.WriteLine("WIN");
                return true;
            }
            PrevX = X;
            PrevY = Y;
            X = nextPoint.X;
            Y = nextPoint.Y;
            CurrentPath.Push(nextPoint);
            VisitedPoints.Add(nextPoint);
            return false;
        }

        private List<Point> GetPossibleMoves()
        {
            var result = new List<Point>();
            var currPoints = new List<Point> {
                new Point(X, Y - 1),
                new Point(X - 1, Y),
                new Point(X + 1, Y),
                new Point(X, Y + 1),
            };
            foreach (var currPoint in currPoints)
            {
                if (!VisitedPoints.Contains(currPoint) && Maze.IsFree(currPoint))
                {
                    result.Add(currPoint);
                }
            }
            return result;
        }

        public void ReceiveMessage(Message message)
        {
            Maze.SetPoints(message.Data, 'x');
            message.Data.ForEach(i =>
                {
                    if (!DeadEnds.Contains(i)) DeadEnds.Add(i);
                }
            );
            message.Receivers.Add(this);
        }
    }
}
