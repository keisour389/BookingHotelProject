using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookingHotelApp.DAL.Model
{
    public class Partners
    {
        [Key]
        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public String PartnerId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String PartnerName { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime DateOfCooperation { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        [Required]
        public String ManagerNumberPhone { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String Email { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Required]
        public String Office { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public String PartnerNote { get; set; }

        public ICollection<Hotel> Hotel { get; set; } //Được sử dụng bởi bảng khách sạn

    }
}
