using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookingHotelApp.DAL.Model
{
    public class RoomOfHotel
    {
        [Key]
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public String RoomOfHotelID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public String RoomName { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int RoomAmount { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int BedAmount { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int PeopleAmount { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Required]
        public String PolicyApply { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Required]
        public String PolicyNotApply { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        [Required]
        public String CheckInTime { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        [Required]
        public String CheckOutTime { get; set; }

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

        [Column("HotelID")]
        [ForeignKey("Hotel")]
        [Required]
        public String HotelID { get; set; }
        public Hotel Hotel { get; set; }

        public ICollection<BookingDetails> BookingDetails { get; set; } //Được sử dụng bởi bảng chi tiết đặt phòng

    }
}
