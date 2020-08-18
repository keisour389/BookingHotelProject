using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotelApp.Common.Request
{
    public class RoomOfHotelReq
    {
        public String RoomOfHotelID { get; set; }
        public String RoomName { get; set; }
        public int RoomAmount { get; set; }
        public int BedAmount { get; set; }
        public int PeopleAmount { get; set; }
        public String PolicyApply { get; set; }
        public String PolicyNotApply { get; set; }
        public String CheckInTime { get; set; }
        public String CheckOutTime { get; set; }
        public double RoomPriceForNight { get; set; }
        public float Discount { get; set; }
        public String Image { get; set; }
        public DateTime RoomsCreatedDate { get; set; }
        public String RoomOfHotelNote { get; set; }
        public String HotelID { get; set; }
    }
}
