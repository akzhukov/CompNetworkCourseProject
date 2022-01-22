using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_Maze
{
    public class Maze
    {
        public char[][] Data { get; set; }
        private string _filename;

        public Maze(string filename)
        {
            _filename = filename;
            string[] lines = File.ReadAllLines(filename);
            int lineNum = 0;
            Data = new char[lines.Length][];
            foreach (var line in lines)
            {
                Data[lineNum++] = line.Replace('o', ' ').ToCharArray();
            }
        }

        public bool IsFree(Point point)
        {
            return Data[point.X][point.Y] == ' ' || IsFinish(point);
        }

        public bool IsFinish(Point point)
        {
            return Data[point.X][point.Y] == 'F';
        }

        public void SetPoint(Point point, char c)
        {
            Data[point.X][point.Y] = c;
        }

        public void SetPoints(HashSet<Point> points, char c)
        {
            points.ForEach(p => SetPoint(p, c));
        }

        public Maze Clone()
        {
            return new Maze(_filename);
        }

        public void Print(List<Agent> agents, Agent currAgent)
        {
            
            for (int i = 0; i < Data.Length; i++)
            {
                Console.WriteLine(new string(Data[i]));
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (var point in currAgent.DeadEnds)
            {
                Console.SetCursorPosition(point.Y, point.X);
                Console.Write('x');
            }
            Console.ResetColor();

            foreach (var agent in agents)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(agent.Y, agent.X);
                Console.Write('o');
                Console.ResetColor();
                Console.SetCursorPosition(agent.PrevY, agent.PrevX);
                Console.Write(' ');
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(currAgent.Y, currAgent.X);
            Console.Write('o');
            Console.ResetColor();
            Console.SetCursorPosition(currAgent.PrevY, currAgent.PrevX);
            Console.Write(' ');

            Console.SetCursorPosition(0, 0);
        }

    }
}
