using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Migrations
{
    public partial class Initialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", nullable: false),
                    Ingredients = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Image = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    CookingTime = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Surname = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 16, nullable: true),
                    Birthday = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PersonType = table.Column<int>(type: "INTEGER", nullable: false),
                    Specialization = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Salary = table.Column<double>(type: "REAL", nullable: true),
                    DateOfEmployment = table.Column<DateTime>(type: "TEXT", nullable: true),
                    StartHour = table.Column<int>(type: "INTEGER", nullable: true),
                    FinishHour = table.Column<int>(type: "INTEGER", nullable: true),
                    Experience = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Robot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LaunchDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateOfLastCheck = table.Column<DateTime>(type: "TEXT", nullable: false),
                    X = table.Column<int>(type: "INTEGER", nullable: false),
                    Y = table.Column<int>(type: "INTEGER", nullable: false),
                    IsStatic = table.Column<bool>(type: "INTEGER", nullable: false),
                    RobotType = table.Column<int>(type: "INTEGER", nullable: false),
                    Specialization = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Robot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RobotRobotRepairman",
                columns: table => new
                {
                    RobotRepairmenId = table.Column<int>(type: "INTEGER", nullable: false),
                    RobotsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RobotRobotRepairman", x => new { x.RobotRepairmenId, x.RobotsId });
                    table.ForeignKey(
                        name: "FK_RobotRobotRepairman_People_RobotRepairmenId",
                        column: x => x.RobotRepairmenId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RobotRobotRepairman_Robot_RobotsId",
                        column: x => x.RobotsId,
                        principalTable: "Robot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumberOfSeats = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tables_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReservationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    PersonCount = table.Column<int>(type: "INTEGER", nullable: true),
                    PartyRoomId = table.Column<int>(type: "INTEGER", nullable: true),
                    TableId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_People_ClientId",
                        column: x => x.ClientId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Room_PartyRoomId",
                        column: x => x.PartyRoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    DishId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderWaiterRobot",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "INTEGER", nullable: false),
                    WaiterRobotsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderWaiterRobot", x => new { x.OrdersId, x.WaiterRobotsId });
                    table.ForeignKey(
                        name: "FK_OrderWaiterRobot_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderWaiterRobot_Robot_WaiterRobotsId",
                        column: x => x.WaiterRobotsId,
                        principalTable: "Robot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChefRobotOrderItem",
                columns: table => new
                {
                    ChefRobotsId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderItemsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChefRobotOrderItem", x => new { x.ChefRobotsId, x.OrderItemsId });
                    table.ForeignKey(
                        name: "FK_ChefRobotOrderItem_OrderItems_OrderItemsId",
                        column: x => x.OrderItemsId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChefRobotOrderItem_Robot_ChefRobotsId",
                        column: x => x.ChefRobotsId,
                        principalTable: "Robot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CookOrderItem",
                columns: table => new
                {
                    CooksId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderItemsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookOrderItem", x => new { x.CooksId, x.OrderItemsId });
                    table.ForeignKey(
                        name: "FK_CookOrderItem_OrderItems_OrderItemsId",
                        column: x => x.OrderItemsId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CookOrderItem_People_CooksId",
                        column: x => x.CooksId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "CookingTime", "Country", "Image", "Ingredients", "Name", "Price", "Weight" },
                values: new object[] { 1, 30, "France", "/images/dish0.jpg", "salt, sos, rise, soya, meat", "Ratatouille", 23, 340 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "CookingTime", "Country", "Image", "Ingredients", "Name", "Price", "Weight" },
                values: new object[] { 2, 20, "France", "/images/dish1.jpg", "chicken, apple", "Samosa", 15, 140 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "CookingTime", "Country", "Image", "Ingredients", "Name", "Price", "Weight" },
                values: new object[] { 3, 10, "USA", "/images/dish2.jpg", "meat, cheese", "Jalebi", 25, 200 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "CookingTime", "Country", "Image", "Ingredients", "Name", "Price", "Weight" },
                values: new object[] { 4, 16, "USA", "/images/dish3.jpg", "rise, fish, sos", "Phindi", 34, 120 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "CookingTime", "Country", "Image", "Ingredients", "Name", "Price", "Weight" },
                values: new object[] { 5, 40, "Spain", "/images/dish4.jpg", "fish, sos", "Bharwa", 27, 230 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "CookingTime", "Country", "Image", "Ingredients", "Name", "Price", "Weight" },
                values: new object[] { 6, 20, "Norway", "/images/dish5.jpg", "mashrooms, sos", "Panipuri", 30, 110 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "CookingTime", "Country", "Image", "Ingredients", "Name", "Price", "Weight" },
                values: new object[] { 7, 13, "Italy", "/images/dish6.jpg", "meat, sos, species", "Malasa", 10, 70 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "CookingTime", "Country", "Image", "Ingredients", "Name", "Price", "Weight" },
                values: new object[] { 8, 28, "Canada", "/images/dish7.jpg", "meat, sos", "Kulche", 7, 150 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "CookingTime", "Country", "Image", "Ingredients", "Name", "Price", "Weight" },
                values: new object[] { 9, 20, "Japan", "/images/dish8.jpg", "prawn, sos", "Katsu", 45, 350 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "CookingTime", "Country", "Image", "Ingredients", "Name", "Price", "Weight" },
                values: new object[] { 10, 33, "Mexica", "/images/dish9.jpg", "meat, sos", "Navi", 35, 450 });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "Discriminator", "Image", "Level" },
                values: new object[] { 1, "PartyRoom", "/images/room0.jpg", 1 });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "Discriminator", "Image", "Level" },
                values: new object[] { 2, "PartyRoom", "/images/room1.jpg", 1 });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "Discriminator", "Image", "Level" },
                values: new object[] { 3, "PartyRoom", "/images/room2.jpg", 2 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "RoomId" },
                values: new object[] { 1, 7, 1 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "RoomId" },
                values: new object[] { 16, 5, 3 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "RoomId" },
                values: new object[] { 15, 5, 3 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "RoomId" },
                values: new object[] { 14, 7, 3 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "RoomId" },
                values: new object[] { 13, 4, 3 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "RoomId" },
                values: new object[] { 12, 6, 3 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "RoomId" },
                values: new object[] { 11, 9, 3 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "RoomId" },
                values: new object[] { 10, 3, 3 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "RoomId" },
                values: new object[] { 9, 8, 3 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "RoomId" },
                values: new object[] { 8, 3, 2 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "RoomId" },
                values: new object[] { 7, 5, 2 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "RoomId" },
                values: new object[] { 6, 9, 2 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "RoomId" },
                values: new object[] { 5, 6, 2 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "RoomId" },
                values: new object[] { 4, 4, 2 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "RoomId" },
                values: new object[] { 3, 9, 1 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "RoomId" },
                values: new object[] { 2, 9, 1 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "RoomId" },
                values: new object[] { 17, 5, 3 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "RoomId" },
                values: new object[] { 18, 6, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_ChefRobotOrderItem_OrderItemsId",
                table: "ChefRobotOrderItem",
                column: "OrderItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_CookOrderItem_OrderItemsId",
                table: "CookOrderItem",
                column: "OrderItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_DishId",
                table: "OrderItems",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReservationId",
                table: "Orders",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderWaiterRobot_WaiterRobotsId",
                table: "OrderWaiterRobot",
                column: "WaiterRobotsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ClientId",
                table: "Reservation",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PartyRoomId",
                table: "Reservation",
                column: "PartyRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_TableId",
                table: "Reservation",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_RobotRobotRepairman_RobotsId",
                table: "RobotRobotRepairman",
                column: "RobotsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_RoomId",
                table: "Tables",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChefRobotOrderItem");

            migrationBuilder.DropTable(
                name: "CookOrderItem");

            migrationBuilder.DropTable(
                name: "OrderWaiterRobot");

            migrationBuilder.DropTable(
                name: "RobotRobotRepairman");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Robot");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
