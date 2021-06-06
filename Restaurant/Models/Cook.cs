using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class Cook : Person
    {
        public string Specialization { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public Cook()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public Cook(Client client) : base(client)
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            if (!OrderItems.Contains(orderItem))
            {
                OrderItems.Add(orderItem);
                orderItem.AddCook(this);
            }
        }
    }
}
