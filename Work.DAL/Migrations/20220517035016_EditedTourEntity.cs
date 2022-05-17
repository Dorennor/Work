using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Work.DAL.Migrations
{
    public partial class EditedTourEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TourPrice",
                table: "Tours",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "TourDurationInDays", "TourName", "TourPrice", "TourType" },
                values: new object[] { new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Fenway Park", 100.0, "Individual Tour" });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "Date", "TourDurationInDays", "TourMovementType", "TourName", "TourPrice", "TourRegion", "TourType" },
                values: new object[] { 2, new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Climbing", "Colorado Hiking: Rocky Mountain National Park", 200.0, "USA", "Mountain Skiing Tour" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "TourPrice",
                table: "Tours");

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "TourDurationInDays", "TourName", "TourType" },
                values: new object[] { new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Colorado Hiking: Rocky Mountain National Park", "Mountain Skiing Tour" });
        }
    }
}