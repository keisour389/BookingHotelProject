using BookingHotelApp.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotelApp.DAL
{
    public class BookingHotelContext : DbContext
    {
        public BookingHotelContext()
        {

        }
        public BookingHotelContext(DbContextOptions<BookingHotelContext> options)
           : base(options)
        {
        }

        public DbSet<CusAccount> CusAccount { get; set; }
        public DbSet<EmpAccount> EmpAccount { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Partners> Partners { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<RoomOfHotel> RoomOfHotel { get; set; }
        public DbSet<BookingDetails> BookingDetails { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Chỉnh đường dẫn CSDL ở đây
            //optionsBuilder.UseSqlServer(@"Server=tcp:bookinghotelserver.database.windows.net,1433;Initial Catalog=BookingHotelApp_db;Persist Security Info=False;
            //User ID=keisour389;Password=Banaccroi123;MultipleActiveResultSets=False;Encrypt=True;
            //TrustServerCertificate=False;Connection Timeout=30;");
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-6VBT9BQ;Initial Catalog=BookingHotelDB;Trusted_Connection=True;"); //Windows Authencation
            //optionsBuilder.UseSqlServer(@"Data Source =.\SQLEXPRESS; Initial Catalog = BookingHotelDB; Persist Security Info = True; User ID = sa; Password = sa;
            //Pooling = False; MultipleActiveResultSets = False; Encrypt = False; TrustServerCertificate = True"; //SQL Server Authencation
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Fluent-API

            //Tạo bảng quan hệ n-n giữa booking, room of hotel
            modelBuilder.Entity<BookingDetails>().HasKey(pk => new { pk.BookingID, pk.RoomOfHotelID }); // Khóa chính

            //Booking
            modelBuilder.Entity<BookingDetails>()
                .HasOne<Booking>(bD => bD.Booking)
                .WithMany(b => b.BookingDetails)
                .HasForeignKey(fk => fk.BookingID);

            //Hotel
            modelBuilder.Entity<BookingDetails>()
                .HasOne<RoomOfHotel>(bD => bD.RoomOfHotel)
                .WithMany(roh => roh.BookingDetails)
                .HasForeignKey(fk => fk.RoomOfHotelID);
        }
    }
}


///Sử dụng migration (Tools -> Nuget Package Manager -> Package Manager Console)
///Chỉnh default project and set start up project là BookingHotelApp.DAL
///Bước 1
///Tạo mới migration: add-migration BookingHotelDB
///Bước 2
///Chuyển dữ liệu qua database: update-database –verbose
///Lưu ý: Nếu muốn update khi sửa database thì khi add-migration tên phải khác lần trước. Rồi làm lại từng bước
