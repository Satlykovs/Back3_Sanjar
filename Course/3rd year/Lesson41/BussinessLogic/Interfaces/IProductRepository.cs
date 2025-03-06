using ProductAPI.Models;

namespace ProductAPI.BussinessLogic.Interfaces;


public interface IProductRepository
{
    Task<Product> GetByIdAsync(int id);
    Task<PagedResult<Product>> GetPagedAsync(int pageNumber, int pageSize, string sortBy, string sortOrder, string filter);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync (int id);
}