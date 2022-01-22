using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_Maze
{
    public class Connection
    {
        public Agent Agent1 { get; set; }
        public Agent Agent2 { get; set; }
        public bool CanHear()
        {
            return true;
        }
    }
}
