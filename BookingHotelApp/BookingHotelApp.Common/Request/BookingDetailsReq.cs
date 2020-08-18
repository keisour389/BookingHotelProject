using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotelApp.Common.Request
{
    public class BookingDetailsReq
    {
        public int BookingID { get; set; }
        public String RoomOfHotelID { get; set; }
        public int NightAmount { get; set; }
        public int Price { get; set; }
        public String SpecialRequirements { get; set; }
    }
}
