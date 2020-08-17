using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotelApp.Common.Request
{
    public class AccountReq
    {
        public String PhoneNumber { get; set; }
        public String Password { get; set; }
        public String AccountType { get; set; }
        public DateTime AccountCreatedDate { get; set; }
        public String AccountStatus { get; set; }
        public String Note { get; set; }
    }
}
