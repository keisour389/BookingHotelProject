using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookingHotelApp.DAL.Model
{
    public class CusAccount
    {
        [Key]
        [Column(TypeName = "nvarchar(15)")]
        [Required]
        public String PhoneNumber { get; set; }

        //Lưu max vì mật khẩu phải băm ra
        [Column(TypeName = "nvarchar(max)")]
        [Required]
        public String Password { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public String AccountType { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime AccountCreatedDate { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String AccountStatus { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public String Note { get; set; }

        public ICollection<Customers> Customers { get; set; } //Được sử dụng bởi bảng khách hàng

    }
}
