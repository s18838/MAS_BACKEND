using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class WaiterRobot : Robot
    {
        public static int MaxTableCount = 5;
        public ICollection<Order> Orders { get; set; }

        public WaiterRobot()
        {
            Orders = new HashSet<Order>();
        }

        public void AddOrder(Order order)
        {
            if (!Orders.Contains(order))
            {
                Orders.Add(order);
                order.AddWaiterRobot(this);
            }
        }
    }
}
