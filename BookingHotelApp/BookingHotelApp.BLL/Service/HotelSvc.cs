using BookingHotelApp.Common.BLL;
using BookingHotelApp.Common.Request;
using BookingHotelApp.DAL.Model;
using BookingHotelApp.DAL.Repository;
using LTCSDL.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingHotelApp.BLL.Service
{
    public class HotelSvc : GenericService<HotelRep, Hotel>
    {
        public SingleResponse CreateHotel(HotelReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            Hotel hotel = new Hotel();
            //Gán
            hotel.HotelID = req.HotelID;
            hotel.HotelName = req.HotelName;
            hotel.Quality = req.Quality;
            hotel.HotelCreatedDate = req.HotelCreatedDate;
            hotel.HotelPhoneNumber = req.HotelPhoneNumber;
            hotel.HotelEmail = req.HotelEmail;
            hotel.HotelAddress = req.HotelAddress;
            hotel.HotelCountry = req.HotelCountry;
            hotel.RestaurantType = req.RestaurantType;
            hotel.RestaurantDescription = req.RestaurantDescription;
            hotel.Image = req.Image;
            hotel.HotelDescription = req.HotelDescription;
            hotel.HotelStatus = req.HotelStatus;
            hotel.Rank = req.Rank;
            hotel.HotelPaymentMethods = req.HotelPaymentMethods;
            hotel.PartnerID = req.PartnerID;
            hotel.HotelNote = req.HotelNote;
            //Trả về
            result = base.Create(hotel); //base gọi lớp cha
            result.Data = hotel;
            return result;
        }
        public SingleResponse UpdateHotel(HotelReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            Hotel hotel = new Hotel();
            //Gán
            hotel.HotelID = req.HotelID;
            hotel.HotelName = req.HotelName;
            hotel.Quality = req.Quality;
            hotel.HotelCreatedDate = req.HotelCreatedDate;
            hotel.HotelPhoneNumber = req.HotelPhoneNumber;
            hotel.HotelEmail = req.HotelEmail;
            hotel.HotelAddress = req.HotelAddress;
            hotel.HotelCountry = req.HotelCountry;
            hotel.RestaurantType = req.RestaurantType;
            hotel.RestaurantDescription = req.RestaurantDescription;
            hotel.Image = req.Image;
            hotel.HotelDescription = req.HotelDescription;
            hotel.HotelStatus = req.HotelStatus;
            hotel.Rank = req.Rank;
            hotel.HotelPaymentMethods = req.HotelPaymentMethods;
            hotel.PartnerID = req.PartnerID;
            hotel.HotelNote = req.HotelNote;
            //Trả về
            result = base.Update(hotel); //base gọi lớp cha
            result.Data = hotel;
            return result;
        }
        public object SearchHotelPagination(int size, int page, string keyWord)
        {
            //Khởi tạo các đối tượng
            //Ban đầu sẽ là tất cả giá trị
            var resultAfterFill = base.All; //All là tất cả giá trị từ generic service
            //Kiểm tra keyword
            if (!string.IsNullOrEmpty(keyWord))
            {
                //Lọc dữ kiệu
                resultAfterFill = base.All.Where(value => value.HotelID.Contains(keyWord) //Kiểm tra theo mã khách sạn
                || value.HotelName.Contains(keyWord)); //Kiểm tra theo tên
            }
            //Kết quả
            return base.SearchPagination(size, page, resultAfterFill);
        }

        public SingleResponse RemoveHotel(string hotelId)
        {
            var result = new SingleResponse();
            result = _rep.Remove(hotelId); //Gọi lớp repository bởi vì mỗi điều kiện xóa khác nhau. Nên phải gọi cụ thể 1 repository
            result.Data = hotelId;
            return result;
        }
    }
}
