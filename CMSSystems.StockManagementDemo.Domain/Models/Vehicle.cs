using CMSSystems.StockManagementDemo.Domain.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CMSSystems.StockManagementDemo.Domain.Models
{
    [Table("Vehicles")]
    public class Vehicle : ModelBase<Guid>
    {
        public Vehicle()
        {
            this.Id = Guid.NewGuid();
            this.Accessories = new HashSet<VehicleAccessory>();
            this.Images = new HashSet<Image>();
        }

        [Required]
        public override Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string RegistrationNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(25)]
        public string Model { get; set; }

        [Required]
        public int ModelYear { get; set; }

        [Required]
        public int KilometerReading { get; set; }

        [Required]
        [MaxLength(25)]
        public string Colour { get; set; }

        [Required]
        [MaxLength(50)]
        public string IdentificationNumber { get; set; }

        [Required]
        public double RetailPrice { get; set; }

        [Required]
        public double CostPrice  { get; set; }

        [JsonIgnore]
        public ICollection<VehicleAccessory> Accessories { get; set; }

        [JsonIgnore]
        public ICollection<Image> Images { get; set; }
    }
}
