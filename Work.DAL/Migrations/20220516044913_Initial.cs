using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Work.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelStars = table.Column<int>(type: "int", nullable: false),
                    HotelPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourRegion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourMovementType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TourDurationInDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLogged = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false),
                    Hotel = table.Column<int>(type: "int", nullable: false),
                    SummaryPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelTickets_Hotels_Hotel",
                        column: x => x.Hotel,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfUsing = table.Column<int>(type: "int", nullable: false),
                    Transport = table.Column<int>(type: "int", nullable: false),
                    TransportPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportTickets_Transports_Transport",
                        column: x => x.Transport,
                        principalTable: "Transports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tour = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<int>(type: "int", nullable: false),
                    HotelReservationTicket = table.Column<int>(type: "int", nullable: true),
                    TransportReservationTicket = table.Column<int>(type: "int", nullable: true),
                    TransportId = table.Column<int>(type: "int", nullable: true),
                    FinalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_HotelTickets_User",
                        column: x => x.User,
                        principalTable: "HotelTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Tours_Tour",
                        column: x => x.Tour,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_TransportTickets_TransportId",
                        column: x => x.TransportId,
                        principalTable: "TransportTickets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_User",
                        column: x => x.User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "HotelName", "HotelPrice", "HotelStars" },
                values: new object[,]
                {
                    { 1, "Belagio", 45.0, 3 },
                    { 2, "The Peninsula Chicago", 70.0, 4 },
                    { 3, "Montage Kapalua Bay", 90.0, 5 }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "Date", "TourDurationInDays", "TourMovementType", "TourName", "TourRegion", "TourType" },
                values: new object[] { 1, new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Walking", "Colorado Hiking: Rocky Mountain National Park", "USA", "Mountain Skiing Tour" });

            migrationBuilder.InsertData(
                table: "Transports",
                columns: new[] { "Id", "TransportName", "TransportPrice" },
                values: new object[,]
                {
                    { 1, "Liner", 82.599999999999994 },
                    { 2, "Bus", 10.199999999999999 },
                    { 3, "Airplane", 52.299999999999997 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsLogged", "PasswordHash", "Name" },
                values: new object[,]
                {
                    { 1, "administrator@mail.com", true, "CF-83-5D-E3-D4-EA-01-36-7C-45-E4-12-E7-A9-39-3A-85-A4-E4-0A-F1-49-ED-8C-3E-D6-C3-7C-05-B6-7B-27-81-3D-7F-F8-07-2C-10-35-CE-DD-19-41-5A-DF-17-12-8D-63-18-6F-05-F0-D6-56-00-2B-0C-A1-C3-4F-44-A0", "Administrator" },
                    { 2, "manager@mail.com", false, "5F-C2-CA-6F-08-59-19-F2-F7-76-26-F1-E2-80-FA-B9-CC-92-B4-ED-C9-ED-C5-3A-C6-EE-E3-F7-2C-5C-50-8E-86-9E-E9-D6-7A-96-D6-39-86-D1-4C-1C-2B-82-C3-5F-F5-F3-14-94-BE-A8-31-01-54-24-F5-9C-96-FF-F6-64", "Manager" },
                    { 3, "user@mail.com", false, "B1-43-61-40-4C-07-8F-FD-54-9C-03-DB-44-3C-3F-ED-E2-F3-E5-34-D7-3F-78-F7-73-01-ED-97-D4-A4-36-A9-FD-9D-B0-5E-E8-B3-25-C0-AD-36-43-8B-43-FE-C8-51-0C-20-4F-C1-C1-ED-B2-1D-09-41-C0-0E-9E-2C-1C-E2", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelTickets_Hotel",
                table: "HotelTickets",
                column: "Hotel");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Tour",
                table: "Orders",
                column: "Tour");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TransportId",
                table: "Orders",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_User",
                table: "Orders",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_TransportTickets_Transport",
                table: "TransportTickets",
                column: "Transport");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "HotelTickets");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "TransportTickets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Transports");
        }
    }
}
