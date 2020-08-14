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
    public class RestaurantSvc : GenericService<RestaurantRep, Restaurant>
    {
        public SingleResponse CreateRestaurant(RestaurantReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            Restaurant restaurant = new Restaurant();
            //Gán
            restaurant.RestaurantID = req.RestaurantID;
            restaurant.RestaurantName = req.RestaurantName;
            restaurant.RestaurantType = req.RestaurantType;
            restaurant.RestaurantDescription = req.RestaurantDescription;
            restaurant.Note = req.Note;
            restaurant.HotetID = req.HotetID;
            //Trả về
            result = base.Create(restaurant);
            result.Data = restaurant;
            return result;
        }
        public SingleResponse UpdateRestaurant(RestaurantReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            Restaurant restaurant = new Restaurant();
            //Gán
            restaurant.RestaurantID = req.RestaurantID;
            restaurant.RestaurantName = req.RestaurantName;
            restaurant.RestaurantType = req.RestaurantType;
            restaurant.RestaurantDescription = req.RestaurantDescription;
            restaurant.Note = req.Note;
            restaurant.HotetID = req.HotetID;
            //Trả về
            result = base.Update(restaurant);
            result.Data = restaurant;
            return result;
        }
        public object SearchRestaurantPagination(int size, int page, string keyWord)
        {
            //Khởi tạo các đối tượng
            //Ban đầu sẽ là tất cả giá trị
            var resultAfterFill = base.All; //All là tất cả giá trị từ generic service
            //Kiểm tra keyword
            if (!string.IsNullOrEmpty(keyWord))
            {
                //Lọc dữ kiệu
                resultAfterFill = base.All.Where(value => value.RestaurantID.Contains(keyWord) //Kiểm tra mã nhà hàng
                || value.RestaurantType.Contains(keyWord)); //Kiểm tra loại tài khoản
            }
            //Kết quả
            return base.SearchPagination(size, page, resultAfterFill);
        }

        public SingleResponse RemoveRestaurant(string restaurantId)
        {
            var result = new SingleResponse();
            //_rep là biến protected, và _rep được get từ D
            result = _rep.Remove(restaurantId); //Gọi lớp repository bởi vì mỗi điều kiện xóa khác nhau. Nên phải gọi cụ thể 1 repository
            result.Data = restaurantId;
            return result;
        }
    }
}
