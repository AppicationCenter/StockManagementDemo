using CMSSystems.StockManagementDemo.Domain.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSSystems.StockManagementDemo.Domain.Models
{
    [Table("VehicleAccessories")]
    public class VehicleAccessory : ModelBase<Guid>
    {
        [ForeignKey(nameof(Vehicle))]
        public Guid VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        [ForeignKey(nameof(StockAccessory))]
        public int StockAccessoryId { get; set; }

        public StockAccessory StockAccessory { get; set; }
    }
}
