using BookingHotelApp.Common.DAL;
using BookingHotelApp.DAL.Model;
using LTCSDL.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingHotelApp.DAL.Repository
{
    public class RestaurantRep : GenericRepository<BookingHotelContext, Restaurant>
    {
        public RestaurantRep()
        {
            Context = new BookingHotelContext();
        }

        public SingleResponse Remove(string restaurantId)
        {
            var dataRemove = Context.Restaurant.FirstOrDefault(data => data.RestaurantID == restaurantId); //Tìm ra dữ liệu cần xóa
            return base.Remove(dataRemove); //Gọi hàm xóa từ đối tượng cha
        }
    }
}
