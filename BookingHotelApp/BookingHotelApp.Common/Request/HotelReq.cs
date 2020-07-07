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
        public String HotelAddress { get; set; }
        public String HotelCountry { get; set; }
        public String RestaurantType { get; set; }
        public String RestaurantDescription { get; set; }
        public String Image { get; set; }
        public String HotelDescription { get; set; }
        public String HotelStatus { get; set; }
        public float Rank { get; set; }
        public String HotelPaymentMethods { get; set; }
        public String PartnerID { get; set; }
        public String HotelNote { get; set; }
    }
}
