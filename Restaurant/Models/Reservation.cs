using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public abstract class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationStatus Status { get; set; }
        public int ClientId { get; set; }
        private Client client;
        public Client Client {
            get => client;
            set {
                client = value;
                client.AddReservation(this);
            }
        }
        public ICollection<Order> Orders { get; set; }

        public Reservation()
        {
            Orders = new HashSet<Order>();
        }

        public void AddOrder(Order order)
        {
            if (!Orders.Contains(order))
            {
                Orders.Add(order);
                order.Reservation = this;
            }
        }
    }
}
