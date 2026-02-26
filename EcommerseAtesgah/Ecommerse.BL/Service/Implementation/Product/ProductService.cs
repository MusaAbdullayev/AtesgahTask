using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerse.Core.Entities;
using Ecommerse.BL.DTO.Product;
using Ecommerse.BL.Service.Interface.Product;
using Ecommerse.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Ecommerse.BL.Helper.Exception.Base;

namespace Ecommerse.BL.Service.Implementation.Product
{
    public  class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task CreateProduct(CreateProductDTO dto)
        {
            string fileName = Guid.NewGuid() + Path.GetExtension(dto.Image.FileName);

            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            string fullPath = Path.Combine(uploadPath, fileName);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                await dto.Image.CopyToAsync(stream);
            }

            var product = new Core.Entities.Product
            {
                Name = dto.Name,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
                ImageUrl = "/uploads/" + fileName
            };
            await _repository.AddAsync(product);
            await _repository.SaveAsync();
            
        }

        public ICollection<GetProductDTO> GetAll()
        {
            var products = _repository.GetAll("Category");
            return _mapper.Map<ICollection<GetProductDTO>>(products);
        }

        public async Task UpdateProduct(UpdateProductDTO dto)
        {
            var product = await _repository.GetAll("Category")
                .FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (product == null) throw new NotFoundException("Bele mehsul movcud deyil", 404);

            if (dto.Image != null)
            {
                if (!string.IsNullOrEmpty(product.ImageUrl))
                {
                    var oldPath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        product.ImageUrl.TrimStart('/')
                    );

                    if (File.Exists(oldPath))
                        File.Delete(oldPath);
                }
                string fileName = Guid.NewGuid() +
                                  Path.GetExtension(dto.Image.FileName);

                string uploadPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "uploads"
                );


                string fullPath = Path.Combine(uploadPath, fileName);

                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    await dto.Image.CopyToAsync(stream);
                }

                product.ImageUrl = "/uploads/" + fileName;
            }

            _mapper.Map(dto, product);
            
            await _repository.SaveAsync();
            
        }

        public async Task DeleteProduct(int Id)
        {
            var product = await _repository.GetAll("Category")
                .FirstOrDefaultAsync(x => x.Id == Id);
            if (product == null) throw new NotFoundException("Bele mehsul movcud deyil", 404);
            await _repository.DeleteAsync(product.Id);
            await _repository.SaveAsync();

        }

        public async Task<GetProductDTO> GetById(int Id)
        {
            var product = await _repository.GetAll("Category")
                .FirstOrDefaultAsync(x => x.Id == Id);
            if (product == null) throw new NotFoundException("Bele mehsul movcud deyil", 404);
            return _mapper.Map<GetProductDTO>(product);
        }
    }
    }

