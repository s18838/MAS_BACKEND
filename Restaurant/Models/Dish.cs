using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class Dish
    {
        public Dish()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Country { get; set; }
        public int Weight { get; set; }
        public string Ingredients { get; set; }
        public string Image { get; set; }
        public int CookingTime { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public void AddOrderItem(OrderItem orderItem)
        {
            if (!OrderItems.Contains(orderItem))
            {
                OrderItems.Add(orderItem);
                orderItem.Dish = this;
            }
        }
    }
}
