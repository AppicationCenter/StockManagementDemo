using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMSSystems.StockManagementDemo.Data.Base.IRepository
{
    public interface IRepositoryBase<T> where T : class
    {
        void Insert(T entity);

        T Find(object id);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");

        void Updated(T entity);

        void Delete(T entity);
    }
}
