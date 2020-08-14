using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotelApp.DAL.Migrations
{
    public partial class BookingHotelDBUpdateVer50 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestaurantDescription",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "RestaurantType",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "EmpAddress",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmpBankCardDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmpBankCardID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmpBankCardType",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CusAddress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CusBankCardDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CusBankCardID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CusBankCardType",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CusIdentityCard",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "HotelCountry",
                table: "Hotel",
                newName: "Ward");

            migrationBuilder.RenameColumn(
                name: "HotelAddress",
                table: "Hotel",
                newName: "Street");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Hotel",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Hotel",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Hotel",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "CoefficientsSalary",
                table: "Employees",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Employees",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Employees",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Employees",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ward",
                table: "Employees",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "BookingDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_HotelID",
                table: "Restaurant",
                column: "HotelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "CoefficientsSalary",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Ward",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "BookingDetails");

            migrationBuilder.RenameColumn(
                name: "Ward",
                table: "Hotel",
                newName: "HotelCountry");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Hotel",
                newName: "HotelAddress");

            migrationBuilder.AddColumn<string>(
                name: "RestaurantDescription",
                table: "Hotel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RestaurantType",
                table: "Hotel",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpAddress",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EmpBankCardDate",
                table: "Employees",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmpBankCardID",
                table: "Employees",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpBankCardType",
                table: "Employees",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Employees",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CusAddress",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CusBankCardDate",
                table: "Customers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CusBankCardID",
                table: "Customers",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CusBankCardType",
                table: "Customers",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CusIdentityCard",
                table: "Customers",
                type: "nvarchar(20)",
                nullable: true);
        }
    }
}
