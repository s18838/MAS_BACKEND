using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class ChefRobot : Robot
    {
        public ChefRobot()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public string Specialization { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public void AddOrderItem(OrderItem orderItem)
        {
            if (!OrderItems.Contains(orderItem))
            {
                OrderItems.Add(orderItem);
                orderItem.AddChefRobot(this);
            }
        }
    }
}
