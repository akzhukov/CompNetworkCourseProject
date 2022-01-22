using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_Maze
{
    public class Message
    {
        public Agent Sender { get; set; }
        public HashSet<Point> Data{ get; set; }

        public List<Agent> Receivers { get; set; } = new();

        public Message(Agent sender, HashSet<Point> data)
        {
            Data = data;
            Sender = sender;
        }
    }
}
