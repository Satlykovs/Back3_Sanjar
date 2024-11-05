public interface ICustomerRepository
{
    Task<Customer> GetCustomerByIdAsync(int id);
    Task<bool> DeleteCustomerByIdAsync(int id);
    Task<IReadOnlyList<Customer>> GetAllCustomersAsync();
    Task UpdateCustomerAsync(Customer customer);
    Task<bool> CreateCustomerAsync(Customer customer);
}