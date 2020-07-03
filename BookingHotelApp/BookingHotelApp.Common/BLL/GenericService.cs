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
            var result = new SingleResponse();

            try
            {
                var now = DateTime.Now;
                _rep.Create(table); //?
            }
            catch (Exception ex)
            {
                result.SetError(ex.StackTrace);
            }

            return result;
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

        public IQueryable<T> Read(Expression<Func<T, bool>> parameter)
        {
            return _rep.Read(parameter);
        }

        public SingleResponse Update(T table)
        {
            var result = new SingleResponse();

            try
            {
                _rep.Update(table);
            }
            catch (Exception ex)
            {
                result.SetError(ex.StackTrace);
            }

            return result;
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
        #endregion
    }
}
