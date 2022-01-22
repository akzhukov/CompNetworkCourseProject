using System;
using System.Collections.Generic;
using System.IO;

namespace CourseProject_Maze
{
    class Program
    {
        private static int _radius = 3;
        static void Main(string[] args)
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var path = Path.Combine(projectDirectory, "maze6.txt");
            Maze maze = new Maze(path);
            List<Agent> agents = GetAgentsFromFile(path, maze);
            var controller = new Controller { Maze = maze, Agents = agents };
            controller.Run();
        }

        private static List<Agent> GetAgentsFromFile(string filename, Maze m)
        {
            var agents = new List<Agent>();
            string[] lines = File.ReadAllLines(filename);
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    if (lines[i][j].Equals('o'))
                    {
                        agents.Add(new Agent(i, j, _radius, m.Clone()));
                    }
                }
            }
            return agents;
        }
    }
}
