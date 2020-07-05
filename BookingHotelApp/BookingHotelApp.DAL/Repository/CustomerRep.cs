using BookingHotelApp.Common.DAL;
using BookingHotelApp.DAL.Model;
using LTCSDL.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingHotelApp.DAL.Repository
{
    public class CustomerRep : GenericRepository<BookingHotelContext, Customers>
    {
        public CustomerRep()
        {
            Context = new BookingHotelContext();
        }
        public SingleResponse Remove(string customerId)
        {
            var dataRemove = Context.Customers.FirstOrDefault(data => data.CustomerID == customerId);
            return base.Remove(dataRemove); //Gọi hàm remove từ đối tượng cha
        }
    }
}
