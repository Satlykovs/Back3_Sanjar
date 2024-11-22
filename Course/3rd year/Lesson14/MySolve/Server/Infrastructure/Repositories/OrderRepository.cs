using Microsoft.EntityFrameworkCore;

public class OrderRepository : IOrderRepository
{
    private readonly DeliveryContext _deliveryContext;

    public OrderRepository(DeliveryContext deliveryContext)
    {
        _deliveryContext = deliveryContext;
    }


    public async Task<Order> GetOrderByIdAsync(int id)
    {
        return await _deliveryContext.Orders
        .Include(o => o.Customer)
        .Include(o => o.Products)
        .FirstOrDefaultAsync(o => o.Id == id);
    }
    public async Task<bool> DeleteOrderByIdAsync(int id)
    {
        var order = await _deliveryContext.Orders
        .Include(o => o.Customer)
        .Include(o => o.Products)  //У меня долго была тут бага, пока не сделал include-ы. Вопрос, почему не удаляются таким образом записи из других таблиц?
        .FirstOrDefaultAsync(o => o.Id == id);  //Хотя без этих подтягиваний наоборот ругалось, что попытка удалить данные отсюда приведет к удалению Customer и Product.
        if (order != null)
        {
            _deliveryContext.Orders.Remove(order);
            await _deliveryContext.SaveChangesAsync();      
            return true;
        }
        return false;
    }
    public async Task<IReadOnlyList<Order>> GetAllOrdersAsync()
    {
        return (await _deliveryContext.Orders
        .Include(o => o.Customer)
        .Include(o => o.Products)
        .ToListAsync()).AsReadOnly();
    }
    public async Task UpdateOrderAsync(Order order)
    {
        _deliveryContext.Orders.Update(order); // Я вообще не уверен, что Update работает, когда такая модель данных, которая состоит из вложенных в нее других
        await _deliveryContext.SaveChangesAsync();
    }
    public async Task CreateOrderAsync(Order order)
    {
        var existingCustomer = await _deliveryContext.Customers
                .FirstOrDefaultAsync(c => c.Email == order.Customer.Email);

        if (existingCustomer != null)
        {
            order.Customer = existingCustomer;
        }
    
        if (order.Products != null)
        {
            foreach (var product in order.Products)
            {
                var existingProduct = await _deliveryContext.Products
                    .FirstOrDefaultAsync(p => p.Name == product.Name); 

                if (existingProduct != null)
                {
                    
                    existingProduct = product;
                }
            }
        }

        
        await _deliveryContext.Orders.AddAsync(order);
        await _deliveryContext.SaveChangesAsync();


    }
}
