using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Work.DAL.Migrations
{
    public partial class ChangedForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_HotelTickets_HotelTicketReservationId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TransportTickets_TransportReservationId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TransportReservationId",
                table: "Orders",
                newName: "TransportTicketId");

            migrationBuilder.RenameColumn(
                name: "HotelTicketReservationId",
                table: "Orders",
                newName: "HotelTicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_TransportReservationId",
                table: "Orders",
                newName: "IX_Orders_TransportTicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_HotelTicketReservationId",
                table: "Orders",
                newName: "IX_Orders_HotelTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_HotelTickets_HotelTicketId",
                table: "Orders",
                column: "HotelTicketId",
                principalTable: "HotelTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TransportTickets_TransportTicketId",
                table: "Orders",
                column: "TransportTicketId",
                principalTable: "TransportTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_HotelTickets_HotelTicketId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TransportTickets_TransportTicketId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TransportTicketId",
                table: "Orders",
                newName: "TransportReservationId");

            migrationBuilder.RenameColumn(
                name: "HotelTicketId",
                table: "Orders",
                newName: "HotelTicketReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_TransportTicketId",
                table: "Orders",
                newName: "IX_Orders_TransportReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_HotelTicketId",
                table: "Orders",
                newName: "IX_Orders_HotelTicketReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_HotelTickets_HotelTicketReservationId",
                table: "Orders",
                column: "HotelTicketReservationId",
                principalTable: "HotelTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TransportTickets_TransportReservationId",
                table: "Orders",
                column: "TransportReservationId",
                principalTable: "TransportTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
