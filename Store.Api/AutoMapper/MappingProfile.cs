using AutoMapper;
using Store.Api.Models.CategoryDtos;
using Store.Api.Models.ClientDtos;
using Store.Api.Models.ProductDtos;
using Store.Core.Entities;

namespace Store.Api.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
