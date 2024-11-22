public interface IOrderRepository
{
    Task<Order> GetOrderByIdAsync(int id);
    Task<bool> DeleteOrderByIdAsync(int id);
    Task<IReadOnlyList<Order>> GetAllOrdersAsync();
    Task UpdateOrderAsync(Order order);
    Task CreateOrderAsync(Order order);
}