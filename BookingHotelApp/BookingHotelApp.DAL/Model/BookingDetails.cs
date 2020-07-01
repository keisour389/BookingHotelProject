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
        public String HotelID { get; set; }
        public Hotel Hotel { get; set; }

        [Required]
        public String RoomID { get; set; }
        public Room Room { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int NumberOfNights { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public int SpecialRequirements { get; set; }
    }
}
