using BookingHotelApp.Common.DAL;
using BookingHotelApp.DAL.Model;
using LTCSDL.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingHotelApp.DAL.Repository
{
    public class RoomRep : GenericRepository<BookingHotelContext, Room>
    {
        public RoomRep()
        {
            Context = new BookingHotelContext();
        }
        public SingleResponse Remove(string roomId)
        {
            var dataRemove = Context.Room.FirstOrDefault(data => data.RoomID == roomId);
            return base.Remove(dataRemove); //Gọi hàm remove từ đối tượng cha
        }
    }
}
