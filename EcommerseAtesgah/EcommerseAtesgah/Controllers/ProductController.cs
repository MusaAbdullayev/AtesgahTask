using Ecommerse.BL.DTO.Product;
using Ecommerse.BL.Service.Interface.Product;
using Ecommerse.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcommerseAtesgah.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(productService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            return Ok(await productService.GetById(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateProductDTO product)
        {
            await productService.CreateProduct(product);
            return Created();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromForm] UpdateProductDTO dto)
        {
            await productService.UpdateProduct(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await productService.DeleteProduct(id);
            return Ok();
        }

       
    }
}
