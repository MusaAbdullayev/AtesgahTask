using AutoMapper;
using Ecommerse.BL.DTOS.CategoryDTOS;
using Ecommerse.BL.Services.Interfaces;
using Ecommerse.Core.Entities;
using Ecommerse.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse.BL.Services.Implements
{
    public class CategoryService(ICategoryRepository _repo, IMapper _mapper) : ICategoryService
    {
        public async Task CreateAsync(CategoryCreateDto dto)
        {
            var data = _mapper.Map<Category>(dto);
            await _repo.AddAsync(data);
            await _repo.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await _repo.DeleteAsync(id);
            await _repo.SaveAsync();
        }

        public async Task<IEnumerable<CategoryGetDto>> GetAsync()
        {
            var entities = _repo.GetAll();
            var datas = _mapper.Map<IEnumerable<CategoryGetDto>>(entities);
            return datas;
        }

        public async Task<CategoryGetDto?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            var data = _mapper.Map<CategoryGetDto>(entity);
            return data;
        }

        public async Task UpdateAsync(CategoryUpdateDto dto, int id)
        {
            var data = await _repo.GetByIdAsync(id);
            data.Name = dto.Name;
            await _repo.SaveAsync();
        }
    }
}
