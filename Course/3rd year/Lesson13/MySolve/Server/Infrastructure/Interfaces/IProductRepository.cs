public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(int id);
    Task<bool> DeleteProductByIdAsync(int id);
    Task<IReadOnlyList<Product>> GetAllProductsAsync();
    Task UpdateProductAsync(Product product);
    Task<bool> AddProductAsync(Product product);
}