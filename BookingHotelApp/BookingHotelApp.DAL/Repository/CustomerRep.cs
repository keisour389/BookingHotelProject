using BookingHotelApp.Common.DAL;
using BookingHotelApp.DAL.Model;
using LTCSDL.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
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
            var dataRemove = Context.Customers.FirstOrDefault(data => data.PhoneNumber == customerId);
            return base.Remove(dataRemove); //Gọi hàm remove từ đối tượng cha
        }
        public SingleResponse GetBookingRoomByCustomrerID(string phoneNumber)
        {
            var result = new SingleResponse();
            var customerDetails = Context.Customers.Where(value => value.PhoneNumber == phoneNumber).FirstOrDefault();
            var bookingDetails = Context.Booking
                .Join(Context.BookingDetails, b => b.BookingID, bK => bK.BookingID, (b, bK) => new
                {
                    b.BookingID,
                    b.BookingDate,
                    b.BookingStatus,
                    b.CustomerPaymentMethods,
                    b.CheckInDate,
                    b.CheckOutDate,
                    b.TotalPrice,
                    b.CustomerName,
                    b.CustomerID, //Dùng để xét điều kiện
                    bK.RoomOfHotelID,
                    bK.NightAmount,
                    bK.Price,
                    bK.SpecialRequirements,
                })
                //Join với bảng room of hotel để lây thông tin phòng
                .Join(Context.RoomOfHotel, bD => bD.RoomOfHotelID, rOH => rOH.RoomOfHotelID, (bD, rOH) => new
                {
                    bD.BookingID,
                    bD.BookingDate,
                    bD.BookingStatus,
                    bD.CustomerPaymentMethods,
                    bD.CheckInDate,
                    bD.CheckOutDate,
                    bD.TotalPrice,
                    bD.CustomerName,
                    bD.CustomerID, //Dùng để xét điều kiện
                    bD.RoomOfHotelID,
                    bD.NightAmount,
                    bD.Price,
                    bD.SpecialRequirements,
                    rOH.RoomName,
                    rOH.BedAmount,
                    rOH.PeopleAmount,
                    rOH.CheckInTime,
                    rOH.CheckOutTime,
                    rOH.HotelID
                })
                .Join(Context.Hotel, bD => bD.HotelID, h => h.HotelID, (bD, h) => new
                {
                    bD.BookingID,
                    bD.BookingDate,
                    bD.BookingStatus,
                    bD.CustomerPaymentMethods,
                    bD.CheckInDate,
                    bD.CheckOutDate,
                    bD.TotalPrice,
                    bD.CustomerName,
                    bD.CustomerID, //Dùng để xét điều kiện
                    bD.RoomOfHotelID,
                    bD.NightAmount,
                    bD.Price,
                    bD.SpecialRequirements,
                    bD.RoomName,
                    bD.BedAmount,
                    bD.PeopleAmount,
                    bD.CheckInTime,
                    bD.CheckOutTime,
                    bD.HotelID,
                    h.HotelName
                }).Where(value => value.CustomerID == phoneNumber).ToList(); //Xuất ra danh sách đặt phòng của khách hàng
            var customerAndBookingInfo = new
            {
                CustomerDetails = customerDetails,
                BookingDetails = bookingDetails
            };
            result.Data = customerAndBookingInfo;
            return result;
        }
    }
}
