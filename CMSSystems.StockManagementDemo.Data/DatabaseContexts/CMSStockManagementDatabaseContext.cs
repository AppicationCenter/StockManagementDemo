using CMSSystems.StockManagementDemo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSSystems.StockManagementDemo.Data.DatabaseContexts
{
    public class CMSStockManagementDatabaseContext : DbContext
    {
        public CMSStockManagementDatabaseContext(DbContextOptions<CMSStockManagementDatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        var connectionString = ConfigurationManager.ConnectionStrings["CMSStockManagementDbConnectioString"].ConnectionString;
        //        optionsBuilder.UseSqlServer(connectionString);
        //    }
        //}


        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<StockAccessory> StockAccessories { get; set; }

        public DbSet<Image> Images { get; set; }
    }
}
