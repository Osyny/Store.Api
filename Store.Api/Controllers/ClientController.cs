using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Api.Models;
using Store.Api.Models.ClientDtos;
using Store.Core;
using Store.Core.Entities;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ClientController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClientDto input)
        {

            var client = await _dbContext.Clients.AsNoTracking()
                .FirstOrDefaultAsync(c =>
             c.Surname.ToUpper().Trim() == input.Surname.ToUpper().Trim() &&
             c.Name.ToUpper().Trim() == input.Name.ToUpper().Trim() &&
             c.FatherName.ToUpper().Trim() == input.FatherName.ToUpper().Trim());

            if (client == null)
            {
                client = _mapper.Map<Client>(input);
                client.RegistrationDate = DateTime.UtcNow;

                await _dbContext.Clients.AddAsync(client);
                await _dbContext.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK,
                        new Response { IsSuccess = true, Message = $"Client created successfully!!!" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
            new Response { Status = "Error", Message = "This Client already  exist!" });

        }
    }
}
