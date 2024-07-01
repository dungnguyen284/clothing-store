using ClothingStore.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly IProductService _productService;
        //private readonly ICategoryService _categoryService;

        //public ProductController(IProductService productService, ICategoryService categoryService)
        //{
        //    _productService = productService;
        //    _categoryService = categoryService;
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllProducts()
        //{
        //    var products = await _productService.GetAllProductsAsync();
        //    return Ok(products);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetProductById(int id)
        //{
        //    var product = await _productService.GetProductByIdAsync(id);
        //    return Ok(product);
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
        //{
        //    var product = _mapper.Map<Product>(productDto);
        //    var createdProduct = await _productService.CreateProductAsync(product);
        //    return Ok(createdProduct);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        //{
        //    var product = _mapper.Map<Product>(productDto);
        //    product.Id = id;
        //    var updatedProduct = await _productService.UpdateProductAsync(product);
        //    return Ok(updatedProduct);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    await _productService.DeleteProduct(id);
        //    return Ok();
        //}

        //[HttpGet("categories")]
        //public async Task<IActionResult> GetAllCategories()
        //{
        //    var categories = await _categoryService.GetAllCategoriesAsync();
        //    return Ok(categories);
        //}
    }
}
