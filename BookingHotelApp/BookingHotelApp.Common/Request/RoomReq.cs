using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotelApp.Common.Request
{
    public class RoomReq
    {
        public String RoomID { get; set; }
        public String RoomName { get; set; }
        public String RoomType { get; set; }
        public String RoomNote { get; set; }
    }
}
