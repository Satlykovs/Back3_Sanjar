using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : Controller
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(int id)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(id);
        if  (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        return Ok(await _customerRepository.GetAllCustomersAsync());
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if  (await _customerRepository.CreateCustomerAsync(customer))
        {
            return Ok();
        }

        return BadRequest("Customer with such email already exists");
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _customerRepository.UpdateCustomerAsync(customer);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        if (await _customerRepository.DeleteCustomerByIdAsync(id))
        {
            return Ok();
        }
        return NotFound("Such customer not found");
    }
}