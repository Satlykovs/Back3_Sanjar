using ProductAPI.BussinessLogic.Interfaces;
using ProductAPI.Models;

namespace ProductAPI.BussinessLogic.Implementation;


public class ProductManager : IProductManager
{
    private readonly IProductRepository _productRepository;

    public ProductManager(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDTO> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return product == null ? null : MapToDto(product);
    }

    public async Task<PagedResult<ProductDTO>> GetProductsAsync(
        int pageNumber, 
        int pageSize, 
        string sortBy, 
        string sortOrder, 
        string filter)
    {
        var result = await _productRepository.GetPagedAsync(pageNumber, pageSize, sortBy, sortOrder, filter);
        var dtos = result.Items.Select(MapToDto).ToList();

        return new PagedResult<ProductDTO>(dtos, result.TotalCount, result.PageNumber, result.PageSize);
    }

    public async Task<ProductDTO> CreateProductAsync(ProductDTO dto)
    {
        
        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Category = dto.Category
        };

        await _productRepository.AddAsync(product);
        return MapToDto(product);
    }

    public async Task UpdateProductAsync(int id, ProductDTO dto)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) throw new KeyNotFoundException("Product not found");

        product.Name = dto.Name;
        product.Price = dto.Price;
        product.Category = dto.Category;

        await _productRepository.UpdateAsync(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) throw new KeyNotFoundException("Product not found");
        
        await _productRepository.DeleteAsync(id);
    }

    private static ProductDTO MapToDto(Product product)
    {
        return new ProductDTO
        {
            Name = product.Name,
            Price = product.Price,
            Category = product.Category,
        };
    }
}