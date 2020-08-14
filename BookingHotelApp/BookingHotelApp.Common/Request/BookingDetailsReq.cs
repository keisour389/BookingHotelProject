using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotelApp.Common.Request
{
    public class BookingDetailsReq
    {
        public int BookingID { get; set; }
        public String HotelID { get; set; }
        public String RoomID { get; set; }
        public int NumberOfNights { get; set; }
        public int TotalPrice { get; set; }
        public int SpecialRequirements { get; set; }
    }
}
