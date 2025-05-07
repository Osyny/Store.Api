using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Models.ClientDtos;
using Store.Core.Entities;
using Store.Core;
using Store.Api.Models;
using Microsoft.EntityFrameworkCore;
using Store.Api.Models.CategoryDtos;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDto input)
        {
            var category = await _dbContext.Categories.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name.ToUpper().Trim() == input.Name.ToUpper().Trim());

            if (category == null)
            {
                category = _mapper.Map<Category>(input);

                await _dbContext.Categories.AddAsync(category);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK,
                        new Response { IsSuccess = true, Message = $"Category created successfully!!!" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
            new Response { Status = "Error", Message = "This Category already  exist!" });

        }
    }
}
