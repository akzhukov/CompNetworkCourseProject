using System;
using System.Collections.Generic;
using System.IO;

namespace CourseProject_Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            Maze maze = new Maze(Path.Combine(projectDirectory, "maze2.txt"));
            List<Agent> agents = new();
            var radius = 5;
            //agents.Add(new Agent(1, 29, radius, maze.Clone()));
            //agents.Add(new Agent(19, 1, radius, maze.Clone()));
            //agents.Add(new Agent(7, 13, radius, maze.Clone()));
            agents.Add(new Agent(1, 18, radius, maze.Clone()));
            agents.Add(new Agent(19, 1, radius, maze.Clone()));
            agents.Add(new Agent(7, 13, radius, maze.Clone()));
            var controller = new Controller { Maze = maze, Agents = agents };
            controller.Run();
        }
    }
}
