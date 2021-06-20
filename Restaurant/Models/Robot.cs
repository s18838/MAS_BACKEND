using System;
using System.Collections.Generic;
using System.Drawing;

namespace Restaurant.Models
{
    public abstract class Robot
    {
        public int Id { get; set; }
        public DateTime LaunchDate { get; set; }
        public DateTime DateOfLastCheck { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public ICollection<RobotRepairman> RobotRepairmen { get; set; }

        public bool IsStatic { get; set; }

        public Robot()
        {
            RobotRepairmen = new HashSet<RobotRepairman>();
        }

        public void AddRobotRepairman(RobotRepairman robotRepairman)
        {
            if (!RobotRepairmen.Contains(robotRepairman))
            {
                RobotRepairmen.Add(robotRepairman);
                robotRepairman.AddRobot(this);
            }
        }
    }
}
