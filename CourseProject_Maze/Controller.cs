using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseProject_Maze
{
    public class Controller
    {
        public Maze Maze { get; set; }
        public List<Agent> Agents { get; set; } = new();
        //public List<Connection> Connections { get; set; } = new();

        public void InitConnections()
        {

        }

        public void Run()
        {
            while (true)
            {
                Maze.Print(Agents, Agents.FirstOrDefault());
                Thread.Sleep(100);
                foreach (var agent in Agents)
                {
                    if (agent.MakeStep())
                    {
                        return;
                    }
                }
                foreach (var agent in Agents)
                {
                    var msg = new Message(agent, agent.DeadEnds);
                    SendMessage(agent, msg);
                }

            }
        }

        private void SendMessage(Agent agent, Message msg)
        {
            var accessibleAgents = GetAccessibleAgents(agent, msg);
            if (!accessibleAgents.Any()) return;
            foreach (var accessibleAgent in accessibleAgents)
            {
                accessibleAgent.ReceiveMessage(msg);
                SendMessage(accessibleAgent, msg);
            }
        }

        private List<Agent> GetAccessibleAgents(Agent sender, Message message)
        {
            var result = new List<Agent>();

            foreach (var agent in Agents)
            {
                if (agent == sender) continue;
                if (CanHear(agent, sender) && !message.Receivers.Contains(agent))
                {

                    result.Add(agent);
                }
            }

            return result;
        }



        private bool CanHear(Agent agent1, Agent agent2)
        {
            //return true;
            var dist = Math.Sqrt((agent1.X - agent2.X) * (agent1.X - agent2.X)
              + (agent1.Y - agent2.Y) * (agent1.Y - agent2.Y));
            if (dist >= agent1.Radius && dist >= agent2.Radius)
            {
                return true;
            }
            return false;
        }

        public void chetotamWithMessage()
        {

        }

    }
}
