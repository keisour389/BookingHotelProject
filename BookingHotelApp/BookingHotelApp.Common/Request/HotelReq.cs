using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotelApp.Common.Request
{
    public class HotelReq
    {
        public String HotelID { get; set; }
        public String HotelName { get; set; }
        public int Quality { get; set; }
        public DateTime HotelCreatedDate { get; set; }
        public String HotelPhoneNumber { get; set; }
        public String HotelEmail { get; set; }
        public String Street { get; set; }
        public String Ward { get; set; }
        public String District { get; set; }
        public String Province { get; set; }
        public String Country { get; set; }
        public String Image { get; set; }
        public String HotelDescription { get; set; }
        public String HotelStatus { get; set; }
        public float Rank { get; set; }
        public String HotelPaymentMethods { get; set; }
        public String PartnerID { get; set; }
        public String HotelNote { get; set; }
    }
}
