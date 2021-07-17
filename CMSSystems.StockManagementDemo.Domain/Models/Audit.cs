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
    public class Audit<T> : ModelBase<Guid>
    {
        public Audit()
        {
            this.Id = Guid.NewGuid();
        }

        [Required]
        public override Guid Id { get; set; }

        [Required]
        public string EntityName { get; set; }

        [Required]
        public T EntityId { get; set; }
    }
}
