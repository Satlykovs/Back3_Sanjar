using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : ICustomerRepository
{
    private readonly DeliveryContext _deliveryContext;

    public CustomerRepository(DeliveryContext deliveryContext)
    {
        _deliveryContext = deliveryContext;
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return await  _deliveryContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
    }


   public async Task<bool> DeleteCustomerByIdAsync(int id)
    {
        var customer  = await _deliveryContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
        if (customer != null)
        {
            _deliveryContext.Customers.Remove(customer);
            await _deliveryContext.SaveChangesAsync();
            return true;
        }
        return false;
    }
    public async Task<IReadOnlyList<Customer>> GetAllCustomersAsync()
    {
       return (await _deliveryContext.Customers.ToListAsync()).AsReadOnly();
    }
    public async Task UpdateCustomerAsync(Customer customer)
    {
        _deliveryContext.Customers.Update(customer);
        await _deliveryContext.SaveChangesAsync();
    }
    public async Task<bool> CreateCustomerAsync(Customer customer)
    {
        var c = await _deliveryContext.Customers.FirstOrDefaultAsync(c => c.Email == customer.Email);
        if (c == null)
        {
            await _deliveryContext.AddAsync(customer);
            await _deliveryContext.SaveChangesAsync();
            return true;
        }
        return false;
    }
}