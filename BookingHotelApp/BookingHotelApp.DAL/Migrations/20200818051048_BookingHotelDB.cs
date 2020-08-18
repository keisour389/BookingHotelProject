using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotelApp.DAL.Migrations
{
    public partial class BookingHotelDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CusAccount",
                columns: table => new
                {
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AccountCreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AccountStatus = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CusAccount", x => x.PhoneNumber);
                });

            migrationBuilder.CreateTable(
                name: "EmpAccount",
                columns: table => new
                {
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AccountCreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AccountStatus = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpAccount", x => x.PhoneNumber);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    PartnerId = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    PartnerName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DateOfCooperation = table.Column<DateTime>(type: "datetime", nullable: false),
                    ManagerNumberPhone = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Office = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalHotel = table.Column<int>(type: "int", nullable: false),
                    PartnerStatus = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    PartnerNote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.PartnerId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    PhoneNumber = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    CusBirthDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    CusEmail = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CusGender = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    CusType = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CusNote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.PhoneNumber);
                    table.ForeignKey(
                        name: "FK_Customers_CusAccount_PhoneNumber",
                        column: x => x.PhoneNumber,
                        principalTable: "CusAccount",
                        principalColumn: "PhoneNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    PhoneNumber = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    EmpBirthDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    EmpEmail = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EmpGender = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    EmpIdentityCard = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Seniority = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CoefficientsSalary = table.Column<double>(type: "float", nullable: false),
                    EmpNote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.PhoneNumber);
                    table.ForeignKey(
                        name: "FK_Employees_EmpAccount_PhoneNumber",
                        column: x => x.PhoneNumber,
                        principalTable: "EmpAccount",
                        principalColumn: "PhoneNumber",
                        onDelete: ReferentialAction.Cascade);
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
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelStatus = table.Column<string>(type: "nvarchar(30)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingType = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    BookingStatus = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    CustomerPaymentMethods = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "date", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "date", nullable: false),
                    Required = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false),
                    CustomerID = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    BookingNote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Booking_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "PhoneNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Employees_PhoneNumber",
                        column: x => x.PhoneNumber,
                        principalTable: "Employees",
                        principalColumn: "PhoneNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    RestaurantID = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    RestaurantName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    RestaurantType = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    RestaurantDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.RestaurantID);
                    table.ForeignKey(
                        name: "FK_Restaurant_Hotel_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotel",
                        principalColumn: "HotelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomOfHotel",
                columns: table => new
                {
                    RoomOfHotelID = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    RoomAmount = table.Column<int>(type: "int", nullable: false),
                    BedAmount = table.Column<int>(type: "int", nullable: false),
                    PeopleAmount = table.Column<int>(type: "int", nullable: false),
                    PolicyApply = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyNotApply = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckInTime = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    CheckOutTime = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    RoomPriceForNight = table.Column<decimal>(type: "money", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomsCreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RoomOfHotelNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomOfHotel", x => x.RoomOfHotelID);
                    table.ForeignKey(
                        name: "FK_RoomOfHotel_Hotel_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotel",
                        principalColumn: "HotelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    BookingID = table.Column<int>(nullable: false),
                    RoomOfHotelID = table.Column<string>(nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NightAmount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    SpecialRequirements = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => new { x.BookingID, x.RoomOfHotelID });
                    table.ForeignKey(
                        name: "FK_BookingDetails_Booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "Booking",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingDetails_RoomOfHotel_RoomOfHotelID",
                        column: x => x.RoomOfHotelID,
                        principalTable: "RoomOfHotel",
                        principalColumn: "RoomOfHotelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CustomerID",
                table: "Booking",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PhoneNumber",
                table: "Booking",
                column: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_RoomOfHotelID",
                table: "BookingDetails",
                column: "RoomOfHotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_PartnerID",
                table: "Hotel",
                column: "PartnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_HotelID",
                table: "Restaurant",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomOfHotel_HotelID",
                table: "RoomOfHotel",
                column: "HotelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetails");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "RoomOfHotel");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "CusAccount");

            migrationBuilder.DropTable(
                name: "EmpAccount");

            migrationBuilder.DropTable(
                name: "Partners");
        }
    }
}
