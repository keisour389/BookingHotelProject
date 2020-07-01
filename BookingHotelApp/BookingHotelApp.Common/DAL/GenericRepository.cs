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
            set { _context = value; }
        }
        //Implement all methods on interface
        #region Implement
        public IQueryable<T> All
        {
            get { return _context.Set<T>(); }
        }

        public void Create(T table)
        {
            _context.Set<T>().Add(table);
            _context.SaveChanges();
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

        public void Update(T table)
        {
            _context.Set<T>().Update(table);
            _context.SaveChanges();
        }

        public void UpdateRange(List<T> listTable)
        {
            _context.Set<T>().UpdateRange(listTable);
            _context.SaveChanges();
        }

        #endregion
    }
}
