﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSSystems.StockManagementDemo.Domain.Models
{
    [Table("StockAccessories")]
    public class StockAccessory : ModelBase<int>
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey(nameof(Vehicle))]
        public Guid VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
