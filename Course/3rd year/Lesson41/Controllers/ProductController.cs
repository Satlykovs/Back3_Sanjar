namespace ProductAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProductAPI.BussinessLogic.Implementation;
using ProductAPI.BussinessLogic.Interfaces;
using ProductAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductManager _productManager;

    public ProductController(IProductManager productManager)
    {
        _productManager = productManager;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productManager.GetProductByIdAsync(id);
        return product == null ? NotFound() : Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery]int pageNumber,
        [FromQuery] int pageSize,
        [FromQuery] string sortBy,
        [FromQuery] string sortOrder,
        [FromQuery] string? filter)
        {
            var result = await _productManager.GetProductsAsync(pageNumber, pageSize, sortBy, sortOrder, filter);
            return Ok(result);
        }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }
        var createdProduct = await _productManager.CreateProductAsync(dto);
        return Ok();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }
        await _productManager.UpdateProductAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _productManager.DeleteProductAsync(id);
        return NoContent();
    }
}