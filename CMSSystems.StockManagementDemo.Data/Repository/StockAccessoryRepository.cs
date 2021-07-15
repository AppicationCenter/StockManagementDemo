using CMSSystems.StockManagementDemo.Data.Base.Repository;
using CMSSystems.StockManagementDemo.Data.DatabaseContexts;
using CMSSystems.StockManagementDemo.Data.IRepository;
using CMSSystems.StockManagementDemo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSSystems.StockManagementDemo.Data.Repository
{
    public class StockAccessoryRepository : RepositoryBase<StockAccessory>, IStockAccessoryRepository
    {
        public StockAccessoryRepository(CMSStockManagementDatabaseContext context) : base(context)
        {
        }
    }
}
