using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public OrderItemStatus Status { get; set; }
        public ICollection<Cook> Cooks { get; set; }
        public ICollection<ChefRobot> ChefRobots { get; set; }
        public int DishId { get; set; }
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
        public int OrderId { get; set; }
        public Order Order { get; }

        private OrderItem() {
            Cooks = new HashSet<Cook>();
            ChefRobots = new HashSet<ChefRobot>();
        }

        private OrderItem(Order order)
        {
            Cooks = new HashSet<Cook>();
            ChefRobots = new HashSet<ChefRobot>();
            Order = order;
            OrderId = order.Id;
        }

        public static OrderItem CreateOrderItem(Order order)
        {
            OrderItem orderItem = new OrderItem(order);
            order.AddOrderItem(orderItem);
            return orderItem;
        }

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
