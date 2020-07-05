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
    public class CustomerSvc : GenericService<CustomerRep, Customers>
    {
        public SingleResponse CreateCustomer(CustomerReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            Customers cus = new Customers();
            //Gán
            cus.CustomerID = req.CustomerID;
            cus.LastName = req.LastName;
            cus.FirstName = req.FirstName;
            cus.CusBirthDay = req.CusBirthDay;
            cus.CusPhoneNumber = req.CusPhoneNumber;
            cus.CusEmail = req.CusEmail;
            cus.CusGender = req.CusGender;
            cus.CusAddress = req.CusAddress;
            cus.CusType = req.CusType;
            cus.CusIdentityCard = req.CusIdentityCard;
            cus.CusBankCardType = req.CusBankCardType;
            cus.CusBankCardID = req.CusBankCardID;
            cus.CusBankCardDate = req.CusBankCardDate;
            cus.CusNote = req.CusNote;
            //Tạo
            result = base.Create(cus);
            result.Data = cus;
            return result;
        }
        public SingleResponse UpdateCustomer(CustomerReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            Customers cus = new Customers();
            //Gán
            cus.CustomerID = req.CustomerID;
            cus.LastName = req.LastName;
            cus.FirstName = req.FirstName;
            cus.CusBirthDay = req.CusBirthDay;
            cus.CusPhoneNumber = req.CusPhoneNumber;
            cus.CusEmail = req.CusEmail;
            cus.CusGender = req.CusGender;
            cus.CusAddress = req.CusAddress;
            cus.CusType = req.CusType;
            cus.CusIdentityCard = req.CusIdentityCard;
            cus.CusBankCardType = req.CusBankCardType;
            cus.CusBankCardID = req.CusBankCardID;
            cus.CusBankCardDate = req.CusBankCardDate;
            cus.CusNote = req.CusNote;
            //Sửa
            result = base.Update(cus);
            result.Data = cus;
            return result;
        }
        public object SearchCustomerPagination(int size, int page, string keyWord)
        {
            //Khởi tạo các đối tượng
            //Ban đầu sẽ là tất cả giá trị
            var resultAfterFill = base.All; //All là tất cả giá trị từ generic service
            //Kiểm tra keyword
            if (!string.IsNullOrEmpty(keyWord))
            {
                //Lọc dữ kiệu
                resultAfterFill = base.All.Where(value => value.CustomerID.Contains(keyWord) //Kiểm tra theo mã khách hàng
                || (value.LastName.Contains(keyWord) || value.FirstName.Contains(keyWord))); //Kiểm tra theo họ hoặc theo tên
            }
            //Kết quả
            return base.SearchPagination(size, page, resultAfterFill);
        }
        public SingleResponse RemoveCustomer(string customerId)
        {
            var result = new SingleResponse();
            result = _rep.Remove(customerId);
            result.Data = customerId;
            return result;
        }
    }
}
