﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CMSSystems.StockManagementDemo.Domain.Models
{
    public class Vehicle : ModelBase<Guid>
    {
        public Vehicle()
        {
            this.Id = Guid.NewGuid();
            this.Accessories = new HashSet<StockAccessory>();
            this.Images = new HashSet<Image>();
        }

        [Required]
        public override Guid Id { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int ModelYear { get; set; }

        [Required]
        public string KilometerReading { get; set; }

        [Required]
        public string Colour { get; set; }

        [Required]
        public string IdentificationNumber { get; set; }

        [Required]
        public double RetailPrice { get; set; }

        [Required]
        public string CostPrice  { get; set; }

        //[JsonIgnore]
        public ICollection<StockAccessory> Accessories { get; set; }

        //[JsonIgnore]
        public ICollection<Image> Images { get; set; }
    }
}
