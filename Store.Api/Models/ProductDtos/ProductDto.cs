using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Store.Api.Models.ProductDtos
{
    public class ProductDto : EntityDto
    {
        [Required]
        public required string Name { get; set; }

        public int CategoryId { get; set; }
        [Required]
        public required string Article { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
