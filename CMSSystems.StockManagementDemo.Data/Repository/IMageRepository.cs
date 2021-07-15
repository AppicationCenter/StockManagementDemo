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
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        public ImageRepository(CMSStockManagementDatabaseContext context) : base(context)
        {
        }
    }
}
