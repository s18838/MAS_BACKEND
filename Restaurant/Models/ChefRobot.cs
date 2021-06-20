using System.Collections.Generic;

namespace Restaurant.Models
{
    public class ChefRobot : Robot
    {
        public string Specialization { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public ChefRobot()
        {
            OrderItems = new HashSet<OrderItem>();
        }

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
