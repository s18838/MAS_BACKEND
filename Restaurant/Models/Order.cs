using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class Order
    {
        public Order()
        {
            WaiterRobots = new HashSet<WaiterRobot>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        private Reservation reservation;
        public Reservation Reservation {
            get => reservation;
            set
            {
                reservation = value;
                reservation.AddOrder(this);
            }
        }
        public ICollection<WaiterRobot> WaiterRobots { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public void AddWaiterRobot(WaiterRobot waiterRobot)
        {
            if (!WaiterRobots.Contains(waiterRobot))
            {
                WaiterRobots.Add(waiterRobot);
                waiterRobot.AddOrder(this);
            }
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            if (!OrderItems.Contains(orderItem))
            {
                OrderItems.Add(orderItem);
            }
        }
    }
}
