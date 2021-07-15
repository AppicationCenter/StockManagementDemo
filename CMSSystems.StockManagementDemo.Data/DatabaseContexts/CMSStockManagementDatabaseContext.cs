using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Get connection string from the settings");
            }
        }
    }
}
