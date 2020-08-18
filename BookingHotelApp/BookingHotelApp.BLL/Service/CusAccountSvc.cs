using BookingHotelApp.Common;
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
    public class CusAccountSvc : GenericService<CusAccountRep, CusAccount>
    {
        public SingleResponse CreateAccount(AccountReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            CusAccount account = new CusAccount();
            //Gán
            account.PhoneNumber = req.PhoneNumber;
            account.Password = PasswordHasher.HashPassword(req.Password);
            account.AccountType = req.AccountType;
            account.AccountCreatedDate = req.AccountCreatedDate;
            account.AccountStatus = req.AccountStatus;
            account.Note = req.Note;
            //Trả về
            result = base.Create(account); //base gọi lớp cha
            result.Data = account;
            return result;
        }
        public SingleResponse UpdateAccount(AccountReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            CusAccount account = new CusAccount();
            //Gán
            account.PhoneNumber = req.PhoneNumber;
            account.Password = req.Password;
            account.AccountType = req.AccountType;
            account.AccountCreatedDate = req.AccountCreatedDate;
            account.AccountStatus = req.AccountStatus;
            account.Note = req.Note;
            //Trả về
            result = base.Update(account);
            result.Data = account;
            return result;
        }
        public object SearchAccountPagination(int size, int page, string keyWord)
        {
            //Khởi tạo các đối tượng
            //Ban đầu sẽ là tất cả giá trị
            var resultAfterFill = base.All; //All là tất cả giá trị từ generic service
            //Kiểm tra keyword
            if (!string.IsNullOrEmpty(keyWord))
            {
                //Lọc dữ kiệu
                resultAfterFill = base.All.Where(value => value.PhoneNumber.Contains(keyWord) //Kiểm tra theo người dùng
                || value.AccountStatus.Contains(keyWord)); //Kiểm tra tình trạng tài khoản
            }
            //Kết quả
            return base.SearchPagination(size, page, resultAfterFill);
        }
        public SingleResponse RemoveAccount(string userName)
        {
            var result = new SingleResponse();
            //_rep là biến protected, và _rep được get từ D
            result = _rep.Remove(userName); //Gọi lớp repository bởi vì mỗi điều kiện xóa khác nhau. Nên phải gọi cụ thể 1 repository
            result.Data = userName;
            return result;
        }

        public SingleResponse ValidateUser(UserReq req)
        {
            var result = new SingleResponse();
            var search = base.All.Where(value => value.PhoneNumber == req.Username
                && value.Password == PasswordHasher.HashPassword(req.Password))
                .FirstOrDefault();
            result.Data = search;
            return result;
        }
    }
}
