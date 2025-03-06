namespace ProductAPI.BussinessLogic.Interfaces;

using ProductAPI.Models;

public interface IProductManager
{
    Task<ProductDTO> GetProductByIdAsync(int id);
    Task<PagedResult<ProductDTO>> GetProductsAsync(int pageNumber, int pageSize, string sortBy, string sortOrder, string filter);
    Task<ProductDTO> CreateProductAsync(ProductDTO product);
    Task UpdateProductAsync(int id, ProductDTO product);
    Task DeleteProductAsync(int id);
}