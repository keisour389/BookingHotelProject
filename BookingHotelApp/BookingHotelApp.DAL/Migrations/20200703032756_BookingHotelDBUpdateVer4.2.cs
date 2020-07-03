using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotelApp.DAL.Migrations
{
    public partial class BookingHotelDBUpdateVer42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDateOfAT",
                table: "Account",
                newName: "AccountCreatedDate");

            migrationBuilder.AddColumn<string>(
                name: "PartnerStatus",
                table: "Partners",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HotelStatus",
                table: "Hotel",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BookingStatus",
                table: "Booking",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountStatus",
                table: "Account",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartnerStatus",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "HotelStatus",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "BookingStatus",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "AccountStatus",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "AccountCreatedDate",
                table: "Account",
                newName: "CreatedDateOfAT");
        }
    }
}
