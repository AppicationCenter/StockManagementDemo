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

        T Get(object id);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");

        void Update(T entity);

        void Delete(T entity);
    }
}
