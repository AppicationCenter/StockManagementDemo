using CMSSystems.StockManagementDemo.Data.Base.IRepository;
using CMSSystems.StockManagementDemo.Data.IRepository;
using CMSSystems.StockManagementDemo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSSystems.StockManagementDemo.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IVehicleRepository VehicleRepository { get; set; }

        IStockAccessoryRepository StockAccessoryRepository { get; set; }

        IImageRepository ImageRepository { get; set; }

        Task<int> CommitAsync();

        int Commit();
    }
}
