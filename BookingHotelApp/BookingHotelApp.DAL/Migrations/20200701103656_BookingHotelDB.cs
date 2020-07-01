using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotelApp.DAL.Migrations
{
    public partial class BookingHotelDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CreatedDateOfAT = table.Column<DateTime>(type: "datetime", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
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
                    CusIdentityCard = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CusBankCardType = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CusBankCardID = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CusBankCardDate = table.Column<DateTime>(type: "datetime", nullable: false),
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
