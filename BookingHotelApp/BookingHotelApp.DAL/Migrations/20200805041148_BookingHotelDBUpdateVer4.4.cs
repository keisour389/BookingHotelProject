using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotelApp.DAL.Migrations
{
    public partial class BookingHotelDBUpdateVer44 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BedAmount",
                table: "RoomOfHotel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeopleAmount",
                table: "RoomOfHotel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PolicyApply",
                table: "RoomOfHotel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PolicyNotApply",
                table: "RoomOfHotel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BedAmount",
                table: "RoomOfHotel");

            migrationBuilder.DropColumn(
                name: "PeopleAmount",
                table: "RoomOfHotel");

            migrationBuilder.DropColumn(
                name: "PolicyApply",
                table: "RoomOfHotel");

            migrationBuilder.DropColumn(
                name: "PolicyNotApply",
                table: "RoomOfHotel");
        }
    }
}
