using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookingHotelApp.DAL.Model
{
    public class BookingDetails
    {
        //Bảng này sử dụng n-n-n. Tạo fluent API bên context
        //3 khóa chính, đồng thời là khóa ngoại
        [Required]
        public int BookingID { get; set; }
        public Booking Booking { get; set; }

        [Required]
        public String RoomOfHotelID { get; set; }
        public RoomOfHotel RoomOfHotel { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String CustomerName { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int NightAmount { get; set; }

        [Column(TypeName = "float")]
        [Required]
        public int Price { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public int SpecialRequirements { get; set; }
    }
}
