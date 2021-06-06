using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class Client : Person
    {
        public virtual ICollection<Reservation> Reservations { get; set; }

        public Client()
        {
            Reservations = new HashSet<Reservation>();
        }

        public Client(Employee employee) : base(employee)
        {
            Reservations = new HashSet<Reservation>();
        }

        public void AddReservation(Reservation reservation)
        {
            if (!Reservations.Contains(reservation))
            {
                Reservations.Add(reservation);
                reservation.Client = this;
            }
        }
    }
}
