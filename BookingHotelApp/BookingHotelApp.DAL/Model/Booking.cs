﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookingHotelApp.DAL.Model
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Khóa chính tự động tăng
        [Required]
        public int BookingID { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String BookingType { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime BookingDate { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int NumberOfPeople { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String CustomerPaymentMethods { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public String Required { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public double Total { get; set; }

        [ForeignKey("Customers")] //Khóa ngoại là bảng Customers
        [Column("CustomerID")] //Tên cột
        public String CustomerID { get; set; }
        public Customers Customers { get; set; }

        [ForeignKey("Employees")] //Khóa ngoại là bảng Employees
        [Column("EmployeeID")] //Tên cột
        public String EmployeeID { get; set; }
        public Employees Employees { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public String BookingNote { get; set; }

        public ICollection<BookingDetails> BookingDetails { get; set; } //Được sử dụng bởi bảng chi tiết đặt phòng
    }
}