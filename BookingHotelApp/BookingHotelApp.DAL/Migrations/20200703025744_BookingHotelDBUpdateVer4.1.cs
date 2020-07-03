using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotelApp.DAL.Migrations
{
    public partial class BookingHotelDBUpdateVer41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalHotel",
                table: "Partners",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalHotel",
                table: "Partners");
        }
    }
}
