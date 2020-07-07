using BookingHotelApp.Common.DAL;
using BookingHotelApp.DAL.Model;
using LTCSDL.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingHotelApp.DAL.Repository
{
    public class RoomOfHotelRep : GenericRepository<BookingHotelContext, RoomOfHotel>
    {
        public RoomOfHotelRep()
        {
            Context = new BookingHotelContext();
        }
        public SingleResponse Remove(string hotelId, string roomId)
        {
            //Xét cả mã phòng và mã khách sạn
            var dataRemove = Context.RoomOfHotel.FirstOrDefault(data => data.HotelID == roomId && data.RoomID == roomId);
            return base.Remove(dataRemove); //Gọi hàm remove từ đối tượng cha
        }
    }
}
