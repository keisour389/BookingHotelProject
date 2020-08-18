using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotelApp.DAL.Migrations
{
    public partial class BookingHotelDBUpdateVer11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingType",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "NumberOfPeople",
                table: "Booking");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookingType",
                table: "Booking",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPeople",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
