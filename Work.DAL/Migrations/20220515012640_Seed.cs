using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Work.DAL.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Manager" },
                    { 3, "User" }
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
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash" },
                values: new object[,]
                {
                    { 1, "administrator@mail.com", "CF-83-5D-E3-D4-EA-01-36-7C-45-E4-12-E7-A9-39-3A-85-A4-E4-0A-F1-49-ED-8C-3E-D6-C3-7C-05-B6-7B-27-81-3D-7F-F8-07-2C-10-35-CE-DD-19-41-5A-DF-17-12-8D-63-18-6F-05-F0-D6-56-00-2B-0C-A1-C3-4F-44-A0" },
                    { 2, "manager@mail.com", "5F-C2-CA-6F-08-59-19-F2-F7-76-26-F1-E2-80-FA-B9-CC-92-B4-ED-C9-ED-C5-3A-C6-EE-E3-F7-2C-5C-50-8E-86-9E-E9-D6-7A-96-D6-39-86-D1-4C-1C-2B-82-C3-5F-F5-F3-14-94-BE-A8-31-01-54-24-F5-9C-96-FF-F6-64" },
                    { 3, "user@mail.com", "B1-43-61-40-4C-07-8F-FD-54-9C-03-DB-44-3C-3F-ED-E2-F3-E5-34-D7-3F-78-F7-73-01-ED-97-D4-A4-36-A9-FD-9D-B0-5E-E8-B3-25-C0-AD-36-43-8B-43-FE-C8-51-0C-20-4F-C1-C1-ED-B2-1D-09-41-C0-0E-9E-2C-1C-E2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
