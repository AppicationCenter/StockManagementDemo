using CMSSystems.StockManagementDemo.Data.Base.IRepository;
using CMSSystems.StockManagementDemo.Data.DatabaseContexts;
using CMSSystems.StockManagementDemo.Data.IRepository;
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

        public UnitOfWork(CMSStockManagementDatabaseContext context, IVehicleRepository vehicleRepository, IStockAccessoryRepository stockAccessoryRepository,
            IImageRepository imageRepository)
        {
            this.context = context;
            this.VehicleRepository = vehicleRepository;
            this.StockAccessoryRepository = stockAccessoryRepository;
            this.ImageRepository = imageRepository;
        }

        public IVehicleRepository VehicleRepository { get; set; }

        public IStockAccessoryRepository StockAccessoryRepository { get; set; }

        public IImageRepository ImageRepository { get; set; }

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
            this.context.Dispose();
        }
    }
}
