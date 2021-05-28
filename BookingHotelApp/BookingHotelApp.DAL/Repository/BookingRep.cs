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
        public SingleResponse SearchOrderByBookingDate(string hotelId, DateTime startDate, DateTime endDate)
        {
            var result = new SingleResponse();
            var query = Context.Hotel.Where(value => value.HotelID == hotelId)
                .Join(Context.RoomOfHotel, h => h.HotelID, rOH => rOH.HotelID, (h, rOH) => new
                {
                    rOH.RoomOfHotelID
                })
                .Join(Context.BookingDetails, newData => newData.RoomOfHotelID, bD => bD.RoomOfHotelID, (newData, bD) => new
                {
                    bD.BookingID,
                    bD.RoomOfHotelID,
                    bD.NightAmount,
                    bD.Price,
                    bD.SpecialRequirements
                })
                .Join(Context.Booking, newData => newData.BookingID, b => b.BookingID, (newData, b) => new
                {
                    b.BookingID,
                    b.BookingDate,
                    b.BookingStatus,
                    b.CustomerPaymentMethods,
                    b.CustomerName,
                    b.CheckInDate,
                    b.CheckOutDate,
                    b.TotalPrice,
                    b.CustomerID,
                    b.EmployeeID,
                    b.BookingNote,
                    newData.RoomOfHotelID,
                    newData.NightAmount,
                    newData.Price,
                    newData.SpecialRequirements
                })
                .Where(value => value.BookingDate >= startDate && value.BookingDate <= endDate); //Check by booking date
            result.Data = query;
            return result;
        }
    }
}
