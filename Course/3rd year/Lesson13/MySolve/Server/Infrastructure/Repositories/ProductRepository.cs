using Microsoft.EntityFrameworkCore;

public class ProductRepository : IProductRepository
{

    private readonly DeliveryContext _deliveryContext;

    public ProductRepository(DeliveryContext deliveryContext)
    {
        _deliveryContext = deliveryContext;
    }
    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _deliveryContext.Products.FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<bool> DeleteProductByIdAsync(int id)
    {
        var product = await _deliveryContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product != null)
        {
            _deliveryContext.Products.Remove(product);
            await _deliveryContext.SaveChangesAsync();
            return true;
        }
        return false;
    }
    public async Task<IReadOnlyList<Product>> GetAllProductsAsync()
    {
        return (await _deliveryContext.Products.ToListAsync()).AsReadOnly();
    }
    public async Task UpdateProductAsync(Product product)
    {
        _deliveryContext.Update(product);
        await _deliveryContext.SaveChangesAsync();
    }
    public async Task<bool> AddProductAsync(Product product)
    {
        if (await _deliveryContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id) == null)
        {
            await _deliveryContext.Products.AddAsync(product);
            await _deliveryContext.SaveChangesAsync();
            return true;
        }
        return false;
    }
}