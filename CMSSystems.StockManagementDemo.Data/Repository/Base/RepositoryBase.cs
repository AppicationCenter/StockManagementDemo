using CMSSystems.StockManagementDemo.Common.Helpers;
using CMSSystems.StockManagementDemo.Data.Base.IRepository;
using CMSSystems.StockManagementDemo.Data.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMSSystems.StockManagementDemo.Data.Base.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly CMSStockManagementDatabaseContext context;
        //protected readonly DbSet<T> table;

        public RepositoryBase(CMSStockManagementDatabaseContext context)
        {
            this.context = context;
            //this.table = this.context.Set<T>();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                var logMessage = $"{nameof(Delete)} entity must not be null";
                LogManager.LogError(logMessage);
                throw new ArgumentNullException(logMessage);
            }

            try
            {
                if (context.Entry(entity).State == EntityState.Detached)
                {
                    this.context.Set<T>().Attach(entity);
                }
                this.context.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.StackTrace);
                throw new Exception(ex.StackTrace);
            }
        }

        public T Get(object id)
        {
            return this.context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = this.context.Set<T>();

            try
            {
                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProperty);
                    }
                }


                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }
                else
                {
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.StackTrace);
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                LogManager.LogError($"{nameof(Insert)} entity must not be null");
                throw new ArgumentNullException($"{nameof(Insert)} entity must not be null");
            }

            this.context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                LogManager.LogError($"{nameof(Update)} entity must not be null");
                throw new ArgumentNullException($"{nameof(Update)} entity must not be null");
            }

            this.context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
