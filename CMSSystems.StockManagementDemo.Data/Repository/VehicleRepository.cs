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
    public class VehicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(CMSStockManagementDatabaseContext context) : base(context)
        {
        }
    }
}
