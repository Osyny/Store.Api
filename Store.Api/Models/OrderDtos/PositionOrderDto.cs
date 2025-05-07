using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.Api.Models.OrderDtos
{
    public class PositionOrderDto
    {
        public int CountProduct { get; set; }
        [Required]
        public decimal PriceProduct { get; set; }

        public int ProductId { get; set; }
    }
}
