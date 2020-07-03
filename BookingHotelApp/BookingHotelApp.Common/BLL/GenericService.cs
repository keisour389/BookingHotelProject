using BookingHotelApp.Common.DAL;
using LTCSDL.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BookingHotelApp.Common.BLL
{
    public class GenericService<D, T> : IGenericService<T> where T : class where D : IGenericRepository<T>, new()
    {
        //Declare
        protected D _rep;

        public GenericService()
        {
            _rep = new D();
        }
        #region Implement
        public IQueryable<T> All
        {
            get
            {
                return _rep.All;
            }
        }

        public virtual SingleResponse Create(T table)
        {
            return _rep.Create(table); //Service gọi hàm từ Repository
        }

        public MultipleResponse CreateRange(List<T> listTable)
        {
            var result = new MultipleResponse();

            try
            {
                _rep.CreateRange(listTable);
            }
            catch (Exception ex)
            {
                result.SetError(ex.StackTrace);
            }

            return result;
        }

        //IQueryable<T> với T là table. Result được lọc qua bằng keyword sau đó truyền vào
        public object SearchPagination(int size, int page, IQueryable<T> resultAfterFill)
        {
            //Độ dời
            int offset = (page - 1) * size;
            //Tổng số dữ liệu
            int total = resultAfterFill.Count();
            //Tổng số trang
            //Ví dụ: 12 DL / Size 5 thì bằng 2 sẽ dư 2. Do đó phải có 3 trang để chứa đủ 12 DL
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            //Dữ liệu theo trang
            var data = resultAfterFill.Skip(offset).Take(size).ToList(); //Trả về danh sách
            var result = new
            {
                Data = data,
                totalRecords = total,
                Page = page,
                Size = size,
                TotalPages = totalPage
            };
            return result;
        }
        public SingleResponse Update(T table)
        {
            return _rep.Update(table); //Service gọi hàm từ Repository
        }

        public MultipleResponse UpdateRange(List<T> listTable)
        {
            var result = new MultipleResponse();

            try
            {
                _rep.UpdateRange(listTable);
            }
            catch (Exception ex)
            {
                result.SetError(ex.StackTrace);
            }

            return result;
        }

        public IQueryable<T> Read(Expression<Func<T, bool>> parameter)
        {
            return _rep.Read(parameter);
        }

        #endregion
    }
}
