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
        [ForeignKey("Account")] //Khóa ngoại là bảng Account
        [Column("EmployeeID")] //Tên cột
        [Required]
        public String EmployeeID { get; set; }
        public Account Account { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public String LastName { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        [Required]
        public String FirstName { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime EmpBirthDay { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        [Required]
        public String EmpPhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String EmpEmail { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        [Required]
        public String EmpGender { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public String EmpAddress { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public String EmpIdentityCard { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String Position { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public String Seniority { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public int Salary { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public String EmpBankCardType { get; set; }


        [Column(TypeName = "nvarchar(20)")]
        public String EmpBankCardID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime EmpBankCardDate { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public String EmpNote { get; set; }

        public ICollection<Booking> Booking { get; set; } //Được sử dụng bởi bảng đặt phòng
    }
}
