namespace ProductAPI.BussinessLogic.Implementation;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.BussinessLogic.Interfaces;
using ProductAPI.Models;

public class ProductRepository : IProductRepository
{
    private readonly ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        _context = context;
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<PagedResult<Product>> GetPagedAsync(
        int pageNumber,
        int pageSize,
        string sortBy="id",
        string sortOrder="asc",
        string filter=""
    )
    {
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrEmpty(filter))
        {

            query = query.Where(p => p.Name.Contains(filter) || p.Category.Contains(filter));
        }


        query = sortOrder.ToLower() == "desc" 
            ? query.OrderByDescending(GetSortProperty(sortBy)) 
            : query.OrderBy(GetSortProperty(sortBy));
        

        var totalCount = await query.CountAsync();
        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<Product>(items, totalCount, pageNumber, pageSize);
    }



    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

     public async Task DeleteAsync(int id)
    {
        var product = await GetByIdAsync(id);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    private static Expression<Func<Product, object>> GetSortProperty(string sortBy)
    {
        return sortBy.ToLower() switch
        {
            "name" => p => p.Name,
            "price" => p => p.Price,
            _ => p => p.Id
        };
    }

}