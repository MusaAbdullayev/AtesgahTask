using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ecommerse.BL.DTO.Product
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public IFormFile Image { get; set; }

        public int CategoryId { get; set; }
    }
}
