using CMSSystems.StockManagementDemo.Data.Base.IRepository;
using CMSSystems.StockManagementDemo.Data.DatabaseContexts;
using CMSSystems.StockManagementDemo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSSystems.StockManagementDemo.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CMSStockManagementDatabaseContext context;

        public UnitOfWork(CMSStockManagementDatabaseContext context, IRepositoryBase<Vehicle> vehicleRepository, IRepositoryBase<StockAccessory> stockAccessoryRepository,
            IRepositoryBase<Image> imageRepository)
        {
            this.context = context;
            this.VehicleRepository = vehicleRepository;
            this.StockAccessoryRepository = stockAccessoryRepository;
            this.ImageRepository = imageRepository;
        }

        public IRepositoryBase<Vehicle> VehicleRepository { get; set; }

        public IRepositoryBase<StockAccessory> StockAccessoryRepository { get; set; }

        public IRepositoryBase<Image> ImageRepository { get; set; }

        public int Commit()
        {
            return this.context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await this.context.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
