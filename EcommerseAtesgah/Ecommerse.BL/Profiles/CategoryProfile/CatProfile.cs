using AutoMapper;
using Ecommerse.BL.DTOS.CategoryDTOS;
using Ecommerse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecommerse.BL.Profiles.CategoryProfile
{
    public class CatProfile : Profile
    {
        public CatProfile()
        {
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryGetDto>();
        }
    }
}
