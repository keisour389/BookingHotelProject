using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotelApp.DAL.Migrations
{
    public partial class BookingHotelDBUpdateVer15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "BookingDetails");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Booking",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Booking");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "BookingDetails",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
