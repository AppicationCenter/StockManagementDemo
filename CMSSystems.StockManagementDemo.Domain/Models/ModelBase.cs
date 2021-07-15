using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSSystems.StockManagementDemo.Domain.Models
{
    public class ModelBase<T>
    {
        public ModelBase()
        {
            this.DateCreated = DateTime.Now;
            this.DateUpdated = DateTime.Now;
        }

        [Key]
        public virtual T Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public bool Deleted { get; set; }
    }
}
