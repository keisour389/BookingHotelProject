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

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Booking",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_PhoneNumber",
                table: "Booking",
                newName: "IX_Booking_EmployeeID");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerID",
                table: "Booking",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Customers_CustomerID",
                table: "Booking",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "PhoneNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Employees_EmployeeID",
                table: "Booking",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "PhoneNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Customers_CustomerID",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Employees_EmployeeID",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Booking",
                newName: "PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_EmployeeID",
                table: "Booking",
                newName: "IX_Booking_PhoneNumber");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerID",
                table: "Booking",
                type: "nvarchar(15)",
                nullable: true,
                oldClrType: typeof(string));

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
        }
    }
}
