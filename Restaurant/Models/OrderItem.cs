using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class OrderItem
    {
        private OrderItem() { }
        private OrderItem(Order order)
        {
            Cooks = new HashSet<Cook>();
            ChefRobots = new HashSet<ChefRobot>();
            Order = order;
        }

        public OrderItem CreateOrderItem(Order order)
        {
            OrderItem orderItem = new OrderItem(order);
            order.AddOrderItem(orderItem);
            return orderItem;
        }

        public int Id { get; set; }
        public int Count { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<Cook> Cooks { get; set; }
        public ICollection<ChefRobot> ChefRobots { get; set; }
        private Dish dish;
        public Dish Dish {
            get => dish;
            set
            {
                if (dish == value) return;
                dish = value;
                value.AddOrderItem(this);
            }
        }
        public Order Order { get; }

        public void AddCook(Cook cook)
        {
            if (!Cooks.Contains(cook))
            {
                Cooks.Add(cook);
                cook.AddOrderItem(this);
            }
        }

        public void AddChefRobot(ChefRobot chefRobot)
        {
            if (!ChefRobots.Contains(chefRobot))
            {
                ChefRobots.Add(chefRobot);
                chefRobot.AddOrderItem(this);
            }
        }
    }
}
