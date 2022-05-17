using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Work.DAL.Migrations
{
    public partial class EditedRequiredFieldsAndForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelTickets_Hotels_Hotel",
                table: "HotelTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_HotelTickets_HotelReservationTicket",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tours_Tour",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TransportTickets_TransportReservationTicket",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_User",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportTickets_Transports_Transport",
                table: "TransportTickets");

            migrationBuilder.RenameColumn(
                name: "Transport",
                table: "TransportTickets",
                newName: "TransportId");

            migrationBuilder.RenameIndex(
                name: "IX_TransportTickets_Transport",
                table: "TransportTickets",
                newName: "IX_TransportTickets_TransportId");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TransportReservationTicket",
                table: "Orders",
                newName: "TransportReservationId");

            migrationBuilder.RenameColumn(
                name: "Tour",
                table: "Orders",
                newName: "TourId");

            migrationBuilder.RenameColumn(
                name: "HotelReservationTicket",
                table: "Orders",
                newName: "HotelTicketReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_User",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_TransportReservationTicket",
                table: "Orders",
                newName: "IX_Orders_TransportReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_Tour",
                table: "Orders",
                newName: "IX_Orders_TourId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_HotelReservationTicket",
                table: "Orders",
                newName: "IX_Orders_HotelTicketReservationId");

            migrationBuilder.RenameColumn(
                name: "Hotel",
                table: "HotelTickets",
                newName: "HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelTickets_Hotel",
                table: "HotelTickets",
                newName: "IX_HotelTickets_HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelTickets_Hotels_HotelId",
                table: "HotelTickets",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_HotelTickets_HotelTicketReservationId",
                table: "Orders",
                column: "HotelTicketReservationId",
                principalTable: "HotelTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tours_TourId",
                table: "Orders",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TransportTickets_TransportReservationId",
                table: "Orders",
                column: "TransportReservationId",
                principalTable: "TransportTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportTickets_Transports_TransportId",
                table: "TransportTickets",
                column: "TransportId",
                principalTable: "Transports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelTickets_Hotels_HotelId",
                table: "HotelTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_HotelTickets_HotelTicketReservationId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tours_TourId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TransportTickets_TransportReservationId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportTickets_Transports_TransportId",
                table: "TransportTickets");

            migrationBuilder.RenameColumn(
                name: "TransportId",
                table: "TransportTickets",
                newName: "Transport");

            migrationBuilder.RenameIndex(
                name: "IX_TransportTickets_TransportId",
                table: "TransportTickets",
                newName: "IX_TransportTickets_Transport");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "TransportReservationId",
                table: "Orders",
                newName: "TransportReservationTicket");

            migrationBuilder.RenameColumn(
                name: "TourId",
                table: "Orders",
                newName: "Tour");

            migrationBuilder.RenameColumn(
                name: "HotelTicketReservationId",
                table: "Orders",
                newName: "HotelReservationTicket");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_User");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_TransportReservationId",
                table: "Orders",
                newName: "IX_Orders_TransportReservationTicket");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_TourId",
                table: "Orders",
                newName: "IX_Orders_Tour");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_HotelTicketReservationId",
                table: "Orders",
                newName: "IX_Orders_HotelReservationTicket");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "HotelTickets",
                newName: "Hotel");

            migrationBuilder.RenameIndex(
                name: "IX_HotelTickets_HotelId",
                table: "HotelTickets",
                newName: "IX_HotelTickets_Hotel");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelTickets_Hotels_Hotel",
                table: "HotelTickets",
                column: "Hotel",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_HotelTickets_HotelReservationTicket",
                table: "Orders",
                column: "HotelReservationTicket",
                principalTable: "HotelTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tours_Tour",
                table: "Orders",
                column: "Tour",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TransportTickets_TransportReservationTicket",
                table: "Orders",
                column: "TransportReservationTicket",
                principalTable: "TransportTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_User",
                table: "Orders",
                column: "User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportTickets_Transports_Transport",
                table: "TransportTickets",
                column: "Transport",
                principalTable: "Transports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
