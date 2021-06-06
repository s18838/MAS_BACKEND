﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurant.Models;

namespace Restaurant.Migrations
{
    [DbContext(typeof(RestaurantContext))]
    partial class RestaurantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("ChefRobotOrderItem", b =>
                {
                    b.Property<int>("ChefRobotsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderItemsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ChefRobotsId", "OrderItemsId");

                    b.HasIndex("OrderItemsId");

                    b.ToTable("ChefRobotOrderItem");
                });

            modelBuilder.Entity("CookOrderItem", b =>
                {
                    b.Property<int>("CooksId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderItemsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CooksId", "OrderItemsId");

                    b.HasIndex("OrderItemsId");

                    b.ToTable("CookOrderItem");
                });

            modelBuilder.Entity("OrderWaiterRobot", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WaiterRobotsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrdersId", "WaiterRobotsId");

                    b.HasIndex("WaiterRobotsId");

                    b.ToTable("OrderWaiterRobot");
                });

            modelBuilder.Entity("Restaurant.Models.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CookingTime")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CookingTime = 30,
                            Country = "France",
                            Image = "/images/dish0.jpg",
                            Ingredients = "salt, sos, rise, soya, meat",
                            Name = "Ratatouille",
                            Price = 23,
                            Weight = 340
                        },
                        new
                        {
                            Id = 2,
                            CookingTime = 20,
                            Country = "France",
                            Image = "/images/dish1.jpg",
                            Ingredients = "chicken, apple",
                            Name = "Samosa",
                            Price = 15,
                            Weight = 140
                        },
                        new
                        {
                            Id = 3,
                            CookingTime = 10,
                            Country = "USA",
                            Image = "/images/dish2.jpg",
                            Ingredients = "meat, cheese",
                            Name = "Jalebi",
                            Price = 25,
                            Weight = 200
                        },
                        new
                        {
                            Id = 4,
                            CookingTime = 16,
                            Country = "USA",
                            Image = "/images/dish3.jpg",
                            Ingredients = "rise, fish, sos",
                            Name = "Phindi",
                            Price = 34,
                            Weight = 120
                        },
                        new
                        {
                            Id = 5,
                            CookingTime = 40,
                            Country = "Spain",
                            Image = "/images/dish4.jpg",
                            Ingredients = "fish, sos",
                            Name = "Bharwa",
                            Price = 27,
                            Weight = 230
                        },
                        new
                        {
                            Id = 6,
                            CookingTime = 20,
                            Country = "Norway",
                            Image = "/images/dish5.jpg",
                            Ingredients = "mashrooms, sos",
                            Name = "Panipuri",
                            Price = 30,
                            Weight = 110
                        },
                        new
                        {
                            Id = 7,
                            CookingTime = 13,
                            Country = "Italy",
                            Image = "/images/dish6.jpg",
                            Ingredients = "meat, sos, species",
                            Name = "Malasa",
                            Price = 10,
                            Weight = 70
                        },
                        new
                        {
                            Id = 8,
                            CookingTime = 28,
                            Country = "Canada",
                            Image = "/images/dish7.jpg",
                            Ingredients = "meat, sos",
                            Name = "Kulche",
                            Price = 7,
                            Weight = 150
                        },
                        new
                        {
                            Id = 9,
                            CookingTime = 20,
                            Country = "Japan",
                            Image = "/images/dish8.jpg",
                            Ingredients = "prawn, sos",
                            Name = "Katsu",
                            Price = 45,
                            Weight = 350
                        },
                        new
                        {
                            Id = 10,
                            CookingTime = 33,
                            Country = "Mexica",
                            Image = "/images/dish9.jpg",
                            Ingredients = "meat, sos",
                            Name = "Navi",
                            Price = 35,
                            Weight = 450
                        });
                });

            modelBuilder.Entity("Restaurant.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Restaurant.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DishId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Restaurant.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .HasMaxLength(16)
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasDiscriminator<int>("PersonType");
                });

            modelBuilder.Entity("Restaurant.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Reservation");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Reservation");
                });

            modelBuilder.Entity("Restaurant.Models.Robot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfLastCheck")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsStatic")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LaunchDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PositionX")
                        .HasColumnType("INTEGER")
                        .HasColumnName("X");

                    b.Property<int>("PositionY")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Y");

                    b.Property<int>("RobotType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Robot");

                    b.HasDiscriminator<int>("RobotType");
                });

            modelBuilder.Entity("Restaurant.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Room");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Room");
                });

            modelBuilder.Entity("Restaurant.Models.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NumberOfSeats = 9,
                            RoomId = 1
                        },
                        new
                        {
                            Id = 2,
                            NumberOfSeats = 8,
                            RoomId = 1
                        },
                        new
                        {
                            Id = 3,
                            NumberOfSeats = 5,
                            RoomId = 1
                        },
                        new
                        {
                            Id = 4,
                            NumberOfSeats = 6,
                            RoomId = 2
                        },
                        new
                        {
                            Id = 5,
                            NumberOfSeats = 6,
                            RoomId = 2
                        },
                        new
                        {
                            Id = 6,
                            NumberOfSeats = 8,
                            RoomId = 2
                        },
                        new
                        {
                            Id = 7,
                            NumberOfSeats = 7,
                            RoomId = 2
                        },
                        new
                        {
                            Id = 8,
                            NumberOfSeats = 7,
                            RoomId = 2
                        },
                        new
                        {
                            Id = 9,
                            NumberOfSeats = 9,
                            RoomId = 3
                        },
                        new
                        {
                            Id = 10,
                            NumberOfSeats = 6,
                            RoomId = 3
                        },
                        new
                        {
                            Id = 11,
                            NumberOfSeats = 6,
                            RoomId = 3
                        },
                        new
                        {
                            Id = 12,
                            NumberOfSeats = 9,
                            RoomId = 3
                        },
                        new
                        {
                            Id = 13,
                            NumberOfSeats = 9,
                            RoomId = 3
                        },
                        new
                        {
                            Id = 14,
                            NumberOfSeats = 7,
                            RoomId = 3
                        },
                        new
                        {
                            Id = 15,
                            NumberOfSeats = 4,
                            RoomId = 3
                        },
                        new
                        {
                            Id = 16,
                            NumberOfSeats = 4,
                            RoomId = 3
                        },
                        new
                        {
                            Id = 17,
                            NumberOfSeats = 3,
                            RoomId = 3
                        },
                        new
                        {
                            Id = 18,
                            NumberOfSeats = 5,
                            RoomId = 3
                        });
                });

            modelBuilder.Entity("RobotRobotRepairman", b =>
                {
                    b.Property<int>("RobotRepairmenId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RobotsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RobotRepairmenId", "RobotsId");

                    b.HasIndex("RobotsId");

                    b.ToTable("RobotRobotRepairman");
                });

            modelBuilder.Entity("Restaurant.Models.Client", b =>
                {
                    b.HasBaseType("Restaurant.Models.Person");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Restaurant.Models.Cook", b =>
                {
                    b.HasBaseType("Restaurant.Models.Person");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("Restaurant.Models.Employee", b =>
                {
                    b.HasBaseType("Restaurant.Models.Person");

                    b.Property<DateTime>("DateOfEmployment")
                        .HasColumnType("TEXT");

                    b.Property<int>("FinishHour")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Salary")
                        .HasColumnType("REAL");

                    b.Property<int>("StartHour")
                        .HasColumnType("INTEGER");
                });

            modelBuilder.Entity("Restaurant.Models.RoomReservation", b =>
                {
                    b.HasBaseType("Restaurant.Models.Reservation");

                    b.Property<int>("PartyRoomId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonCount")
                        .HasColumnType("INTEGER");

                    b.HasIndex("PartyRoomId");

                    b.HasDiscriminator().HasValue("RoomReservation");
                });

            modelBuilder.Entity("Restaurant.Models.TableReservation", b =>
                {
                    b.HasBaseType("Restaurant.Models.Reservation");

                    b.Property<int?>("TableId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("TableId");

                    b.HasDiscriminator().HasValue("TableReservation");
                });

            modelBuilder.Entity("Restaurant.Models.ChefRobot", b =>
                {
                    b.HasBaseType("Restaurant.Models.Robot");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Restaurant.Models.WaiterRobot", b =>
                {
                    b.HasBaseType("Restaurant.Models.Robot");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Restaurant.Models.PartyRoom", b =>
                {
                    b.HasBaseType("Restaurant.Models.Room");

                    b.HasDiscriminator().HasValue("PartyRoom");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "/images/room0.jpg",
                            Level = 1
                        },
                        new
                        {
                            Id = 2,
                            Image = "/images/room1.jpg",
                            Level = 1
                        },
                        new
                        {
                            Id = 3,
                            Image = "/images/room2.jpg",
                            Level = 2
                        });
                });

            modelBuilder.Entity("Restaurant.Models.StandardRoom", b =>
                {
                    b.HasBaseType("Restaurant.Models.Room");

                    b.HasDiscriminator().HasValue("StandardRoom");
                });

            modelBuilder.Entity("Restaurant.Models.RobotRepairman", b =>
                {
                    b.HasBaseType("Restaurant.Models.Employee");

                    b.Property<string>("Experience")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("ChefRobotOrderItem", b =>
                {
                    b.HasOne("Restaurant.Models.ChefRobot", null)
                        .WithMany()
                        .HasForeignKey("ChefRobotsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurant.Models.OrderItem", null)
                        .WithMany()
                        .HasForeignKey("OrderItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CookOrderItem", b =>
                {
                    b.HasOne("Restaurant.Models.Cook", null)
                        .WithMany()
                        .HasForeignKey("CooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurant.Models.OrderItem", null)
                        .WithMany()
                        .HasForeignKey("OrderItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderWaiterRobot", b =>
                {
                    b.HasOne("Restaurant.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurant.Models.WaiterRobot", null)
                        .WithMany()
                        .HasForeignKey("WaiterRobotsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Restaurant.Models.Order", b =>
                {
                    b.HasOne("Restaurant.Models.Reservation", "Reservation")
                        .WithMany("Orders")
                        .HasForeignKey("ReservationId");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("Restaurant.Models.OrderItem", b =>
                {
                    b.HasOne("Restaurant.Models.Dish", "Dish")
                        .WithMany("OrderItems")
                        .HasForeignKey("DishId");

                    b.HasOne("Restaurant.Models.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");

                    b.Navigation("Dish");
                });

            modelBuilder.Entity("Restaurant.Models.Reservation", b =>
                {
                    b.HasOne("Restaurant.Models.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Restaurant.Models.Table", b =>
                {
                    b.HasOne("Restaurant.Models.Room", "Room")
                        .WithMany("Tables")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("RobotRobotRepairman", b =>
                {
                    b.HasOne("Restaurant.Models.RobotRepairman", null)
                        .WithMany()
                        .HasForeignKey("RobotRepairmenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurant.Models.Robot", null)
                        .WithMany()
                        .HasForeignKey("RobotsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Restaurant.Models.RoomReservation", b =>
                {
                    b.HasOne("Restaurant.Models.PartyRoom", "PartyRoom")
                        .WithMany("RoomReservations")
                        .HasForeignKey("PartyRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PartyRoom");
                });

            modelBuilder.Entity("Restaurant.Models.TableReservation", b =>
                {
                    b.HasOne("Restaurant.Models.Table", "Table")
                        .WithMany("TableReservations")
                        .HasForeignKey("TableId");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Restaurant.Models.Dish", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Restaurant.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Restaurant.Models.Reservation", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Restaurant.Models.Room", b =>
                {
                    b.Navigation("Tables");
                });

            modelBuilder.Entity("Restaurant.Models.Table", b =>
                {
                    b.Navigation("TableReservations");
                });

            modelBuilder.Entity("Restaurant.Models.Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Restaurant.Models.PartyRoom", b =>
                {
                    b.Navigation("RoomReservations");
                });
#pragma warning restore 612, 618
        }
    }
}
