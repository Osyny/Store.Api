using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Models.CategoryDtos;
using Store.Core.Entities;
using Store.Core;
using Store.Api.Models;
using Store.Api.Models.OrderDtos;
using Microsoft.EntityFrameworkCore;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderDto input)
        {
            if (input.Positions == null || !input.Positions.Any())
                return StatusCode(StatusCodes.Status500InternalServerError,
                new Response { Status = "Error", Message = "Incorrect order details." });

            var existOrder = await _dbContext.Orders.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Number.ToUpper().Trim() == input.Number.ToUpper().Trim());
            if (existOrder != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "Number order already exist!" });
            }

            var newOrder = new Order()
            {
                Number = input.Number,
                Date = input.Date,
                ClientId = input.ClientId,
                Positions = input.Positions.Select(p => new PositionOrder()
                {
                    ProductId = p.ProductId,
                    CountProduct = p.CountProduct,
                    PriceProduct = p.PriceProduct,

                }).ToList(),
            };
            newOrder.TotalCost = newOrder.Positions.Sum(pos => pos.CountProduct * pos.PriceProduct);
            _dbContext.Orders.Add(newOrder);
            await _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK,
                  new Response { IsSuccess = true, Message = $"Order created successfully!!!" });

        }
    }
}
