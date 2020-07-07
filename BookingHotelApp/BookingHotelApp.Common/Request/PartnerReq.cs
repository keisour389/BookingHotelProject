using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotelApp.Common.Request
{
    public class PartnerReq
    {
        public String PartnerId { get; set; }
        public String PartnerName { get; set; }
        public DateTime DateOfCooperation { get; set; }
        public String ManagerNumberPhone { get; set; }
        public String Email { get; set; }
        public String Office { get; set; }
        public int TotalHotel { get; set; }
        public String PartnerStatus { get; set; }
        public String PartnerNote { get; set; }
    }
}
