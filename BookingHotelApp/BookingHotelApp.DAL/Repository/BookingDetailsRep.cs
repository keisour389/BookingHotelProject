using BookingHotelApp.Common.DAL;
using BookingHotelApp.DAL.Model;
using LTCSDL.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingHotelApp.DAL.Repository
{
    public class BookingDetailsRep : GenericRepository<BookingHotelContext, BookingDetails>
    {
        public BookingDetailsRep()
        {
            Context = new BookingHotelContext();
        }
        public SingleResponse Remove(int bookingId, string hotelId, string roomId)
        {
            //Xét theo mã đặt, mã khách sạn, mã phòng
            var dataRemove = Context.BookingDetails.FirstOrDefault(data => data.BookingID == bookingId
                && data.HotelID == hotelId && data.RoomID == roomId);
            return base.Remove(dataRemove); //Gọi hàm remove từ đối tượng cha
        }
    }
}
