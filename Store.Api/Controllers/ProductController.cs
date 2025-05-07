using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Models.CategoryDtos;
using Store.Core.Entities;
using Store.Core;
using Microsoft.EntityFrameworkCore;
using Store.Api.Models;
using Store.Api.Models.ProductDtos;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto input)
        {
            var existByArticle = await _dbContext.Products.AsNoTracking()
              .FirstOrDefaultAsync(c => c.Article.ToUpper().Trim() == input.Article.ToUpper().Trim());
            if (existByArticle != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "Article order already exist!" });
            }

            var product = await _dbContext.Products.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name.ToUpper().Trim() == input.Name.ToUpper().Trim());

            if (product == null)
            {
                product = _mapper.Map<Product>(input);

                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK,
                        new Response { IsSuccess = true, Message = $"Product created successfully!!!" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
            new Response { Status = "Error", Message = "This product already  exist!" });

        }
    }
}
