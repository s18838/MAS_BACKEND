using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class RobotRepairman : Employee
    {
        public string Experience { get; set; }
        public ICollection<Robot> Robots { get; set; }

        public RobotRepairman()
        {
            Robots = new HashSet<Robot>();
        }

        public RobotRepairman(Client client) : base(client)
        {
            Robots = new HashSet<Robot>();
        }

        public void AddRobot(Robot robot)
        {
            if (!Robots.Contains(robot))
            {
                Robots.Add(robot);
                robot.AddRobotRepairman(this);
            }
        }
    }
}
