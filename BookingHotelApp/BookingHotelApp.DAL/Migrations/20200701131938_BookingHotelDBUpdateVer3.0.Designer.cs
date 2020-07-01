﻿// <auto-generated />
using System;
using BookingHotelApp.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookingHotelApp.DAL.Migrations
{
    [DbContext(typeof(BookingHotelContext))]
    [Migration("20200701131938_BookingHotelDBUpdateVer3.0")]
    partial class BookingHotelDBUpdateVer30
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Account", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CreatedDateOfAT")
                        .HasColumnType("datetime");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("UserName");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Booking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime");

                    b.Property<string>("BookingNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CustomerID")
                        .HasColumnName("CustomerID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CustomerPaymentMethods")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("EmployeeID")
                        .HasColumnName("EmployeeID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("int");

                    b.Property<string>("Required")
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Total")
                        .HasColumnType("money");

                    b.HasKey("BookingID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.BookingDetails", b =>
                {
                    b.Property<int>("BookingID")
                        .HasColumnType("int");

                    b.Property<string>("HotelID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("RoomID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("BookingAmount")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfNights")
                        .HasColumnType("int");

                    b.Property<string>("SpecialRequirements")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingID", "HotelID", "RoomID");

                    b.HasIndex("HotelID");

                    b.HasIndex("RoomID");

                    b.ToTable("BookingDetails");
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Customers", b =>
                {
                    b.Property<string>("CustomerID")
                        .HasColumnName("CustomerID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CusAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CusBankCardDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CusBankCardID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CusBankCardType")
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CusBirthDay")
                        .HasColumnType("datetime");

                    b.Property<string>("CusEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CusGender")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("CusIdentityCard")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CusNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CusPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("CusType")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Employees", b =>
                {
                    b.Property<string>("EmployeeID")
                        .HasColumnName("EmployeeID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("EmpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EmpBankCardDate")
                        .HasColumnType("datetime");

                    b.Property<string>("EmpBankCardID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("EmpBankCardType")
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("EmpBirthDay")
                        .HasColumnType("datetime");

                    b.Property<string>("EmpEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmpGender")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("EmpIdentityCard")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("EmpNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("money");

                    b.Property<string>("Seniority")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Hotel", b =>
                {
                    b.Property<string>("HotelID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("HotelAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("HotelCreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("HotelDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HotelNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelPaymentMethods")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("HotelPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartnerID")
                        .IsRequired()
                        .HasColumnName("PartnerID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Quality")
                        .HasColumnType("int");

                    b.Property<double>("Rank")
                        .HasColumnType("float");

                    b.Property<string>("RestaurantDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantType")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("HotelID");

                    b.HasIndex("PartnerID");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Partners", b =>
                {
                    b.Property<string>("PartnerId")
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("DateOfCooperation")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ManagerNumberPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Office")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PartnerNote")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PartnerId");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Room", b =>
                {
                    b.Property<string>("RoomID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("RoomNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("RoomID");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.RoomOfHotel", b =>
                {
                    b.Property<string>("HotelID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("RoomID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomAmount")
                        .HasColumnType("int");

                    b.Property<string>("RoomOfHotelNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RoomPriceForNight")
                        .HasColumnType("money");

                    b.Property<DateTime>("RoomsCreatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("HotelID", "RoomID");

                    b.HasIndex("RoomID");

                    b.ToTable("RoomOfHotel");
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Booking", b =>
                {
                    b.HasOne("BookingHotelApp.DAL.Model.Customers", "Customers")
                        .WithMany("Booking")
                        .HasForeignKey("CustomerID");

                    b.HasOne("BookingHotelApp.DAL.Model.Employees", "Employees")
                        .WithMany("Booking")
                        .HasForeignKey("EmployeeID");
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.BookingDetails", b =>
                {
                    b.HasOne("BookingHotelApp.DAL.Model.Booking", "Booking")
                        .WithMany("BookingDetails")
                        .HasForeignKey("BookingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingHotelApp.DAL.Model.Hotel", "Hotel")
                        .WithMany("BookingDetails")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingHotelApp.DAL.Model.Room", "Room")
                        .WithMany("BookingDetails")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Customers", b =>
                {
                    b.HasOne("BookingHotelApp.DAL.Model.Account", "Account")
                        .WithMany("Customers")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Employees", b =>
                {
                    b.HasOne("BookingHotelApp.DAL.Model.Account", "Account")
                        .WithMany("Employees")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Hotel", b =>
                {
                    b.HasOne("BookingHotelApp.DAL.Model.Partners", "Partners")
                        .WithMany("Hotel")
                        .HasForeignKey("PartnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.RoomOfHotel", b =>
                {
                    b.HasOne("BookingHotelApp.DAL.Model.Hotel", "Hotel")
                        .WithMany("RoomOfHotel")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingHotelApp.DAL.Model.Room", "Room")
                        .WithMany("RoomOfHotel")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
