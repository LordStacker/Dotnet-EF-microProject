using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoundTheCode.EFCore.Application.Models;
using RoundTheCode.EFCore.Application.Services;

namespace RoundTheCode.EFCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(
            InsertUpdateProduct insertProduct)
        {
            var id = await _productService.InsertAsync(insertProduct);
            return Created(string.Empty, new { id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, InsertUpdateProduct updateProduct) {
            await _productService.UpdateAsync(id, updateProduct);
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) {
            await _productService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var product = await _productService.GetAsync(id);
            if(product == null)
                return NotFound();
            return Ok(product);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
            int? skip,
            int? take)
        {
            if (skip.HasValue && take.HasValue)
{
                return Ok(await _productService.GetAllAsync(
                    skip.Value,
                    take.Value));
            }
            return Ok(await _productService.GetAllSync());
        }
    }
}
