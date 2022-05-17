using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Work.DAL.Migrations
{
    public partial class SecondFixForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_HotelTickets_HotelReservationTicket",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TransportTickets_TransportReservationTicket",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "TransportReservationTicket",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HotelReservationTicket",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_HotelTickets_HotelReservationTicket",
                table: "Orders",
                column: "HotelReservationTicket",
                principalTable: "HotelTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TransportTickets_TransportReservationTicket",
                table: "Orders",
                column: "TransportReservationTicket",
                principalTable: "TransportTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_HotelTickets_HotelReservationTicket",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TransportTickets_TransportReservationTicket",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "TransportReservationTicket",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HotelReservationTicket",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
