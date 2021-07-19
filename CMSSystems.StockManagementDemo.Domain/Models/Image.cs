using CMSSystems.StockManagementDemo.Domain.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSSystems.StockManagementDemo.Domain.Models
{
    [Table("Images")]
    public class Image : ModelBase<Guid>
    {
        public Image()
        {
            this.Id = Guid.NewGuid();
        }

        [Required]
        public override Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public byte[] ImageData { get; set; }

        [ForeignKey(nameof(Vehicle))]
        public Guid VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
