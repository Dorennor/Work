using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Work.DAL.Migrations
{
    public partial class DeletedForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelTickets_Hotels_HotelId",
                table: "HotelTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_HotelTickets_HotelTicketId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tours_TourId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TransportTickets_TransportTicketId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportTickets_Transports_TransportId",
                table: "TransportTickets");

            migrationBuilder.DropIndex(
                name: "IX_TransportTickets_TransportId",
                table: "TransportTickets");

            migrationBuilder.DropIndex(
                name: "IX_Orders_HotelTicketId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TourId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TransportTicketId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_HotelTickets_HotelId",
                table: "HotelTickets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TransportTickets_TransportId",
                table: "TransportTickets",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_HotelTicketId",
                table: "Orders",
                column: "HotelTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TourId",
                table: "Orders",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TransportTicketId",
                table: "Orders",
                column: "TransportTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelTickets_HotelId",
                table: "HotelTickets",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelTickets_Hotels_HotelId",
                table: "HotelTickets",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_HotelTickets_HotelTicketId",
                table: "Orders",
                column: "HotelTicketId",
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
                name: "FK_Orders_TransportTickets_TransportTicketId",
                table: "Orders",
                column: "TransportTicketId",
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
    }
}
