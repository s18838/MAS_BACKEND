using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Restaurant.Configurations;

namespace Restaurant.Models
{
    public class RestaurantContext: DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<RobotRepairman> RobotRepairmen { get; set; }
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<WaiterRobot> WaiterRobots { get; set; }
        public DbSet<ChefRobot> ChefRobots { get; set; }
        public DbSet<RoomReservation> RoomReservations { get; set; }
        public DbSet<TableReservation> TableReservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<PartyRoom> PartyRooms { get; set; }
        public DbSet<StandardRoom> StandardRooms { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public RestaurantContext()
        {

        }

        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChefRobotEfConfiguration());
            modelBuilder.ApplyConfiguration(new CookEfConfiguration());
            modelBuilder.ApplyConfiguration(new DishEfConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeEfConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEfConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemEfConfiguration());
            modelBuilder.ApplyConfiguration(new PersonEfConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationEfConfiguration());
            modelBuilder.ApplyConfiguration(new RobotEfConfiguration());
            modelBuilder.ApplyConfiguration(new RoomEfConfiguration());
            modelBuilder.ApplyConfiguration(new RoomReservationEfConfiguration());
            modelBuilder.ApplyConfiguration(new TableEfConfiguration());

            PartyRoom partyRoom1 = new PartyRoom()
            {
                Id = 1,
                Level = 1,
                Image = "/images/room0.jpg"
            };
            PartyRoom partyRoom2 = new PartyRoom()
            {
                Id = 2,
                Level = 1,
                Image = "/images/room1.jpg"
            };
            PartyRoom partyRoom3 = new PartyRoom()
            {
                Id = 3,
                Level = 2,
                Image = "/images/room2.jpg"
            };
            List<PartyRoom> partyRooms = new List<PartyRoom>()
            {
                partyRoom1,
                partyRoom2,
                partyRoom3
            };

            List<Table> tables = new List<Table>();

            for (int i = 1; i <= 18; i++)
            {
                Table table = new Table()
                {
                    Id = i,
                    NumberOfSeats = new Random().Next(3, 10),
                };

                if (i <= 3)
                {
                    table.RoomId = partyRoom1.Id;
                }
                else if (i <= 8)
                {
                    table.RoomId = partyRoom2.Id;
                }
                else
                {
                    table.RoomId = partyRoom3.Id;
                }

                tables.Add(table);
            }

            modelBuilder.Entity<Table>()
                .HasData(tables);

            modelBuilder.Entity<PartyRoom>()
                .HasData(partyRooms);

            List<Dish> dishes = new List<Dish>()
            {
                new Dish()
                {
                    Id = 1,
                    Name = "Ratatouille",
                    Price = 23,
                    Country = "France",
                    Weight = 340,
                    Ingredients = "salt, sos, rise, soya, meat",
                    Image = "/images/dish0.jpg",
                    CookingTime = 30
                },
                new Dish()
                {
                    Id = 2,
                    Name = "Samosa",
                    Price = 15,
                    Country = "France",
                    Weight = 140,
                    Ingredients = "chicken, apple",
                    Image = "/images/dish1.jpg",
                    CookingTime = 20
                },
                new Dish()
                {
                    Id = 3,
                    Name = "Jalebi",
                    Price = 25,
                    Country = "USA",
                    Weight = 200,
                    Ingredients = "meat, cheese",
                    Image = "/images/dish2.jpg",
                    CookingTime = 10
                },
                new Dish()
                {
                    Id = 4,
                    Name = "Phindi",
                    Price = 34,
                    Country = "USA",
                    Weight = 120,
                    Ingredients = "rise, fish, sos",
                    Image = "/images/dish3.jpg",
                    CookingTime = 16
                },
                new Dish()
                {
                    Id = 5,
                    Name = "Bharwa",
                    Price = 27,
                    Country = "Spain",
                    Weight = 230,
                    Ingredients = "fish, sos",
                    Image = "/images/dish4.jpg",
                    CookingTime = 40
                },
                new Dish()
                {
                    Id = 6,
                    Name = "Panipuri",
                    Price = 30,
                    Country = "Norway",
                    Weight = 110,
                    Ingredients = "mashrooms, sos",
                    Image = "/images/dish5.jpg",
                    CookingTime = 20
                },
                new Dish()
                {
                    Id = 7,
                    Name = "Malasa",
                    Price = 10,
                    Country = "Italy",
                    Weight = 70,
                    Ingredients = "meat, sos, species",
                    Image = "/images/dish6.jpg",
                    CookingTime = 13
                },
                new Dish()
                {
                    Id = 8,
                    Name = "Kulche",
                    Price = 7,
                    Country = "Canada",
                    Weight = 150,
                    Ingredients = "meat, sos",
                    Image = "/images/dish7.jpg",
                    CookingTime = 28
                },
                new Dish()
                {
                    Id = 9,
                    Name = "Katsu",
                    Price = 45,
                    Country = "Japan",
                    Weight = 350,
                    Ingredients = "prawn, sos",
                    Image = "/images/dish8.jpg",
                    CookingTime = 20
                },
                new Dish()
                {
                    Id = 10,
                    Name = "Navi",
                    Price = 35,
                    Country = "Mexica",
                    Weight = 450,
                    Ingredients = "meat, sos",
                    Image = "/images/dish9.jpg",
                    CookingTime = 33
                },
            };

            modelBuilder.Entity<Dish>()
                .HasData(dishes);
        }
    }
}
