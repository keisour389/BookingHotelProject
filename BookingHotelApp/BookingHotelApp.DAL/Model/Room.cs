using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookingHotelApp.DAL.Model
{
    public class Room
    {
        [Key]
        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public String RoomID { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String RoomType { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public String RoomNote { get; set; }

        public ICollection<RoomOfHotel> RoomOfHotel { get; set; } //Được sử dụng bởi bảng phòng của khách sạn

        public ICollection<BookingDetails> BookingDetails { get; set; } //Được sử dụng bởi bảng chi tiết đặt phòng
    }
}
