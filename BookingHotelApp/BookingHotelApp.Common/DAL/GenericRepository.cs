using LTCSDL.Common.Rsp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BookingHotelApp.Common.DAL
{
    //T được xem như 1 class
    //C là 1 class được kế thừa từ DbContext
    public class GenericRepository<C, T> : IGenericRepository<T> where T : class where C : DbContext, new()
    {
        //Declare
        private C _context;
        //Declare get, set methods to _context
        public C Context
        {
            get { return _context; }
            set { _context = value; } //Value ở đây là DbContext
        }
        //Implement all methods on interface
        //Dưới đây là các phương thức thường sử dụng cho tất cả bảng
        //Các hàm sau khi implement sẽ được sử dụng bởi GenericService
        #region Implement
        public IQueryable<T> All
        {
            get { return _context.Set<T>(); }
        }

        public SingleResponse Create(T table)
        {
            var result = new SingleResponse();
            using (var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    _context.Set<T>().Add(table); //Create của generic repository
                    _context.SaveChanges();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    result.SetError(ex.StackTrace);
                    tran.Rollback();
                }
            }
            return result;
        }

        public void CreateRange(List<T> listTable)
        {
            _context.Set<T>().AddRange(listTable);
            _context.SaveChanges();
        }

        public IQueryable<T> Read(Expression<Func<T, bool>> parameter)
        {
            return _context.Set<T>().Where(parameter);
        }

        public SingleResponse Update(T table)
        {
            var result = new SingleResponse();
            using (var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    _context.Set<T>().Update(table);
                    _context.SaveChanges();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    result.SetError(ex.StackTrace);
                    tran.Rollback();
                }
            }
            return result;
        }

        public void UpdateRange(List<T> listTable)
        {
            _context.Set<T>().UpdateRange(listTable);
            _context.SaveChanges();
        }

        public SingleResponse Remove(T table)
        {
            var result = new SingleResponse();
            using (var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    _context.Set<T>().Remove(table);
                    _context.SaveChanges();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    result.SetError(ex.StackTrace);
                    tran.Rollback();
                }
            }
            return result;
        }

        public SingleResponse RemoveRange(List<T> listTable)
        {
            var result = new SingleResponse();
            using (var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    _context.Set<T>().RemoveRange(listTable);
                    _context.SaveChanges();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    result.SetError(ex.StackTrace);
                    tran.Rollback();
                }
            }
            return result;
        }
        #endregion
    }
}
