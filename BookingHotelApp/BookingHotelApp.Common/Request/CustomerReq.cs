using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotelApp.Common.Request
{
    public class CustomerReq
    {
        public String PhoneNumber { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public DateTime CusBirthDay { get; set; }
        public String CusEmail { get; set; }
        public String CusGender { get; set; }
        public String CusType { get; set; }
        public String CusNote { get; set; }
    }
}
