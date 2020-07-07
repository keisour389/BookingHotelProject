using BookingHotelApp.Common.DAL;
using BookingHotelApp.DAL.Model;
using LTCSDL.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingHotelApp.DAL.Repository
{
    public class PartnerRep : GenericRepository<BookingHotelContext, Partners>
    {
        public PartnerRep()
        {
            Context = new BookingHotelContext();
        }
        public SingleResponse Remove(string partnerId)
        {
            var dataRemove = Context.Partners.FirstOrDefault(data => data.PartnerId == partnerId);
            return base.Remove(dataRemove); //Gọi hàm remove từ đối tượng cha
        }
    }
}
