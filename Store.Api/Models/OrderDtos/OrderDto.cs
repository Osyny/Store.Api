using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.Api.Models.OrderDtos
{
    public class OrderDto : EntityDto
    {
        [Required]
        public required string Number { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }

        [Required]
        public decimal TotalCost { get; set; }

        public List<PositionOrderDto> Positions { get; set; }
    }
}
