using System;
using System.Collections.Generic;

namespace CourseProject_Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            Maze maze = new Maze("maze1.txt");
            List<Agent> agents = new();
            var radius = 5;
            agents.Add(new Agent(1, 29, radius, maze.Clone()));
            agents.Add(new Agent(19, 1, radius, maze.Clone()));
            agents.Add(new Agent(7, 13, radius, maze.Clone()));
            var controller = new Controller { Maze = maze, Agents = agents };
            controller.Run();
        }
    }
}
