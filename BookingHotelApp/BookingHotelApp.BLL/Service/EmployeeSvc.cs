﻿using BookingHotelApp.Common.BLL;
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
    public class EmployeeSvc : GenericService<EmployeeRep, Employees>
    {
        public SingleResponse CreateEmployee(EmployeeReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            Employees emp = new Employees();
            //Gán
            emp.EmployeeID = req.EmployeeID;
            emp.LastName = req.LastName;
            emp.FirstName = req.FirstName;
            emp.EmpBirthDay = req.EmpBirthDay;
            emp.EmpPhoneNumber = req.EmpPhoneNumber;
            emp.EmpEmail = req.EmpEmail;
            emp.EmpGender = req.EmpGender;
            emp.EmpAddress = req.EmpAddress;
            emp.EmpIdentityCard = req.EmpIdentityCard;
            emp.Position = req.Position;
            emp.Seniority = req.Seniority;
            emp.Salary = req.Salary;
            emp.EmpBankCardType = req.EmpBankCardType;
            emp.EmpBankCardID = req.EmpBankCardID;
            emp.EmpBankCardDate = req.EmpBankCardDate;
            emp.EmpNote = req.EmpNote;
            //Tạo
            result = base.Create(emp);
            result.Data = emp;
            return result;
        }
        public SingleResponse UpdateEmployee(EmployeeReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            Employees emp = new Employees();
            //Gán
            emp.EmployeeID = req.EmployeeID;
            emp.LastName = req.LastName;
            emp.FirstName = req.FirstName;
            emp.EmpBirthDay = req.EmpBirthDay;
            emp.EmpPhoneNumber = req.EmpPhoneNumber;
            emp.EmpEmail = req.EmpEmail;
            emp.EmpGender = req.EmpGender;
            emp.EmpAddress = req.EmpAddress;
            emp.EmpIdentityCard = req.EmpIdentityCard;
            emp.Position = req.Position;
            emp.Seniority = req.Seniority;
            emp.Salary = req.Salary;
            emp.EmpBankCardType = req.EmpBankCardType;
            emp.EmpBankCardID = req.EmpBankCardID;
            emp.EmpBankCardDate = req.EmpBankCardDate;
            emp.EmpNote = req.EmpNote;
            //Sửa
            result = base.Update(emp);
            result.Data = emp;
            return result;
        }
        public object SearchEmployeePagination(int size, int page, string keyWord)
        {
            //Khởi tạo các đối tượng
            //Ban đầu sẽ là tất cả giá trị
            var resultAfterFill = base.All; //All là tất cả giá trị từ generic service
            //Kiểm tra keyword
            if (!string.IsNullOrEmpty(keyWord))
            {
                //Lọc dữ kiệu
                resultAfterFill = base.All.Where(value => value.EmployeeID.Contains(keyWord) //Kiểm tra theo mã nhân viên
                || (value.LastName.Contains(keyWord) || value.FirstName.Contains(keyWord))); //Kiểm tra theo họ hoặc theo tên
            }
            //Kết quả
            return base.SearchPagination(size, page, resultAfterFill);
        }
        public SingleResponse RemoveEmployee(string employeeId)
        {
            var result = new SingleResponse();
            result = _rep.Remove(employeeId); //Gọi lớp repository bởi vì mỗi điều kiện xóa khác nhau. Nên phải gọi cụ thể 1 repository
            result.Data = employeeId;
            return result;
        }
    }
}