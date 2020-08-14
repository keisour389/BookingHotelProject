using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookingHotelApp.DAL.Model
{
    public class Restaurant
    {
        [Key]
        [Column(TypeName = "nvarchar(10)")]
        public String RestaurantID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public String RestaurantName {get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String RestaurantType { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Required]
        public String RestaurantDescription { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public String Note { get; set; }

        [Column("HotelID")]
        [ForeignKey("Hotel")]
        [Required]
        public String HotetID { get; set; }
        public Hotel Hotel { get; set; }

    }
}
