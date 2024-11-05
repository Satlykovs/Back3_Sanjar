



// using Microsoft.AspNetCore.Mvc;

// [Route("api/[controller]")]
// public class OrderController : Controller
// {
//     private readonly IOrderRepository _orderRepository; 

//     public OrderController(IOrderRepository orderRepository)
//     {
//         _orderRepository = orderRepository;
//     }

//     [HttpGet] 
//     public async Task<IActionResult> Index()
//     {
//         var orders = await _orderRepository.GetAllOrdersAsync();
//         return Ok(orders); 
//     }

//     [HttpGet("Create")] 
//     public IActionResult Create()
//     {
//         return View(new Order()); 
//     }

//     [HttpPost("Create")] 
//     public async Task<IActionResult> Create([FromForm] Order order)
//     {
//         if (!ModelState.IsValid)
//         {
//             return View(order);
//         }

//         await _orderRepository.CreateOrderAsync(order);
//         return RedirectToAction("Index");
//     }

//     [HttpGet("Edit/{id}")] 
//     public async Task<IActionResult> Edit(int id)
//     {
//         var order = await _orderRepository.GetOrderByIdAsync(id);
//         if (order == null)
//         {
//             return NotFound();
//         }
//         return View(order); 
//     }

//     [HttpPatch("Edit")] 
//     public async Task<IActionResult> Edit([FromForm] Order order)
//     {
//         if (!ModelState.IsValid)
//         {
//             return View(order);
//         }

//         await _orderRepository.UpdateOrderAsync(order);
//         return RedirectToAction("Index");
//     }

//     [HttpGet("Details/{id}")] 
//     public async Task<IActionResult> Details(int id)
//     {
//         var order = await _orderRepository.GetOrderByIdAsync(id);
//         if (order == null)
//         {
//             return NotFound();
//         }
//         return View(order); 
//     }

//     [HttpDelete("Delete/{id}")] 
//     public async Task<IActionResult> DeleteOrder([FromForm] int id)
//     {
//         if (await _orderRepository.DeleteOrderByIdAsync(id))
//         {
//             return RedirectToAction("Index");
//         }
//         return NotFound("Такой заказ не найден."); 
//     }
// }

