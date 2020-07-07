using BookingHotelApp.Common.DAL;
using BookingHotelApp.DAL.Model;
using LTCSDL.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingHotelApp.DAL.Repository
{
    public class BookingRep : GenericRepository<BookingHotelContext, Booking>
    {
        public BookingRep()
        {
            Context = new BookingHotelContext();
        }
        public SingleResponse Remove(int bookingId)
        {
            var dataRemove = Context.Booking.FirstOrDefault(data => data.BookingID == bookingId);
            return base.Remove(dataRemove); //Gọi hàm remove từ đối tượng cha
        }
    }
}
