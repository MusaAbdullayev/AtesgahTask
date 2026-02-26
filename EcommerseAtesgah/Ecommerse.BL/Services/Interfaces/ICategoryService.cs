using Ecommerse.BL.DTOS.CategoryDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse.BL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryGetDto>> GetAsync();
        Task<CategoryGetDto?> GetByIdAsync(int id);
        Task CreateAsync(CategoryCreateDto dto);
        Task UpdateAsync(CategoryUpdateDto dto, int id);
        Task Delete(int id);
    }
}
