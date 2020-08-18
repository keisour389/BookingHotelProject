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
    [Migration("20200818150021_BookingHotelDBUpdateVer1.3")]
    partial class BookingHotelDBUpdateVer13
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("BookingStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CustomerID")
                        .IsRequired()
                        .HasColumnName("CustomerID")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("CustomerPaymentMethods")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("EmployeeID")
                        .HasColumnName("EmployeeID")
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal>("TotalPrice")
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

                    b.Property<string>("RoomOfHotelID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NightAmount")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("SpecialRequirements")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingID", "RoomOfHotelID");

                    b.HasIndex("RoomOfHotelID");

                    b.ToTable("BookingDetails");
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.CusAccount", b =>
                {
                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("AccountCreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("AccountStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhoneNumber");

                    b.ToTable("CusAccount");
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Customers", b =>
                {
                    b.Property<string>("PhoneNumber")
                        .HasColumnName("PhoneNumber")
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("CusBirthDay")
                        .HasColumnType("datetime");

                    b.Property<string>("CusEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CusGender")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("CusNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CusType")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("PhoneNumber");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.EmpAccount", b =>
                {
                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("AccountCreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("AccountStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhoneNumber");

                    b.ToTable("EmpAccount");
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Employees", b =>
                {
                    b.Property<string>("PhoneNumber")
                        .HasColumnName("PhoneNumber")
                        .HasColumnType("nvarchar(15)");

                    b.Property<double>("CoefficientsSalary")
                        .HasColumnType("float");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

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

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Seniority")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ward")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PhoneNumber");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Hotel", b =>
                {
                    b.Property<string>("HotelID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("District")
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

                    b.Property<string>("HotelStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartnerID")
                        .IsRequired()
                        .HasColumnName("PartnerID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Quality")
                        .HasColumnType("int");

                    b.Property<double>("Rank")
                        .HasColumnType("float");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ward")
                        .IsRequired()
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

                    b.Property<string>("PartnerStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("TotalHotel")
                        .HasColumnType("int");

                    b.HasKey("PartnerId");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Restaurant", b =>
                {
                    b.Property<string>("RestaurantID")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("HotetID")
                        .IsRequired()
                        .HasColumnName("HotelID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RestaurantType")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("RestaurantID");

                    b.HasIndex("HotetID");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.RoomOfHotel", b =>
                {
                    b.Property<string>("RoomOfHotelID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("BedAmount")
                        .HasColumnType("int");

                    b.Property<string>("CheckInTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("CheckOutTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<string>("HotelID")
                        .IsRequired()
                        .HasColumnName("HotelID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeopleAmount")
                        .HasColumnType("int");

                    b.Property<string>("PolicyApply")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyNotApply")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomAmount")
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RoomOfHotelNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RoomPriceForNight")
                        .HasColumnType("money");

                    b.Property<DateTime>("RoomsCreatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("RoomOfHotelID");

                    b.HasIndex("HotelID");

                    b.ToTable("RoomOfHotel");
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Booking", b =>
                {
                    b.HasOne("BookingHotelApp.DAL.Model.Customers", "Customers")
                        .WithMany("Booking")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

                    b.HasOne("BookingHotelApp.DAL.Model.RoomOfHotel", "RoomOfHotel")
                        .WithMany("BookingDetails")
                        .HasForeignKey("RoomOfHotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Customers", b =>
                {
                    b.HasOne("BookingHotelApp.DAL.Model.CusAccount", "CusAccount")
                        .WithMany("Customers")
                        .HasForeignKey("PhoneNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Employees", b =>
                {
                    b.HasOne("BookingHotelApp.DAL.Model.EmpAccount", "EmpAccount")
                        .WithMany("Employees")
                        .HasForeignKey("PhoneNumber")
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

            modelBuilder.Entity("BookingHotelApp.DAL.Model.Restaurant", b =>
                {
                    b.HasOne("BookingHotelApp.DAL.Model.Hotel", "Hotel")
                        .WithMany("Restaurant")
                        .HasForeignKey("HotetID")
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
                });
#pragma warning restore 612, 618
        }
    }
}
