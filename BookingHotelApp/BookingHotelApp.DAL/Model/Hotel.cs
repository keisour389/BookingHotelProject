using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookingHotelApp.DAL.Model
{
    public class Hotel
    {
        [Key]
        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public String HotelID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public String HotelName { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int Quality { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime HotelCreatedDate { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        [Required]
        public String HotelPhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String HotelEmail { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Required]
        public String HotelAddress { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String HotelCountry { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public String RestaurantType { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public String RestaurantDescription { get; set; }

        [Column(TypeName = "nvarchar(max)")] //Lấy đường dẫn lưu vào
        public String Image { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public String HotelDescription { get; set; }

        [Column(TypeName = "float")]
        public float Rank { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String HotelPaymentMethods { get; set; }

        [ForeignKey("Partners")] //Khóa ngoại là bảng Partners
        [Column("PartnerID")] //Tên cột
        [Required]
        public String PartnerID { get; set; }
        public Partners Partners { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public String HotelNote { get; set; }

        public ICollection<RoomOfHotel> RoomOfHotel { get; set; } //Được sử dụng bởi bảng phòng của khách sạn

        public ICollection<BookingDetails> BookingDetails { get; set; } //Được sử dụng bởi bảng chi tiết đặt phòng
    }
}
