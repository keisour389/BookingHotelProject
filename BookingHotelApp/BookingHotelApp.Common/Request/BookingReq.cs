using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotelApp.Common.Request
{
    public class BookingReq
    {
        public int BookingID { get; set; }
        public String BookingType { get; set; }
        public DateTime BookingDate { get; set; }
        public String BookingStatus { get; set; }
        public int NumberOfPeople { get; set; }
        public String CustomerPaymentMethods { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public String Required { get; set; }
        public double TotalPrice { get; set; }
        public String CustomerID { get; set; }
        public String EmployeeID { get; set; }
        public String BookingNote { get; set; }
    }
}
