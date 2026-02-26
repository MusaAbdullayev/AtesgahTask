using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerse.BL.DTO.Product;
using Ecommerse.Core.Entities;

namespace Ecommerse.BL.Mapper.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDTO, Product>().ReverseMap();
            CreateMap<UpdateProductDTO, Product>().ReverseMap();
            CreateMap<Product, GetProductDTO>()
                .ForMember(dest => dest.CategotyName,
                           opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
