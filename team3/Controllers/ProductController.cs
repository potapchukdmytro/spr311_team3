using Microsoft.AspNetCore.Mvc;
using team3.BLL.Services.Product;
using team3.DTOs.Product;

namespace team3.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductDto dto)
        {
            var response = await _productService.CreateAsync(dto);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _productService.DeleteAsync(id);
            return response.IsSuccess? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateProductDto dto)
        {
            var response = await _productService.UpdateAsync(dto);
            return response.IsSuccess? Ok(response) : BadRequest(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _productService.GetAllAsync();
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
