using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_Maze
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            Point point = obj as Point;
            return point.X == X && point.Y == Y;
        }

        public override int GetHashCode()
        {
            return 31 * X + Y;
        }
    }
}
