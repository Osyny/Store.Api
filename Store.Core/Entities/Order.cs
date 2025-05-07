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
    public class Order : BaseEntity
    {
        [Required]
        [MaxLength(25)]
        public required string Number { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [Required]
        [Precision(12, 2)]
        public decimal TotalCost { get; set; }
    }
}
