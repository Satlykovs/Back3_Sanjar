






// using Microsoft.AspNetCore.Mvc;

// [ApiController]
// [Route("api/[controller]")]
// public class OrderController : Controller
// {
//     private readonly IOrderRepository _orderRepository;

//     public OrderController(IOrderRepository orderRepository)
//     {
//         _orderRepository = orderRepository;
//     }

//     [HttpGet("{id}")]
//     public async Task<IActionResult> GetOrder(int id)
//     {
//         var order = await _orderRepository.GetOrderByIdAsync(id);
//         if (order == null)
//         {
//             return NotFound();
//         }
//         return Ok(order);
//     }

//     [HttpGet]
//     public async Task<IActionResult> GetOrders()
//     {
//         return Ok(await _orderRepository.GetAllOrdersAsync());
//     }

//     [HttpPost]
//     public async Task<IActionResult> CreateOrder([FromBody] Order order)
//     {
//         if (!ModelState.IsValid)
//         {
//             return BadRequest(ModelState);
//         }

//         await _orderRepository.CreateOrderAsync(order);
//         return Ok();
//     }

//     [HttpPatch]
//     public async Task<IActionResult> PatchOrder([FromBody] Order order)
//     {
//         if (!ModelState.IsValid)
//         {
//             return BadRequest(ModelState);
//         }
//         await _orderRepository.UpdateOrderAsync(order);
//         return Ok();
//     }

//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeleteOrder(int id)
//     {
//         if (await _orderRepository.DeleteOrderByIdAsync(id))
//         {
//             return Ok();
//         }
//         return NotFound("Such order not found.");
//     }
// }