using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookingHotelApp.DAL.Model
{
    public class RoomOfHotel
    {
        //Bảng này sử dụng n-n. Tạo fluent API bên context
        [Required]
        public String HotelID { get; set; }
        public Hotel Hotel { get; set; }

        [Required]
        public String RoomID { get; set; }
        public Room Room { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int RoomAmount { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public double RoomPriceForNight { get; set; }

        [Column(TypeName = "float")]
        [Required]
        public float Discount { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public String Image { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime RoomsCreatedDate { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public String RoomOfHotelNote { get; set; }

    }
}
