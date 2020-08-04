using BookingHotelApp.Common.DAL;
using BookingHotelApp.DAL.Model;
using LTCSDL.Common.Rsp;
using System.Collections.Generic;
using System.Linq;

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
        public object CustomerSearchRoomByKeyword(string keyword)
        {
            //Đối tượng để lưu kết quả
            List<object> resultList = new List<object>();
            //Xuất ra danh sách khách sạn phù hợp với từ khóa
            List<Hotel> hotelList = Context.Hotel.Where(value => value.HotelCountry.Contains(keyword) || value.HotelName.Contains(keyword)).ToList();

            //Gán giá phòng của từng khách sạn
            foreach (Hotel hotel in hotelList)
            {
                RoomOfHotel rOH = Context.RoomOfHotel.Where(value => value.HotelID == hotel.HotelID)
                    .OrderBy(value => value.RoomPriceForNight).FirstOrDefault(); //Sắp xếp từ trên xuống, lấy giá phòng rẻ nhất hiển thị
                //Kết quả của 1 khách sạn
                var result = new
                {
                    hotelId = hotel.HotelID,
                    hotelImage = hotel.Image,
                    hotelName = hotel.HotelName,
                    quality = hotel.Quality,
                    hotelAddress = hotel.HotelAddress,
                    hotelCountry = hotel.HotelCountry,
                    rank = hotel.Rank,
                    roomPriceForNight = rOH.RoomPriceForNight,
                    discount = rOH.Discount,
                    //Biến tự sinh
                    hotelPriceAfterDiscount = rOH.RoomPriceForNight * (1 - rOH.Discount)
                };
                //Lưu vào danh sách kết quả
                resultList.Add(result);
            }
            return resultList;
        }
    }
}
