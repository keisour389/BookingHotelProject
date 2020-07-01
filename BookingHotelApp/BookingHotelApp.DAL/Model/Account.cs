using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookingHotelApp.DAL.Model
{
    public class Account
    {
        [Key]
        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public String UserName { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String Password { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public String AccountType { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime CreatedDateOfAT { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public String Note { get; set; }

        public ICollection<Customers> Customers { get; set; } //Được sử dụng bởi bảng khách hàng

        public ICollection<Employees> Employees { get; set; } //Được sử dụng bởi bảng nhân viên
    }
}
