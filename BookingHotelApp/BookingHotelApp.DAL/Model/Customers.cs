using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookingHotelApp.DAL.Model
{
    public class Customers
    {
        [Key]
        [ForeignKey("CusAccount")] //Khóa ngoại là bảng Account
        [Column("PhoneNumber")] //Tên cột
        [Required]
        public String PhoneNumber { get; set; }
        public CusAccount CusAccount { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public String LastName { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        [Required]
        public String FirstName { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime CusBirthDay { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String CusEmail { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        [Required]
        public String CusGender { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public String CusType { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public String CusNote { get; set; }

        public ICollection<Booking> Booking { get; set; } //Được sử dụng bởi bảng đặt phòng
    }
}
