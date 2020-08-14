using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotelApp.Common.Request
{
    public class RestaurantReq
    {
        public String RestaurantID { get; set; }
        public String RestaurantName { get; set; }
        public String RestaurantType { get; set; }
        public String RestaurantDescription { get; set; }
        public String Note { get; set; }
        public String HotetID { get; set; }
    }
}
