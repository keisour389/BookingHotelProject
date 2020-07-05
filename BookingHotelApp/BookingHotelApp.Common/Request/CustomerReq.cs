using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotelApp.Common.Request
{
    public class CustomerReq
    {
        public String CustomerID { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public DateTime CusBirthDay { get; set; }
        public String CusPhoneNumber { get; set; }
        public String CusEmail { get; set; }
        public String CusGender { get; set; }
        public String CusAddress { get; set; }
        public String CusType { get; set; }
        public String CusIdentityCard { get; set; }
        public String CusBankCardType { get; set; }
        public String CusBankCardID { get; set; }
        public DateTime CusBankCardDate { get; set; }
        public String CusNote { get; set; }
    }
}
