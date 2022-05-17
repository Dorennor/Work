using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Work.DAL.Migrations
{
    public partial class FixedForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_HotelTickets_User",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TransportTickets_TransportId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TransportId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TransportId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_HotelReservationTicket",
                table: "Orders",
                column: "HotelReservationTicket");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TransportReservationTicket",
                table: "Orders",
                column: "TransportReservationTicket");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_HotelTickets_HotelReservationTicket",
                table: "Orders",
                column: "HotelReservationTicket",
                principalTable: "HotelTickets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TransportTickets_TransportReservationTicket",
                table: "Orders",
                column: "TransportReservationTicket",
                principalTable: "TransportTickets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_HotelTickets_HotelReservationTicket",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TransportTickets_TransportReservationTicket",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_HotelReservationTicket",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TransportReservationTicket",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "TransportId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TransportId",
                table: "Orders",
                column: "TransportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_HotelTickets_User",
                table: "Orders",
                column: "User",
                principalTable: "HotelTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TransportTickets_TransportId",
                table: "Orders",
                column: "TransportId",
                principalTable: "TransportTickets",
                principalColumn: "Id");
        }
    }
}