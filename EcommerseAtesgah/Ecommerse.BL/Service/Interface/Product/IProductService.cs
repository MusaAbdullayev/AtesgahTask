using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerse.BL.DTO.Product;

namespace Ecommerse.BL.Service.Interface.Product
{
    public interface IProductService
    {
        Task CreateProduct(CreateProductDTO dto);
        ICollection<GetProductDTO> GetAll();
        Task<GetProductDTO> GetById(int Id);
        Task UpdateProduct(UpdateProductDTO dto);
        Task DeleteProduct(int Id);
    }
}
