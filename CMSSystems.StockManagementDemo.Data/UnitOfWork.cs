using CMSSystems.StockManagementDemo.Data.Base.IRepository;
using CMSSystems.StockManagementDemo.Data.DatabaseContexts;
using CMSSystems.StockManagementDemo.Data.IRepository;
using CMSSystems.StockManagementDemo.Data.Repository;
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
        private IVehicleRepository vehicleRepository;
        private IStockAccessoryRepository stockAccessoryRepository;
        private IImageRepository imageRepository;

        public UnitOfWork(CMSStockManagementDatabaseContext context)
        {
            this.context = context;
        }

        public IVehicleRepository VehicleRepository 
        {
            get
            {
                if (this.vehicleRepository == null)
                {
                    this.vehicleRepository = new VehicleRepository(this.context);
                }

                return this.vehicleRepository;
            }
        }

        public IStockAccessoryRepository StockAccessoryRepository
        {
            get
            {
                if (this.stockAccessoryRepository == null)
                {
                    this.stockAccessoryRepository = new StockAccessoryRepository(this.context);
                }

                return this.stockAccessoryRepository;
            }
        }

        public IImageRepository ImageRepository
        {
            get
            {
                if (this.imageRepository == null)
                {
                    this.imageRepository = new ImageRepository(this.context);
                }

                return this.imageRepository;
            }
        }

        public int Commit()
        {
            try
            {
                return this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Log exception
                throw;
            }
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
