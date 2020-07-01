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

        public DbSet<Account> Account { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Partners> Partners { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<RoomOfHotel> RoomOfHotel { get; set; }
        public DbSet<BookingDetails> BookingDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Chỉnh đường dẫn CSDL ở đây
            optionsBuilder.UseSqlServer(@"Server=.;Initial Catalog=BookingHotelDB;Trusted_Connection=True;"); //Windows Authencation
            //optionsBuilder.UseSqlServer(@"Data Source =.\SQLEXPRESS; Initial Catalog = BookingHotelDB; Persist Security Info = True; User ID = sa; Password = sa;
            //Pooling = False; MultipleActiveResultSets = False; Encrypt = False; TrustServerCertificate = True"; //SQL Server Authencation
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Fluent-API
            //Tạo bảng quan hệ n-n giữa hotel và room
            modelBuilder.Entity<RoomOfHotel>().HasKey(pk => new { pk.HotelID, pk.RoomID }); // Khóa chính

            //Hotel
            modelBuilder.Entity<RoomOfHotel>()
                .HasOne<Hotel>(h => h.Hotel)
                .WithMany(roh => roh.RoomOfHotel)
                .HasForeignKey(fk => fk.HotelID);

            //Room
            modelBuilder.Entity<RoomOfHotel>()
                .HasOne<Room>(r => r.Room)
                .WithMany(roh => roh.RoomOfHotel)
                .HasForeignKey(fk => fk.RoomID);

            //Tạo bảng quan hệ n-n-n giữa booking, hotel và room
            modelBuilder.Entity<BookingDetails>().HasKey(pk => new { pk.BookingID, pk.HotelID, pk.RoomID }); // Khóa chính

            //Booking
            modelBuilder.Entity<BookingDetails>()
                .HasOne<Booking>(b => b.Booking)
                .WithMany(roh => roh.BookingDetails)
                .HasForeignKey(fk => fk.BookingID);

            //Hotel
            modelBuilder.Entity<BookingDetails>()
                .HasOne<Hotel>(h => h.Hotel)
                .WithMany(roh => roh.BookingDetails)
                .HasForeignKey(fk => fk.HotelID);

            //Room
            modelBuilder.Entity<BookingDetails>()
                .HasOne<Room>(r => r.Room)
                .WithMany(roh => roh.BookingDetails)
                .HasForeignKey(fk => fk.RoomID);
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
