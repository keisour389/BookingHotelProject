using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotelApp.DAL.Migrations
{
    public partial class BookingHotelDBUpdateVer30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HotelCountry",
                table: "Hotel",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Booking",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    BookingID = table.Column<int>(nullable: false),
                    HotelID = table.Column<string>(nullable: false),
                    RoomID = table.Column<string>(nullable: false),
                    NumberOfNights = table.Column<int>(type: "int", nullable: false),
                    BookingAmount = table.Column<int>(type: "int", nullable: false),
                    SpecialRequirements = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => new { x.BookingID, x.HotelID, x.RoomID });
                    table.ForeignKey(
                        name: "FK_BookingDetails_Booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "Booking",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingDetails_Hotel_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotel",
                        principalColumn: "HotelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingDetails_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomOfHotel",
                columns: table => new
                {
                    HotelID = table.Column<string>(nullable: false),
                    RoomID = table.Column<string>(nullable: false),
                    RoomAmount = table.Column<int>(type: "int", nullable: false),
                    RoomPriceForNight = table.Column<decimal>(type: "money", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomsCreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RoomOfHotelNote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomOfHotel", x => new { x.HotelID, x.RoomID });
                    table.ForeignKey(
                        name: "FK_RoomOfHotel_Hotel_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotel",
                        principalColumn: "HotelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomOfHotel_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_HotelID",
                table: "BookingDetails",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_RoomID",
                table: "BookingDetails",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomOfHotel_RoomID",
                table: "RoomOfHotel",
                column: "RoomID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetails");

            migrationBuilder.DropTable(
                name: "RoomOfHotel");

            migrationBuilder.DropColumn(
                name: "HotelCountry",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Booking");
        }
    }
}
