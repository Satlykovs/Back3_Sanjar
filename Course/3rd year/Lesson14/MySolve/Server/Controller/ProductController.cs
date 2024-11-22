using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPrdouct(int id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        return Ok(await _productRepository.GetAllProductsAsync());
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (await _productRepository.AddProductAsync(product))
        {
            return Ok();
        }
        return BadRequest("Such product already exists");
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateProduct([FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _productRepository.UpdateProductAsync(product);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        if (await _productRepository.DeleteProductByIdAsync(id))
        {
            return Ok();
        }
        return NotFound("Such product not found.");
    }
}