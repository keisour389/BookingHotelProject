using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotelApp.DAL.Migrations
{
    public partial class BookingHotelDBUpdateVer10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Customers_CustomerID",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Employees_PhoneNumber",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CusAccount_Username",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmpAccount_Username",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "PhoneNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "PhoneNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Customers_CustomerID",
                table: "Booking",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "PhoneNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Employees_PhoneNumber",
                table: "Booking",
                column: "PhoneNumber",
                principalTable: "Employees",
                principalColumn: "PhoneNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CusAccount_PhoneNumber",
                table: "Customers",
                column: "PhoneNumber",
                principalTable: "CusAccount",
                principalColumn: "PhoneNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmpAccount_PhoneNumber",
                table: "Employees",
                column: "PhoneNumber",
                principalTable: "EmpAccount",
                principalColumn: "PhoneNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Customers_CustomerID",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Employees_PhoneNumber",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CusAccount_PhoneNumber",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmpAccount_PhoneNumber",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Employees",
                type: "nvarchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Customers",
                type: "nvarchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Username");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Customers_CustomerID",
                table: "Booking",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Employees_PhoneNumber",
                table: "Booking",
                column: "PhoneNumber",
                principalTable: "Employees",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CusAccount_Username",
                table: "Customers",
                column: "Username",
                principalTable: "CusAccount",
                principalColumn: "PhoneNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmpAccount_Username",
                table: "Employees",
                column: "Username",
                principalTable: "EmpAccount",
                principalColumn: "PhoneNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
