using System;
namespace Restaurant.Models
{
    public abstract class Employee : Person
    {
        public double Salary { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public int StartHour { get; set; }
        public int FinishHour { get; set; }

        public Employee() { }

        public Employee(Client client) : base(client) { }
    }
}
