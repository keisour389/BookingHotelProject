using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotelApp.DAL.Migrations
{
    public partial class BookingHotelDBUpdateVer10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    CusBirthDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    CusPhoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    CusEmail = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CusGender = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    CusAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CusType = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CusIdentityCard = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CusBankCardType = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CusBankCardID = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CusBankCardDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_Account_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Account",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    EmpBirthDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    EmpPhoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    EmpEmail = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EmpGender = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    EmpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpIdentityCard = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Seniority = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    EmpBankCardType = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    EmpBankCardID = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    EmpBankCardDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Account_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Account",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
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
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.PartnerId);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomID = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    RoomNote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CusAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CusBankCardDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CusBankCardID = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CusBankCardType = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CusBirthDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    CusEmail = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CusGender = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    CusIdentityCard = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CusPhoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    CusType = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customer_Account_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Account",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
