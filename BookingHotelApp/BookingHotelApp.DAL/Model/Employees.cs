using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookingHotelApp.DAL.Model
{
    public class Employees
    {
        [Key]
        [ForeignKey("EmpAccount")] //Khóa ngoại là bảng Account
        [Column("PhoneNumber")] //Tên cột
        [Required]
        public String PhoneNumber { get; set; }
        public EmpAccount EmpAccount { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public String LastName { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        [Required]
        public String FirstName { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime EmpBirthDay { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String EmpEmail { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        [Required]
        public String EmpGender { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Required]
        public String Street { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String Ward { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String District { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String Province { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String Country { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public String EmpIdentityCard { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String Position { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public String Seniority { get; set; }

        [Column(TypeName = "float")]
        [Required]
        public float CoefficientsSalary { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public String EmpNote { get; set; }

        public ICollection<Booking> Booking { get; set; } //Được sử dụng bởi bảng đặt phòng
    }
}
