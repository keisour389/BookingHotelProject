using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotelApp.DAL.Migrations
{
    public partial class BookingHotelDBUpdateVer20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Partners",
                newName: "PartnerNote");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Employees",
                newName: "EmpNote");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Customers",
                newName: "CusNote");

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingType = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    CustomerPaymentMethods = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Required = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CustomerID = table.Column<string>(nullable: true),
                    EmployeeID = table.Column<string>(nullable: true),
                    BookingNote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Booking_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    HotelID = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    HotelName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Quality = table.Column<int>(type: "int", nullable: false),
                    HotelCreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    HotelPhoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    HotelEmail = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    HotelAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantType = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    RestaurantDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<double>(type: "float", nullable: false),
                    HotelPaymentMethods = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    PartnerID = table.Column<string>(nullable: false),
                    HotelNote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.HotelID);
                    table.ForeignKey(
                        name: "FK_Hotel_Partners_PartnerID",
                        column: x => x.PartnerID,
                        principalTable: "Partners",
                        principalColumn: "PartnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CustomerID",
                table: "Booking",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_EmployeeID",
                table: "Booking",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_PartnerID",
                table: "Hotel",
                column: "PartnerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.RenameColumn(
                name: "PartnerNote",
                table: "Partners",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "EmpNote",
                table: "Employees",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "CusNote",
                table: "Customers",
                newName: "Note");
        }
    }
}
