



using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class OrderController : Controller
{
    private readonly IOrderRepository _orderRepository; 

    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpGet] 
    public async Task<IActionResult> Index()
    {
        var orders = await _orderRepository.GetAllOrdersAsync();
        return View(orders); 
    }

    [HttpGet("Create")] 
    public IActionResult Create()
    {
        return View(new Order()); 
    }

    [HttpPost("Create")] 
    public async Task<IActionResult> Create([FromForm] Order order)
    {
        if (!ModelState.IsValid)
        {
            return View(order);
        }

        await _orderRepository.CreateOrderAsync(order);
        return RedirectToAction("Index");
    }

    [HttpGet("Edit/{id}")] 
    public async Task<IActionResult> Edit(int id)
    {
        var order = await _orderRepository.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        return View(order); 
    }

    [HttpPost("Edit")] // Тут не работало, когда был Patch, и теперь не работает, ругается на какой-то CSRF, что это?
    [IgnoreAntiforgeryToken] 
    public async Task<IActionResult> Edit([FromForm] Order order)
    {
        if (!ModelState.IsValid)
        {
            return View(order);
        }

        await _orderRepository.UpdateOrderAsync(order);
        return RedirectToAction("Index");
    }

    [HttpGet("Details/{id}")] 
    public async Task<IActionResult> Details(int id)
    {
        var order = await _orderRepository.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        return View(order); 
    }

    [HttpGet("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return View(await _orderRepository.GetOrderByIdAsync(id));
    }
    [HttpPost("Delete/{id}")]  //Знаю, тут должен быть Delete, но почему-то не отправлялась в таком случае форма, пришлось поменять и тут, и там
    public async Task<IActionResult> DeleteOrder([FromForm] int id)
    {
        if (await _orderRepository.DeleteOrderByIdAsync(id))
        {
            return RedirectToAction("Index");
        }
        return NotFound("Такой заказ не найден."); 
    }
}
