using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        public required string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        [MaxLength(25)]
        public required string Article { get; set; }
        [Required]
        [Precision(12, 2)]
        public decimal Price { get; set; }
    }
}
