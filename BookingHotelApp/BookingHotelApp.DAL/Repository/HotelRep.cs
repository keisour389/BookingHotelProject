using BookingHotelApp.Common.DAL;
using BookingHotelApp.DAL.Model;
using LTCSDL.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingHotelApp.DAL.Repository
{
    public class HotelRep : GenericRepository<BookingHotelContext, Hotel>
    {
        public HotelRep()
        {
            Context = new BookingHotelContext();
        }
        public SingleResponse Remove(string hotelId)
        {
            var dataRemove = Context.Hotel.FirstOrDefault(data => data.HotelID == hotelId);
            return base.Remove(dataRemove); //Gọi hàm remove từ đối tượng cha
        }
    }
}
